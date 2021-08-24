using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grand_NotePad
{
    public partial class frmMyNotepad : Form
    {
        public frmMyNotepad()
        {
            InitializeComponent();
        }
         //Form Load Event Handler//
        private void frmMyNotepad_Load(object sender, EventArgs e)
        {
            // Set the default File type
            //and the default file extensions of the 2 dialog boxes //
            mySaveFileDialog.Filter = "RTF Files|*.rtf";
            mySaveFileDialog.DefaultExt = "*.rtf";
            myOpenFileDialog.Filter = "RTF Files|*.rtf";
            myOpenFileDialog.DefaultExt = "*.rtf";

            // Display Date in proper format. 2 lines code
            string strCurrentDate = dtpMenu.Value.ToLongDateString();
            rtfBox.Text = strCurrentDate + ":    ";

            // Set the curser at end of text //
            rtfBox.SelectionStart = rtfBox.TextLength;




        }
        // 2 Lines of code Clicking the default returns Font to Arial, 12F, reg
        private void tstDefault_Click(object sender, EventArgs e)
        {
            rtfBox.SelectionFont = new Font("Arial", 12F, FontStyle.Regular);
            rtfBox.SelectionColor = Color.Black;
        }

        private void tstNewFont_Click(object sender, EventArgs e)
        {
            // instansiate a new Font Dialog object. A class basically // 
            FontDialog myFontDialog = new FontDialog();
            myFontDialog.ShowColor = true;

            DialogResult fontResult = myFontDialog.ShowDialog();

            if (fontResult != DialogResult.Cancel)
            {
                rtfBox.SelectionFont = myFontDialog.Font;
                rtfBox.SelectionColor = myFontDialog.Color;
            }

        }

        private void tstRed_Click(object sender, EventArgs e)
        {
            rtfBox.SelectionColor = Color.Red;
        }

        private void tstBold_Click(object sender, EventArgs e)
        {
            rtfBox.SelectionFont = new Font(rtfBox.SelectionFont, FontStyle.Bold);
        }

        private void tstItalic_Click(object sender, EventArgs e)
        {
            rtfBox.SelectionFont = new Font(rtfBox.SelectionFont, FontStyle.Italic);
        }

        private void tstCopy_Click(object sender, EventArgs e)
        {
            rtfBox.Copy();
        }

        private void tstPaste_Click(object sender, EventArgs e)
        {
            rtfBox.Paste();
        }

        private void tstOpen_Click(object sender, EventArgs e)
        {
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    string strFilePath = myOpenFileDialog.FileName;
                    rtfBox.LoadFile(strFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void tstSave_Click(object sender, EventArgs e)
        {
            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    string strFilePath = mySaveFileDialog.FileName;
                    rtfBox.SaveFile(strFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
