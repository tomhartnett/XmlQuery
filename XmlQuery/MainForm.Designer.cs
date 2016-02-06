namespace XmlQuery
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loadButton = new System.Windows.Forms.Button();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.resultsTreeView = new System.Windows.Forms.TreeView();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.metaResultsLabel = new System.Windows.Forms.Label();
            this.saveResultsButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.copiedLabel = new System.Windows.Forms.Label();
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.clearButton = new System.Windows.Forms.Button();
            this.parseButton = new System.Windows.Forms.Button();
            this.sourceXmlLabel = new System.Windows.Forms.Label();
            this.sourceTextBox = new XmlQuery.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(841, 12);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFileTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(823, 23);
            this.inputFileTextBox.TabIndex = 0;
            // 
            // resultsTreeView
            // 
            this.resultsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsTreeView.Location = new System.Drawing.Point(0, 0);
            this.resultsTreeView.Name = "resultsTreeView";
            this.resultsTreeView.Size = new System.Drawing.Size(600, 415);
            this.resultsTreeView.TabIndex = 5;
            // 
            // queryTextBox
            // 
            this.queryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryTextBox.Enabled = false;
            this.queryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryTextBox.Location = new System.Drawing.Point(12, 41);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(822, 23);
            this.queryTextBox.TabIndex = 2;
            this.queryTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QueryTextBox_KeyPress);
            // 
            // queryButton
            // 
            this.queryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.queryButton.Enabled = false;
            this.queryButton.Location = new System.Drawing.Point(841, 41);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(75, 23);
            this.queryButton.TabIndex = 3;
            this.queryButton.Text = "Query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // metaResultsLabel
            // 
            this.metaResultsLabel.AutoSize = true;
            this.metaResultsLabel.Location = new System.Drawing.Point(313, 70);
            this.metaResultsLabel.Name = "metaResultsLabel";
            this.metaResultsLabel.Size = new System.Drawing.Size(98, 13);
            this.metaResultsLabel.TabIndex = 5;
            this.metaResultsLabel.Text = "NODES FOUND: 0";
            // 
            // saveResultsButton
            // 
            this.saveResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveResultsButton.Enabled = false;
            this.saveResultsButton.Location = new System.Drawing.Point(841, 507);
            this.saveResultsButton.Name = "saveResultsButton";
            this.saveResultsButton.Size = new System.Drawing.Size(75, 23);
            this.saveResultsButton.TabIndex = 9;
            this.saveResultsButton.Text = "Save";
            this.saveResultsButton.UseVisualStyleBackColor = true;
            this.saveResultsButton.Click += new System.EventHandler(this.SaveResultsButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Enabled = false;
            this.copyButton.Location = new System.Drawing.Point(760, 507);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 8;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 86);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.sourceTextBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.resultsTreeView);
            this.splitContainer.Size = new System.Drawing.Size(904, 415);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 8;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer_SplitterMoved);
            // 
            // copiedLabel
            // 
            this.copiedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copiedLabel.AutoSize = true;
            this.copiedLabel.ForeColor = System.Drawing.Color.Blue;
            this.copiedLabel.Location = new System.Drawing.Point(714, 512);
            this.copiedLabel.Name = "copiedLabel";
            this.copiedLabel.Size = new System.Drawing.Size(40, 13);
            this.copiedLabel.TabIndex = 10;
            this.copiedLabel.Text = "Copied";
            this.copiedLabel.Visible = false;
            // 
            // fadeTimer
            // 
            this.fadeTimer.Interval = 1000;
            this.fadeTimer.Tick += new System.EventHandler(this.FadeTimer_Tick);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(93, 507);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // parseButton
            // 
            this.parseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.parseButton.Location = new System.Drawing.Point(12, 507);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(75, 23);
            this.parseButton.TabIndex = 6;
            this.parseButton.Text = "Parse";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // sourceXmlLabel
            // 
            this.sourceXmlLabel.AutoSize = true;
            this.sourceXmlLabel.Location = new System.Drawing.Point(12, 70);
            this.sourceXmlLabel.Name = "sourceXmlLabel";
            this.sourceXmlLabel.Size = new System.Drawing.Size(0, 13);
            this.sourceXmlLabel.TabIndex = 11;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Location = new System.Drawing.Point(0, 0);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceTextBox.Size = new System.Drawing.Size(300, 415);
            this.sourceTextBox.TabIndex = 0;
            this.sourceTextBox.TextPasted += new XmlQuery.TextPastedHandler(this.SourceTextBox_TextPasted);
            this.sourceTextBox.TextChanged += new System.EventHandler(this.SourceTextBox_TextChanged);
            this.sourceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SourceTextBox_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 542);
            this.Controls.Add(this.sourceXmlLabel);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.copiedLabel);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.saveResultsButton);
            this.Controls.Add(this.metaResultsLabel);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.inputFileTextBox);
            this.Controls.Add(this.loadButton);
            this.Name = "MainForm";
            this.Text = "XmlQuery";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.TreeView resultsTreeView;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Label metaResultsLabel;
        private System.Windows.Forms.Button saveResultsButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label copiedLabel;
        private System.Windows.Forms.Timer fadeTimer;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.Label sourceXmlLabel;
        private CustomTextBox sourceTextBox;
    }
}

