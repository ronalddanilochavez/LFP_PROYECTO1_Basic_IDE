using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFP_PROYECTO1_Basic_IDE
{
    class MyLibraries
    {
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

        public void colorText(string word, int start, Color color, RichTextBox myRichTextBox)
        {
            //myRichTextBox.Select(start, word.Length);
            //myRichTextBox.SelectionColor = color;
            myRichTextBox.SelectionStart = start;
            myRichTextBox.SelectionLength = word.Length;
            myRichTextBox.SelectionColor = color;
            //myRichTextBox.Select(start + word.Length, 0);
            //myRichTextBox.SelectionColor = Color.Black;
        }

        public void processText(string text, RichTextBox myRichTextBox)
        {
            int i = 0;

            while (i < text.Length)
            {
                // Arithmentical operators
                if (text[i] == '+')
                {
                    colorText(Convert.ToString(text[i]), i, Color.Blue, myRichTextBox);
                }
                if (text[i] == '-')
                {
                    colorText(Convert.ToString(text[i]), i, Color.Blue, myRichTextBox);
                }
                if (text[i] == '*')
                {
                    colorText(Convert.ToString(text[i]), i, Color.Blue, myRichTextBox);
                }
                if (text[i] == '/')
                {
                    colorText(Convert.ToString(text[i]), i, Color.Blue, myRichTextBox);
                }

                //myRichTextBox.DeselectAll();
                myRichTextBox.Select(i + 1, 1);
                myRichTextBox.SelectionColor = Color.Black;

                i++;
            }
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
