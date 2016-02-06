using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlQuery
{
    public delegate void TextPastedHandler();

    public class CustomTextBox : System.Windows.Forms.TextBox
    {
        public event TextPastedHandler TextPasted;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // Trap WM_PASTE:
            if (m.Msg == 0x302 && Clipboard.ContainsText())
            {
                TextPasted();
            }
        }
    }
}
