using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFP_PROYECTO1_Basic_IDE
{
    public partial class Form1 : Form
    {
        private IDE myIDE = new IDE();

        // fileProject[0] is the project's file and fileProject[1] is the myIDE's file
        private string[] fileProject = new string[2];

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

        private void myIDELexer_KeyPress(object sender, KeyPressEventArgs e)
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
        myIDE.processFile(myIDELexer.Text, myIDELexer);

        RowColumn.Text = myIDE.cursorRowPosition(myIDELexer) + "," + myIDE.cursorColumnPosition(myIDELexer);
        */

        private void IDELexer_TextChanged(object sender, EventArgs e)
        {
            // We need to asign the return of the function to some integer that counts the last colored index
            letterPos = myIDE.processText(IDELexer);

            //myIDE.processFile(myIDELexer.Text, myIDELexer);

            // To see the row and column
            RowColumn.Text = myIDE.cursorRowPosition(IDELexer) + "," + myIDE.cursorColumnPosition(IDELexer);

            // To log the tokens found
            Log.Text = myIDE.tokenList;
        }

        //********************************************************
        //********************************************************
        // Menu

        private void crearProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileProject = myIDE.createFileProjectGTP(IDELexer);
        }

        private void abrirProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileProject = myIDE.openFileProjectGTP(IDELexer);
        }

        private void guardarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myIDE.saveFileProjectGTP(IDELexer, fileProject[0], fileProject[1]);
            Log.AppendText("\nProyecto guardado exitosamente");
        }

        private void cerrarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDELexer.Clear();
            Log.Clear();
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myIDE.openFileGT(IDELexer);
        }

        private void guardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myIDE.saveFileGT(IDELexer);
            Log.AppendText("\nArchivo guardado exitosamente");
        }

        private void cerrarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDELexer.Clear();
            Log.Clear();
        }

        private void crearArchivoLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myIDE.saveFileLogGTE(Log);
        }

        private void abrirArchivoLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myIDE.openFileLogGTE(IDELexer);
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //********************************************************
        //********************************************************

        private void buttonReset_Click(object sender, EventArgs e)
        {

        }


    }
}
