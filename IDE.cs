using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFP_PROYECTO1_Basic_IDE
{
    class IDE
    {
        private string[] bLueTokens = {"+","-","*","/","++","--",">","<",">=","<=","==","!=","||","&&","!","(",")"};
        private string[] pinkTokens = { "=",";"};
        private string[] greenTokens = {"SI", "SINO","FIN_SI","SINO_SI","EN_CASO","CASO:","OTRO CASO:","SEA:","FIN_CASO", "PARA","FIN_PARA","MIENTRAS","FIN_MIENTRAS","HACER","DESDE","HASTA","INCREMENTO","REINICIAR CICLO","TERMINAR CICLO"};
        private string[] purpleTokens = { "entero" };
        private string[] cyanTokens = { "decimal" };
        private string[] grayTokens = { "cadena" };
        private string[] orangeTokens = { "booleano" };
        private string[] brownTokens = { "caracter" };

        private bool closedString = true;

        private bool closedLongCommentary = true;
        private bool closedShortCommentary = true;

        public string tokenList = "**************************************";

        // !
        public void colorString(int start, int length, Color color, RichTextBox myRichTextBox)
        {
            myRichTextBox.SelectionStart = start;
            myRichTextBox.SelectionLength = length;
            myRichTextBox.SelectionColor = color;
        }

        // !
        public void checkKeyword(string word, Color color, int startIndex, RichTextBox rtb
            )
        {
            if (rtb.Text.Contains(word))
            {
                int index = -1;
                int selectStart = rtb.SelectionStart;

                while ((index = rtb.Text.IndexOf(word, (index + 1))) != -1)
                {
                    rtb.Select((index + startIndex), word.Length);
                    rtb.SelectionColor = color;
                    rtb.Select(selectStart, 0);
                    rtb.SelectionColor = Color.Black;
                }
            }
        }

        // !
        public int checkKeyword2(string word, Color color, int startIndex, RichTextBox rtb
            )
        {
            if (rtb.Text.Contains(word))
            {
                rtb.Select(startIndex, word.Length);
                rtb.SelectionColor = color;
                rtb.Select(startIndex + word.Length, 0);
                rtb.SelectionColor = Color.Black;
            }

            return startIndex + word.Length;
        }

        // !
        public void checkKeyword3(string word, Color color, RichTextBox rtb)
        {
            if (rtb.Text.Contains(word))
            {
                rtb.Select(rtb.Text.IndexOf(word), word.Length);
                rtb.SelectionColor = color;
            }
        }

        public int colorText(string word, int start, Color wordColor, Color finalColor, RichTextBox rtb)
        {
            rtb.Select(start, word.Length);
            rtb.SelectionColor = wordColor;

            rtb.Select(start + word.Length, 0);
            rtb.SelectionColor = finalColor;

            //rtb.SelectionStart = start;
            //rtb.SelectionLength = word.Length;
            //rtb.SelectionColor = color;

            //rtb.Select(start + word.Length, 0);
            //rtb.SelectionColor = Color.Black;

            // We return the position of the next index
            return start + word.Length;
        }

        /*
        public int colorTextFile(string word, int start, Color wordColor, Color finalColor, RichTextBox rtb)
        {
            rtb.Select(start, word.Length);
            rtb.SelectionColor = wordColor;

            rtb.Select(start + word.Length, 0);
            rtb.SelectionColor = finalColor;

            //myRichTextBox.SelectionStart = start;
            //myRichTextBox.SelectionLength = word.Length;
            //myRichTextBox.SelectionColor = color;

            //myRichTextBox.Select(start + word.Length, 0);
            //myRichTextBox.SelectionColor = Color.Black;

            // We return the position of the next index
            return start + word.Length;
        }
        */

        //public int processText(string text, RichTextBox rtb, int start)
        public int processText(RichTextBox rtb)
        {
            string word = "";

            // When open a string
            if (rtb.Text.Length >= 1)
            {
                if (rtb.Text[rtb.Text.Length - 1] == '"')
                {
                    closedString = !closedString;
                }
            }

            // To find the main tokens
            for (int i = (rtb.Text.Length - 1); i >= 0; i--)
            {
                word = Convert.ToString(rtb.Text[i]) + word;

                // { "=",";"}
                for (int k = 0; k < pinkTokens.Length; k++)
                {
                    if (word == pinkTokens[k] && rtb.Text[rtb.Text.Length - 2] != '=' && rtb.Text[rtb.Text.Length - 2] != '!' && rtb.Text[rtb.Text.Length - 2] != '>' && rtb.Text[rtb.Text.Length - 2] != '<')
                    {
                        colorText(word, rtb.Text.Length - pinkTokens[k].Length, Color.Magenta, Color.Black, rtb);
                        tokenList += "\nNuevo Token = " + word; 
                    }
                }

                // {"+","-","*","/","++","--",">","<",">=","<=","==","!=","||","&&","!","(",")"}
                for (int k = 0; k < bLueTokens.Length; k++)
                {
                    if (word == bLueTokens[k] /*&& rtb.Text[rtb.Text.Length - 2] != '/' && rtb.Text[rtb.Text.Length - 1] != '*'*/)
                    {
                        colorText(word, rtb.Text.Length - bLueTokens[k].Length, Color.Blue, Color.Black, rtb);
                        tokenList += "\nNuevo Token = " + word;
                    }
                }

                // { "SI", "SINO","FIN_SI","SINO_SI","EN_CASO","CASO:","OTRO CASO:","SEA:","FIN_CASO", "PARA","FIN_PARA","MIENTRAS","FIN_MIENTRAS","HACER","DESDE","HASTA","INCREMENTO","REINICIAR CICLO","TERMINAR CICLO"}
                for (int k = 0; k < greenTokens.Length; k++)
                {
                    if (word == greenTokens[k])
                    {
                        colorText(word, rtb.Text.Length - greenTokens[k].Length, Color.Green, Color.Black, rtb);
                        tokenList += "\nNuevo Token = " + word;
                    }
                }

                //////////////////////////////////////////////


                if (word == "entero")
                {
                    colorText(word, rtb.Text.Length - 6, Color.Purple, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                }

                if (word == "decimal")
                {
                    colorText(word, rtb.Text.Length - 7, Color.Cyan, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                }

                if (word == "cadena")
                {
                    colorText(word, rtb.Text.Length - 6, Color.Gray, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                }

                if (word == "booleano")
                {
                    colorText(word, rtb.Text.Length - 8, Color.Orange, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                }

                if (word == "caracter")
                {
                    colorText(word, rtb.Text.Length - 8, Color.Brown, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                }

                //////////////////////////////////////////////

                // Testing if a word is decimal before integer
                if (isDecimal(word))
                {
                    colorText(word, rtb.Text.Length - word.Length, Color.Cyan, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                }

                // Testing if a word is integer after decimal
                if (isInteger(word))
                {
                    colorText(word, rtb.Text.Length - word.Length, Color.Purple, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                }

                if (isBoolean(word))
                {
                    colorText(word, rtb.Text.Length - word.Length, Color.Orange, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                    return rtb.Text.Length;
                }

                if ( closedString == true && isString(word))
                {
                    colorText(word, rtb.Text.Length - word.Length, Color.Gray, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;
                    break;
                }

                if (isCharacter(word))
                {
                    colorText(word, rtb.Text.Length - word.Length, Color.Brown, Color.Black, rtb);
                    tokenList += "\nNuevo Token = " + word;

                }

                //////////////////////////////////////////////

                // To paint the short commentary //.........
                if (word == "//")
                {
                    closedShortCommentary = false;
                    colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Red, rtb);
                }
                if (word.Length >= 2)
                {
                    if (closedShortCommentary == false && word[0] == '/' && word[1] == '/' && word[word.Length - 1] == '\n')
                    {
                        colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Black, rtb);
                        closedShortCommentary = true;
                        break;
                    }
                }

                // To paint the long commentary between /*....*/
                if (word == "/*")
                {
                    closedLongCommentary = false;
                    colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Red, rtb);
                }
                if (word.Length >= 4)
                {
                    if (closedLongCommentary == false && word[0] == '/' && word[1] == '*' && word[word.Length - 2] == '*' && word[word.Length - 1] == '/')
                    {
                        colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Black, rtb);
                        closedLongCommentary = true;
                        break;
                    }
                }

                //////////////////////////////////////////////

                // This limits the maximun length of "word"
                if (i == rtb.Text.Length - 500)
                {
                    return rtb.Text.Length;
                }

                // This limits the word to the size of the actual line
                /*if (rtb.Text[i] == '\n')
                {
                    return rtb.Text.Length;
                }*/
            }

            return rtb.Text.Length;
        }

        // !
        public string tokenLog(string text)
        {
            string tokenList = "";
            string word = "";

            for (int i = 0; i < text.Length; i++ )
            {
                word = Convert.ToString(text[i]) + word;

                for (int k = 0; k < bLueTokens.Length; k++)
                {
                    if (word == bLueTokens[k] )
                    {
                        tokenList += "\n" + "Nuevo Token = " + bLueTokens[k];  
                    }
                }
            }

            return tokenList;
        }

        // !
        public void processFile(string text, RichTextBox rtb)
        {
            string word = "";

            for (int i = 0; i < text.Length; i++)
            {
                word = Convert.ToString(text[i]) + word;
                processText(rtb);
            }
        }

        public int cursorColumnPosition (RichTextBox rtb)
        {
            int numberColumn = 0;
            int numberRow = 1;

            for (int i = rtb.Text.Length - 1; i >= 0; i--)
            {
                if (rtb.Text[i] == '\n')
                {
                    numberRow++;
                }
            }

            try
            {
                if (numberRow >= 1 && rtb.Lines[numberRow - 1].Length > 0)
                {
                    numberColumn = rtb.Lines[numberRow - 1].Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*
            for (int i = rtb.Text.Length - 1; i >= 0; i--)
            {
                if (rtb.Text[i] == '\n')
                {
                    numberColumn = word.Length;
                    break;
                }

                word = rtb.Text[i] + word;
            }
            */

            return numberColumn;
        }

        public int cursorRowPosition (RichTextBox rtb)
        {
            int numberRow = 1;

            for (int i = rtb.Text.Length - 1; i >= 0; i--)
            {
                if (rtb.Text[i] == '\n')
                {
                    numberRow++;
                }
            }

            return numberRow;
        }
        public bool isInteger(String token)
        {
            bool isInteger = false;

            for (int i = 0; i < token.Length; i++)
            {
                // To test if the first character is '-' or a number and the next character is a number
                if (i == 0 && token.Length > 1)
                {
                    if (token[i].Equals('-') || token[i].Equals('0') || token[i].Equals('1') || token[i].Equals('2') || token[i].Equals('3') || token[i].Equals('4') || token[i].Equals('5') || token[i].Equals('6') || token[i].Equals('7') || token[i].Equals('8') || token[i].Equals('9'))
                    {
                        if (token[i + 1].Equals('0') || token[i + 1].Equals('1') || token[i + 1].Equals('2') || token[i + 1].Equals('3') || token[i + 1].Equals('4') || token[i + 1].Equals('5') || token[i + 1].Equals('6') || token[i + 1].Equals('7') || token[i + 1].Equals('8') || token[i + 1].Equals('9'))
                        {
                            isInteger = true;
                            continue;
                        }
                        else
                        {
                            isInteger = false;
                            break;
                        }
                    }
                }

                // To test if the characters are only numbers
                if (token[i].Equals('0') || token[i].Equals('1') || token[i].Equals('2') || token[i].Equals('3') || token[i].Equals('4') || token[i].Equals('5') || token[i].Equals('6') || token[i].Equals('7') || token[i].Equals('8') || token[i].Equals('9'))
                {
                    isInteger = true;
                }
                else
                {
                    isInteger = false;
                    break;
                }
            }

            return isInteger;
        }

        public bool isDecimal(string token)
        {
            bool isDecimal = false;
            /*String integerPart = "";
            String fractionalPart = "";
            bool fractionalTurn = false;*/
            bool isFirstTime = false;

            if (token.Length > 1)
            {
                for (int i = 0; i < token.Length; i++)
                {
                    // To test if the first character is '-' or a number and the next character is a number
                    if (i == 0 && token.Length > 1)
                    {
                        if (token[i].Equals('-') || token[i].Equals('0') || token[i].Equals('1') || token[i].Equals('2') || token[i].Equals('3') || token[i].Equals('4') || token[i].Equals('5') || token[i].Equals('6') || token[i].Equals('7') || token[i].Equals('8') || token[i].Equals('9'))
                        {
                            if (token[i + 1].Equals('.') || token[i + 1].Equals('0') || token[i + 1].Equals('1') || token[i + 1].Equals('2') || token[i + 1].Equals('3') || token[i + 1].Equals('4') || token[i + 1].Equals('5') || token[i + 1].Equals('6') || token[i + 1].Equals('7') || token[i + 1].Equals('8') || token[i + 1].Equals('9'))
                            {
                                isDecimal = true;
                                continue;
                            }
                            else
                            {
                                isDecimal = false;
                                break;
                            }
                        }
                    }

                    // To test if the character meet a Decimal pattern
                    if (token[i].Equals('.') || token[i].Equals('0') || token[i].Equals('1') || token[i].Equals('2') || token[i].Equals('3') || token[i].Equals('4') || token[i].Equals('5') || token[i].Equals('6') || token[i].Equals('7') || token[i].Equals('8') || token[i].Equals('9'))
                    {
                        if (token[i].Equals('.') && i > 0)
                        {
                            //fractionalTurn = true;
                            isFirstTime = !isFirstTime;  // To ensure we have only one point in expression to be decimal
                            if (isFirstTime == false)
                            {
                                isDecimal = false;
                                break;
                            }
                        }
                        else
                        {
                            isDecimal = true;
                        }
                    }
                    else
                    {
                        isDecimal = false;
                        return isDecimal;
                    }
                }
            }

            return isDecimal;
        }

        public bool isBoolean(string token)
        {
            bool isBoolean = false;

            if (token.Length > 1)
            {
                if (token == "verdadero" || token == "falso")
                {
                    isBoolean = true;
                    return isBoolean;
                }
            }

            return isBoolean;
        }

        public bool isString(string token)
        {
            bool isString = false;

            if (token.Length > 1)
            {
                if (closedString == true && token[0] == '"' && token[token.Length - 1] == '"')
                {
                    isString = true;
                    return isString;
                }
            }

            return isString;
        }

        public bool isCharacter(string token)
        {
            bool isCharacter = false;

            if (token.Length == 3)
            {
                if (token[0] == '\'' && token[token.Length - 1] == '\'')
                {
                    isCharacter = true;
                    return isCharacter;
                }
            }

            return isCharacter;
        }

        public string[] createFileProjectGTP(RichTextBox rtb)
        {
            // fileProject[0] is the project's file and fileProject[1] is the IDE's file
            string[] fileProject = new string[2];

            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                // To show some title
                saveFile.Title = "Guardar Archivo de IDE";
                // set a default file name
                saveFile.FileName = "";
                // set filters - this can be done in properties as well
                saveFile.Filter = "Archivos GT (*.gt)|*.gt|Todos los archivos (*.*)|*.*";
                // Directory to start
                saveFile.InitialDirectory = ".";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    //using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    //sw.WriteLine("Hello World!");
                    rtb.SaveFile(saveFile.FileName);
                    fileProject[1] = saveFile.FileName;
                }

                SaveFileDialog saveFileProject = new SaveFileDialog();
                // To show some title
                saveFileProject.Title = "Crear Archivo de Proyecto";
                // set a default file name
                saveFileProject.FileName = "";
                // set filters - this can be done in properties as well
                saveFileProject.Filter = "Archivos GTP (*.gtP)|*.gtP|Todos los archivos (*.*)|*.*";
                // Directory to start
                saveFileProject.InitialDirectory = ".";

                if (saveFileProject.ShowDialog() == DialogResult.OK)
                {
                    rtb.Text = saveFile.FileName;
                    rtb.SaveFile(saveFileProject.FileName);
                    fileProject[0] = saveFileProject.FileName;
                    rtb.Clear();
                }

                // Loads the project and IDE files
                rtb.LoadFile(fileProject[0]);
                rtb.LoadFile(fileProject[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return fileProject;
        }

        public string[] openFileProjectGTP(RichTextBox rtb)
        {
            // fileProject[0] is the project's file and fileProject[1] is the IDE's file
            string[] fileProject = new string[2];

            try
            {
                OpenFileDialog openFileProject = new OpenFileDialog();
                // To show some title
                openFileProject.Title = "Abrir Archivo de Proyecto";
                // set a default file name
                openFileProject.FileName = "";
                // set filters - this can be done in properties as well
                openFileProject.Filter = "Archivos GTP (*.gtP)|*.gtP|Todos los archivos (*.*)|*.*";
                // Directory to start
                openFileProject.InitialDirectory = ".";

                if (openFileProject.ShowDialog() == DialogResult.OK)
                {
                    rtb.LoadFile(openFileProject.FileName);
                    fileProject[0] = openFileProject.FileName;
                    rtb.LoadFile(rtb.Text);
                    fileProject[1] = rtb.Text;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return fileProject;
        }

        public void saveFileProjectGTP(RichTextBox rtb, string fileProject, string fileIDE)
        {
            // fileProject[0] is the project's file and fileProject[1] is the IDE's file

            try
            {
                rtb.SaveFile(fileIDE);
                rtb.LoadFile(fileProject);
                rtb.SaveFile(fileProject);
                rtb.LoadFile(fileIDE);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void saveFileIDEGT(RichTextBox rtb)
        {
            try
            {
                SaveFileDialog saveFileProject = new SaveFileDialog();
                // To show some title
                saveFileProject.Title = "Guardar Archivo de IDE";
                // set a default file name
                saveFileProject.FileName = "";
                // set filters - this can be done in properties as well
                saveFileProject.Filter = "Archivos GT (*.gt)|*.gt|Todos los archivos (*.*)|*.*";
                // Directory to start
                saveFileProject.InitialDirectory = ".";

                if (saveFileProject.ShowDialog() == DialogResult.OK)
                {
                    //using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    //sw.WriteLine("Hello World!");
                    rtb.SaveFile(saveFileProject.FileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void openFileGT(RichTextBox rtb)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                // To show some title
                openFile.Title = "Abrir Archivo de IDE";
                // set a default file name
                openFile.FileName = "";
                // set filters - this can be done in properties as well
                openFile.Filter = "Archivos GT (*.gt)|*.gt|Todos los archivos (*.*)|*.*";
                // Directory to start
                openFile.InitialDirectory = ".";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    rtb.LoadFile(openFile.FileName);
                    //MessageBox.Show(openFile.FileName.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void saveFileGT(RichTextBox rtb)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                // To show some title
                saveFile.Title = "Guardar Archivo de IDE";
                // set a default file name
                saveFile.FileName = "";
                // set filters - this can be done in properties as well
                saveFile.Filter = "Archivos GT (*.gt)|*.gt|Todos los archivos (*.*)|*.*";
                // Directory to start
                saveFile.InitialDirectory = ".";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    //using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    //sw.WriteLine("Hello World!");
                    rtb.SaveFile(saveFile.FileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void openFileLogGTE(RichTextBox rtb)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                // To show some title
                openFile.Title = "Abrir Archivo de Log";
                // set a default file name
                openFile.FileName = "";
                // set filters - this can be done in properties as well
                openFile.Filter = "Archivos GTE (*.gtE)|*.gtE|Todos los archivos (*.*)|*.*";
                // Directory to start
                openFile.InitialDirectory = ".";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    rtb.LoadFile(openFile.FileName);
                    //MessageBox.Show(openFile.FileName.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void saveFileLogGTE(RichTextBox rtb)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                // To show some title
                saveFile.Title = "Guardar Archivo de Log";
                // set a default file name
                saveFile.FileName = "";
                // set filters - this can be done in properties as well
                saveFile.Filter = "Archivos GTE (*.gtE)|*.gtE|Todos los archivos (*.*)|*.*";
                // Directory to start
                saveFile.InitialDirectory = ".";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    //using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    //sw.WriteLine("Hello World!");
                    rtb.SaveFile(saveFile.FileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
