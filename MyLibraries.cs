using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFP_PROYECTO1_Basic_IDE
{
    class MyLibraries
    {
        private string[] bLueTokens = {"+","-","*","/","++","--",">","<",">=","<=","==","!=","||","&&","!","(",")"};
        private string[] pinkTokens = { "=",";"};
        private string[] greenTokens = { "SI", "SINO","FIN_SI","SINO_SI","EN_CASO","CASO:","OTRO CASO:","SEA:","FIN_CASO", "PARA","FIN_PARA","MIENTRAS","FIN_MIENTRAS","HACER","DESDE","HASTA","INCREMENTO","REINICIAR CILO","TERMINAR CICLO"};
        private string[] purpleTokens = { "entero" };
        private string[] cyanTokens = { "decimal" };
        private string[] grayTokens = { "cadena" };
        private string[] orangeTokens = { "booleano" };
        private string[] brownTokens = { "caracter" };

        public void processString(string stringLine)
        {

        }

        public void colorString(int start, int length, Color color, RichTextBox myRichTextBox)
        {
            myRichTextBox.SelectionStart = start;
            myRichTextBox.SelectionLength = length;
            myRichTextBox.SelectionColor = color;
        }

        public void checkKeyword(string word, Color color, int startIndex, RichTextBox myRichTextBox)
        {
            if (myRichTextBox.Text.Contains(word))
            {
                int index = -1;
                int selectStart = myRichTextBox.SelectionStart;

                while ((index = myRichTextBox.Text.IndexOf(word, (index + 1))) != -1)
                {
                    myRichTextBox.Select((index + startIndex), word.Length);
                    myRichTextBox.SelectionColor = color;
                    myRichTextBox.Select(selectStart, 0);
                    myRichTextBox.SelectionColor = Color.Black;
                }
            }
        }

        public int checkKeyword2(string word, Color color, int startIndex, RichTextBox myRichTextBox)
        {
            if (myRichTextBox.Text.Contains(word))
            {
                int index = -1;
                int selectStart = myRichTextBox.SelectionStart;

                while ((index = myRichTextBox.Text.IndexOf(word, (index + 1))) != -1)
                {
                    myRichTextBox.Select((index + startIndex), word.Length);
                    myRichTextBox.SelectionColor = color;
                    myRichTextBox.Select(selectStart, 0);
                    myRichTextBox.SelectionColor = Color.Black;
                }
            }

            return startIndex + word.Length;
        }

        public int colorText(string word, int start, Color color, RichTextBox myRichTextBox)
        {
            myRichTextBox.Select(start, word.Length);
            myRichTextBox.SelectionColor = color;

            myRichTextBox.Select(start + word.Length, 0);
            myRichTextBox.SelectionColor = Color.Black;

            //myRichTextBox.SelectionStart = start;
            //myRichTextBox.SelectionLength = word.Length;
            //myRichTextBox.SelectionColor = color;

            //myRichTextBox.Select(start + word.Length, 0);
            //myRichTextBox.SelectionColor = Color.Black;

            // We return the position of the next index
            return start + word.Length;
        }

        public int processText(string text, RichTextBox rtb, int start)
        {
            int i = start;

            while (i < text.Length)
            {
                // Arithmetical operators
                if (text[i] == '+')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '-')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '*')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '/')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }

                // Arithmetical operators
                else if (text[i] == '>')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '<')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '=')
                {
                    if (i - 1 >= 0)
                    {
                        if (text[i - 1] == '=')
                        {
                            return colorText(Convert.ToString(text[i - 1] + text[i]), i - 1, Color.Blue, rtb);
                        }
                    }

                    return colorText(Convert.ToString(text[i]), i, Color.Magenta, rtb);
                }

                // Logic operators
                else if (text[i] == '!')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '|')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '&')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }

                // Agrupation signs

                else if (text[i] == '(')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == ')')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '{')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }
                else if (text[i] == '}')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }

                // End of sentence
                else if (text[i] == ';')
                {
                    return colorText(Convert.ToString(text[i]), i, Color.Blue, rtb);
                }



                //myRichTextBox.Select(i + 1, 1);
                //myRichTextBox.SelectionColor = Color.Black;

                i++;
            }

            return start;
        }

        public int processText2(string text, RichTextBox rtb, int start)
        {
            int i = rtb.Text.Length - 1;
            string word = "";

            while (i >= start)
            {
                word = Convert.ToString(rtb.Text[i]) + word;

                for (int k = 0; k < pinkTokens.Length; k++)
                {
                    if (word == pinkTokens[k] && rtb.Text[rtb.Text.Length - 2] != '=')
                    {
                        colorText(word, rtb.Text.Length - pinkTokens[k].Length, Color.Magenta, rtb);
                        return text.Length;
                    }
                }

                for (int k = 0; k < bLueTokens.Length; k++)
                {
                    if (word == bLueTokens[k])
                    {
                        colorText(word, rtb.Text.Length - bLueTokens[k].Length, Color.Blue, rtb);
                        return text.Length;
                    }
                }

                i--;
            }

            return start;
        }

        public int processText3(string text, RichTextBox rtb, int start)
        {
            string word = ""; 

            for (int i = (rtb.Text.Length - 1); i >= 0; i--)
            {
                word = Convert.ToString(rtb.Text[i]) + word;

                /*if (rtb.Text[rtb.Text.Length - 1] == '+' || rtb.Text[rtb.Text.Length - 1] == '-' || rtb.Text[rtb.Text.Length - 1] == '*' || rtb.Text[rtb.Text.Length - 1] == '/' || rtb.Text[rtb.Text.Length - 1] == '<' || rtb.Text[rtb.Text.Length - 1] == '>' || rtb.Text[rtb.Text.Length - 1] == '!' || rtb.Text[rtb.Text.Length - 1] == '(' || rtb.Text[rtb.Text.Length - 1] == ')')
                {
                    colorText(, rtb.Text.Length - bLueTokens[k].Length, Color.Blue, rtb);
                }*/

                for (int k = 0; k < pinkTokens.Length; k++)
                {
                    if (word == pinkTokens[k] && rtb.Text[rtb.Text.Length - 2] != '=' && rtb.Text[rtb.Text.Length - 2] != '!' && rtb.Text[rtb.Text.Length - 2] != '>' && rtb.Text[rtb.Text.Length - 2] != '<')
                    {
                        colorText(word, rtb.Text.Length - pinkTokens[k].Length, Color.Magenta, rtb);
                        return text.Length;
                    }
                }

                for (int k = 0; k < bLueTokens.Length; k++)
                {
                    if (word == bLueTokens[k])
                    {
                        colorText(word, rtb.Text.Length - bLueTokens[k].Length, Color.Blue, rtb);
                        return text.Length;
                    }
                }

                for (int k = 0; k < greenTokens.Length; k++)
                {
                    if (word == greenTokens[k])
                    {
                        colorText(word, rtb.Text.Length - greenTokens[k].Length, Color.Green, rtb);
                        return text.Length;
                    }
                }
            }

            return start;
        }

        public bool isInteger(String token)
        {
            bool isInteger = false;

            for (int i = 0; i < token.Length; i++)
            {
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
    }
}
