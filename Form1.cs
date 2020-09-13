using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFP_PROYECTO1_Basic_IDE
{
    public partial class Form1 : Form
    {
        private MyLibraries myLibraries = new MyLibraries();

        private int letterPos = 0; 
        public Form1()
        {
            InitializeComponent();
        }

        public static Color[] ParseString(string raw)
        {
            int len = 0;
            foreach (char chr in raw)
            {
                len++;
            }
            Color[] ret = new Color[len];
            string[] parsed = Regex.Split(raw, " ");
            for (int i = 0; i < len; i++)
            {
                ret[i] = Color.Green;
            }
            return ret;
        }

        private void IDELexer_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            // Check for an illegal character in the KeyDown event.
            // Only this characters are all allowed
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^a-z^A-Z^0-9^+^\-^\/^\*^\(^\)^\>^\<^\!^\|^\&^\;^\=]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
            */
        }

        /*
        myLibraries.processFile(IDELexer.Text, IDELexer);

        RowColumn.Text = myLibraries.cursorRowPosition(IDELexer) + "," + myLibraries.cursorColumnPosition(IDELexer);
        */

        private void IDELexer_TextChanged(object sender, EventArgs e)
        {
            // We need to asign the return of the function to some integer that counts the last colored index
            letterPos = myLibraries.processText(IDELexer);

            //myLibraries.processFile(IDELexer.Text, IDELexer);

            // To see the row and column
            RowColumn.Text = myLibraries.cursorRowPosition(IDELexer) + "," + myLibraries.cursorColumnPosition(IDELexer);

            // To log the tokens found
            Log.Text = myLibraries.tokenList;
        }
    }
}
