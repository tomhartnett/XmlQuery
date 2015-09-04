using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XmlQuery
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clear all the results from the TreeView.
            ClearResults();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            // Copy the results from the TreeView and save them to the Clipboard.
            string results = GetTreeNodesAsText();
            Clipboard.SetData(DataFormats.Text, (object)results);

            copiedLabel.Visible = true;
            fadeTimer.Enabled = true;
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            // Hide the 'copied' label and stop the timer.
            copiedLabel.Visible = false;
            fadeTimer.Enabled = false;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Give the user an open file dialog, let them browse to
            // and open an XML file, and load the file.
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "All files (*.*)|*.*";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                inputFileTextBox.Text = diag.FileName;
                ClearResults();
                LoadXmlFromFile(inputFileTextBox.Text);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set SplitterDistance to some arbitrary value.  This will
            // cause the SplitterMoved event to fire, which will line
            // up the metaResultsLabel with the resultsTreeView.
            splitContainer.SplitterDistance = this.Width / 2 + 100;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Ensure Clear button is lined up with TreeView & Copy Button.
            if (WindowState != FormWindowState.Minimized)
            {
                clearButton.Left = splitContainer.Panel2.Left + 12;
                clearButton.Top = copyButton.Top;
            }
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            QueryXmlAndDisplayResults();
        }

        private void QueryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If user hit the enter key, run the query
            if (e.KeyChar == (char)Keys.Enter)
            {
                QueryXmlAndDisplayResults();
            }
        }

        private void SaveResultsButton_Click(object sender, EventArgs e)
        {
            // Give the user a save file dialog, let them choose a 
            // location/file.
            SaveFileDialog diag = new SaveFileDialog();
            diag.FileName = "results.xml";
            diag.Filter = "All Files(*.*)|*.*";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                string results = GetTreeNodesAsText();

                string filename = diag.FileName;
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                using (StreamWriter sw = new StreamWriter(filename))
                {

                    if (filename.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase))
                    {
                        sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                        // If saving as XML file, you may need to add root-element in order for the
                        // file to display in a browser as XML.
                        sw.WriteLine("<results>");
                    }

                    sw.Write(results);
                    sw.Write("</results>");

                    sw.Close();
                }
            }
        }

        private void SplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // Move the label that displays found nodes count.
            // Add arbitrary pixels to line it up nicely.
            metaResultsLabel.Left = splitContainer.Panel2.Left + 10;

            // Ensure Clear button is lined up with TreeView & Copy Button.
            clearButton.Left = splitContainer.Panel2.Left + 12;
            clearButton.Top = copyButton.Top;
        }

        private void ParseButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceTextBox.Text))
                return;

            LoadXmlFromTextBox(sourceTextBox.Text);
        }

        private void SourceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                sourceTextBox.SelectAll();
            }
        }

        #endregion

        #region Methods

        private void AppendChildNodes(TreeNode node, XmlElement e)
        {
            // Loop through any child nodes of the XmlElement passed in.
            foreach (XmlNode childXmlNode in e.ChildNodes)
            {
                XmlElement childXmlElement = childXmlNode as XmlElement;
                if (childXmlElement != null)
                {
                    // For each child XmlElement, create a new TreeNode and add
                    // it to the child nodes of the passed in TreeNode
                    TreeNode childTreeNode = CreateTreeNodeFromXmlElement(childXmlElement);
                    node.Nodes.Add(childTreeNode);

                    // Recursively check for children of this child node
                    AppendChildNodes(childTreeNode, childXmlElement);
                }
            }
        }

        private TreeNode CreateTreeNodeFromXmlAttribute(XmlAttribute a)
        {
            // Create a new tree node to return
            TreeNode node = new TreeNode();
            // Save the element to the .Tag property for later use if needed
            node.Tag = a;
            // Set the text of the tree node to the attribute's text
            node.Text = a.InnerText;

            return node;
        }

        private TreeNode CreateTreeNodeFromXmlElement(XmlElement e)
        {
            // Create a new tree node to return
            TreeNode node = new TreeNode();
            // Save the element to the .Tag property for later use if needed
            node.Tag = e;

            // Build up the display text for the tree node; this process is
            // pretty manual.
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<{0}", e.Name));
            // Have to loop through attributes and add to display text
            foreach (XmlAttribute attr in e.Attributes)
            {
                sb.Append(string.Format(" {0}=\"{1}\"", attr.Name, attr.Value));
            }

            if (e.HasChildNodes && e.FirstChild.GetType().ToString() == "System.Xml.XmlText")
            {
                // This element has some text between its open & close tags
                sb.Append(string.Format(">{0}</{1}>", e.FirstChild.InnerText, e.Name));
            }
            else if (e.HasChildNodes)
            {
                // This element doesn't have any text, but it has child elements
                sb.Append(">");
            }
            else
            {
                // This element has neither text or child nodes
                sb.Append("/>");
            }

            // Set display text of the tree node
            node.Text = sb.ToString();

            return node;
        }

        private string GetFormattedXmlAsString(XmlDocument xmlDoc)
        {
            // The XmlDocument class doesn't contain any formatting in the
            // XML (unless the original source document had formatting).
            // If you want formatting, have to write out the XML to a string
            // with an XmlTextWriter specifying Formatted.Indented.
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlDoc.WriteContentTo(xmlTextWriter);
            xmlTextWriter.Flush();
            return stringWriter.ToString();
        }

        private string GetTreeNodesAsText()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultsTreeView.Nodes.Count; i++)
            {
                sb.Append(RecursiveGetTreeNodeText(resultsTreeView.Nodes[i], 0));
            }
            return sb.ToString();
        }

        private void LoadXmlFromFile(string filename)
        {
            try
            {
                // Load Xml from input file.
                _xmlDoc.Load(filename);
                // Display the loaded Xml.
                string formattedXml = GetFormattedXmlAsString(_xmlDoc);
                sourceTextBox.Text = formattedXml;
                // Enabled some controls.
                queryTextBox.Enabled = true;
                queryButton.Enabled = true;
                sourceXmlLabel.Text = "LOADED FROM FILE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sourceTextBox.Text = string.Empty;
                queryTextBox.Enabled = false;
                queryButton.Enabled = false;
                sourceXmlLabel.Text = string.Empty;
            }
        }

        private void LoadXmlFromTextBox(string xml)
        {
            try
            {
                // Load xml from text in textbox.
                _xmlDoc.LoadXml(xml);
                queryTextBox.Enabled = true;
                queryButton.Enabled = true;
                // Clear input file textbox to reflect that xml was not loaded from file.
                inputFileTextBox.Clear();
                sourceXmlLabel.Text = "PARSED INPUT FROM UI";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                queryTextBox.Enabled = false;
                queryButton.Enabled = false;
                sourceXmlLabel.Text = string.Empty;
            }
        }

        private void QueryXmlAndDisplayResults()
        {
            if (string.IsNullOrEmpty(queryTextBox.Text))
                return;

            try
            {
                // Get the XPath query results.
                XmlNodeList nodes = _xmlDoc.SelectNodes(queryTextBox.Text);
                // Display number of nodes found.
                metaResultsLabel.Text = string.Format("NODES FOUND: {0}", nodes.Count);

                // Clear any previous results.
                ClearResults();

                // Populate the TreeView with results of the query.
                resultsTreeView.BeginUpdate();
                foreach (XmlNode node in nodes)
                {
                    TreeNode treeNode = null;
                    if (node is XmlElement)
                    {
                        // Create a new TreeNode for every XmlElement and add it
                        // to the TreeView.
                        XmlElement element = node as XmlElement;
                        treeNode = CreateTreeNodeFromXmlElement(element);
                        AppendChildNodes(treeNode, element);
                        
                        if (treeNode.Nodes.Count > 0)
                        {
                            treeNode.LastNode.Text += string.Format("</{0}>", element.Name);
                        }
                    }

                    else if (node is XmlAttribute)
                    {
                        treeNode = CreateTreeNodeFromXmlAttribute(node as XmlAttribute);
                    }
                    else
                    {
                        continue;
                    }

                    resultsTreeView.Nodes.Add(treeNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                resultsTreeView.EndUpdate();
            }

            if (resultsTreeView.Nodes.Count > 0)
            {
                saveResultsButton.Enabled = true;
                copyButton.Enabled = true;
            }
            else
            {
                saveResultsButton.Enabled = false;
                copyButton.Enabled = false;
            }
        }

        private string RecursiveGetTreeNodeText(TreeNode node, int level)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < level; i++)
            {
                sb.Append('\t');
            }

            sb.Append(node.Text);
            sb.Append(Environment.NewLine);

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                sb.Append(RecursiveGetTreeNodeText(node.Nodes[i], level + 1));
            }

            return sb.ToString();
        }

        private void ClearResults()
        {
            resultsTreeView.Nodes.Clear();
            metaResultsLabel.Text = "NODES FOUND:";
            copyButton.Enabled = false;
            saveResultsButton.Enabled = false;
        }

        #endregion

        #region Fields

        private XmlDocument _xmlDoc = new XmlDocument();

        private const string OUTPUT_RESULTS_ROOT_ELEMENT = "Results";

        #endregion
    }
}
