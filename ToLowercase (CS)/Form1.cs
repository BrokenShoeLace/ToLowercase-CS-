using System;
using System.Windows.Forms;

namespace Crouchie.ToLowercase.CS
{
    /// <summary>
    /// This program is provided AS-IS and allows the user to 
    /// quickly paste in text to be converted to lowercase and 
    /// copy to the clipboard.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Constants
        public const int WM_QUERYENDSESSION = 0x11;
        #endregion

        #region Convert
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.ToLower().Trim();
        }
        #endregion

        #region Exit
        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Clear
        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox1.Focus();
        }
        #endregion

        #region Copy to Clipboard
        private void Button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                Clipboard.SetText(textBox2.Text.Trim());
            }

        }
        #endregion

        #region WndProc
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
                Application.Exit();
            base.WndProc(ref m);
        }
        #endregion

    }
}
