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

            /*
            myLibraries.checkKeyword("+", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("-", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("*", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("/", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("++", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("++", Color.Blue, 0, IDELexer);

            // Relational operators
            myLibraries.checkKeyword(">", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("<", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword(">=", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("<=", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("==", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("!=", Color.Blue, 0, IDELexer);

            // Logical operators
            myLibraries.checkKeyword("||", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("&&", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("!", Color.Blue, 0, IDELexer);

            // Agrupation signs
            myLibraries.checkKeyword("(", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword(")", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("{", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("}", Color.Blue, 0, IDELexer);

            // Agination and end of sentence
            myLibraries.checkKeyword("=", Color.Magenta, 0, IDELexer);
            myLibraries.checkKeyword(";", Color.Magenta, 0, IDELexer);

            // Reserved words in green
            myLibraries.checkKeyword("SI", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("SINO", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("SINO_SI", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("MIENTRAS", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("HACER", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("PARA", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("DESDE", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("HASTA", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("INCREMENTO", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("INICIO", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("FIN", Color.Green, 0, IDELexer);

            // Reserved words in colors
            myLibraries.checkKeyword("entero", Color.Purple, 0, IDELexer);
            myLibraries.checkKeyword("decimal", Color.LightBlue, 0, IDELexer);
            myLibraries.checkKeyword("cadena", Color.Gray, 0, IDELexer);
            myLibraries.checkKeyword("booleano", Color.Orange, 0, IDELexer);
            myLibraries.checkKeyword("caracter", Color.Brown, 0, IDELexer);
            */
        }

        private void IDELexer_TextChanged(object sender, EventArgs e)
        {
            /*// Arithmetical operators
            myLibraries.checkKeyword("+", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("-", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("*", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("/", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("++", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("++", Color.Blue, 0, IDELexer);

            // Relational operators
            myLibraries.checkKeyword(">", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("<", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword(">=", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("<=", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("==", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("!=", Color.Blue, 0, IDELexer);

            // Logical operators
            myLibraries.checkKeyword("||", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("&&", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword("!", Color.Blue, 0, IDELexer);

            // Agrupation signs
            myLibraries.checkKeyword("(", Color.Blue, 0, IDELexer);
            myLibraries.checkKeyword(")", Color.Blue, 0, IDELexer);

            // Agination and end of sentence
            myLibraries.checkKeyword("=", Color.Magenta, 0, IDELexer);
            myLibraries.checkKeyword(";", Color.Magenta, 0, IDELexer);

            // Reserved words in green
            myLibraries.checkKeyword("SI", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("SINO", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("SINO_SI", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("MIENTRAS", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("HACER", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("PARA", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("DESDE", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("HASTA", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("INCREMENTO", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("INICIO", Color.Green, 0, IDELexer);
            myLibraries.checkKeyword("FIN", Color.Green, 0, IDELexer);

            // Reserved words in colors
            myLibraries.checkKeyword("entero", Color.Purple, 0, IDELexer);
            myLibraries.checkKeyword("decimal", Color.LightBlue, 0, IDELexer);
            myLibraries.checkKeyword("cadena", Color.Gray, 0, IDELexer);
            myLibraries.checkKeyword("booleano", Color.Orange, 0, IDELexer);
            myLibraries.checkKeyword("caracter", Color.Brown, 0, IDELexer);*/

            // We need to asign the return of the function to some integer that counts the last colored index
            letterPos = myLibraries.processText3(IDELexer.Text, IDELexer, letterPos);
        }
    }
}
