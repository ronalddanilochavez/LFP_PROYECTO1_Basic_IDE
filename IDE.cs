using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
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
        
        // 1 character
        private string[] tokensPink1 = { "=", ";" };
        private string[] tokensBlue1 = { "+", "-", "*", "/", ">", "<", "!", "(", ")" };
        // 2 characters
        private string[] tokensBlue2 = { "++", "--", ">=", "<=", "==", "!=", "||", "&&" };
        private string[] tokensGreen2 = { "SI" };
        // 4 characters
        private string[] tokensGreen4 = { "SINO", "SEA:", "PARA" };
        // 5 characters
        private string[] tokensGreen5 = { "CASO:", "HACER", "DESDE", "HASTA" };
        // 6 characters
        private string[] tokensGreen6 = { "FIN_SI" };
        private string[] tokensPurple6 = { "entero" };
        private string[] tokensGray6 = { "cadena" };
        // 7 characters
        private string[] tokensGreen7 = { "SINO_SI", "EN_CASO" };
        private string[] tokensCyan7 = { "decimal" };
        // 8 characters
        private string[] tokensGreen8 = { "FIN_CASO", "FIN_PARA", "MIENTRAS",  };
        private string[] tokensOrange8 = { "booleano" };
        private string[] tokensBrown8 = { "caracter" };
        // 10 characters
        private string[] tokensGreen10 = { "OTRO CASO:", "INCREMENTO" };
        // 12 characters
        private string[] tokensGreen12 = { "FIN_MIENTRAS"};
        // 14 characters
        private string[] tokensGreen14 = { "TERMINAR CICLO" };
        // 15 characters
        private string[] tokensGreen15 = { "REINICIAR CICLO" };


        private bool closedString = true;
        private int stringStart = 0;

        private bool closedLongCommentary = true;
        private bool closedShortCommentary = true;

        public string tokenList = "********Think Outside the BOX********";

        private int stringLength = 0;
        private bool isStringIncreasing = false;
        public int row = 1;
        public int column = 0;
        private int lineFirstIndex = 0;
        private int lineLastIndex = 0;

        // !
        public void colorString(int start, int length, Color color, RichTextBox myRichTextBox)
        {
            myRichTextBox.SelectionStart = start;
            myRichTextBox.SelectionLength = length;
            myRichTextBox.SelectionColor = color;
        }

        // !*
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

        // !*
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

        // !*
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

            // To know if the string is increasing or decreasing
            if (rtb.Text.Length > stringLength)
            {
                isStringIncreasing = true;
                stringLength = rtb.Text.Length;
            }
            else
            {
                isStringIncreasing = false;
                stringLength = rtb.Text.Length;
            }

            // To know the number of rows where we are
            try
            {
                if (rtb.Text[rtb.Text.Length - 1] == '\n' && isStringIncreasing == true)
                {
                    row++;
                }
                if (rtb.Text[rtb.Text.Length - 1] == '\n' && isStringIncreasing == false)
                {
                    row--;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // To know the number of columns where we are
            try
            {
                lineLastIndex = rtb.Text.Length - 1;
                for (int i = rtb.Text.Length - 1; i > 0; i--)
                {
                    if (rtb.Text[i] == '\n')
                    {
                        lineFirstIndex = i + 1;
                        break;
                    }
                }
                column = lineLastIndex - lineFirstIndex + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // When open a string
            if (rtb.Text.Length >= 1)
            {
                if (rtb.Text[rtb.Text.Length - 1] == '"')
                {
                    closedString = !closedString;
                }
            }

            string token = "";

            //****************
            // To find the main tokens
            for (int i = (rtb.Text.Length - 1); i >= 0; i--)
            {
                word = Convert.ToString(rtb.Text[i]) + word;

                //////////////////////////////////////////////

                if (closedShortCommentary == true && closedLongCommentary == true)
                {
                    // To color the defined tokens

                    // 1 character length
                    if (word.Length == 1)
                    {
                        for (int k = 0; k < tokensPink1.Length; k++)
                        {
                            if (word == tokensPink1[k])
                            {
                                colorText(word, rtb.Text.Length - tokensPink1[k].Length, Color.Magenta, Color.Black, rtb);
                            }
                        }

                        for (int k = 0; k < tokensBlue1.Length; k++)
                        {
                            if (word == tokensBlue1[k])
                            {
                                colorText(word, rtb.Text.Length - tokensBlue1[k].Length, Color.Blue, Color.Black, rtb);
                            }
                        }
                    }

                    // 2 characters length
                    if (word.Length == 2)
                    {
                        for (int k = 0; k < tokensBlue2.Length; k++)
                        {
                            if (word == tokensBlue2[k])
                            {
                                colorText(word, rtb.Text.Length - tokensBlue2[k].Length, Color.Blue, Color.Black, rtb);
                            }
                        }

                        for (int k = 0; k < tokensGreen2.Length; k++)
                        {
                            if (word == tokensGreen2[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen2[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }
                    }

                    // 4 characters length
                    if (word.Length == 4)
                    {
                        for (int k = 0; k < tokensGreen4.Length; k++)
                        {
                            if (word == tokensGreen4[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen4[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }
                    }

                    // 5 characters length
                    if (word.Length == 5)
                    {
                        for (int k = 0; k < tokensGreen5.Length; k++)
                        {
                            if (word == tokensGreen5[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen5[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }
                    }

                    // 6 characters length
                    if (word.Length == 6)
                    {
                        for (int k = 0; k < tokensGreen6.Length; k++)
                        {
                            if (word == tokensGreen6[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen6[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }

                        for (int k = 0; k < tokensPurple6.Length; k++)
                        {
                            if (word == tokensPurple6[k])
                            {
                                colorText(word, rtb.Text.Length - tokensPurple6[k].Length, Color.Purple, Color.Black, rtb);
                            }
                        }

                        for (int k = 0; k < tokensGray6.Length; k++)
                        {
                            if (word == tokensGray6[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGray6[k].Length, Color.Gray, Color.Black, rtb);
                            }
                        }
                    }

                    // 7 characters length
                    if (word.Length == 7)
                    {
                        for (int k = 0; k < tokensGreen7.Length; k++)
                        {
                            if (word == tokensGreen7[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen7[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }

                        for (int k = 0; k < tokensCyan7.Length; k++)
                        {
                            if (word == tokensCyan7[k])
                            {
                                colorText(word, rtb.Text.Length - tokensCyan7[k].Length, Color.Cyan, Color.Black, rtb);
                            }
                        }
                    }

                    // 8 characters length
                    if (word.Length == 8)
                    {
                        for (int k = 0; k < tokensGreen8.Length; k++)
                        {
                            if (word == tokensGreen8[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen8[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }

                        for (int k = 0; k < tokensOrange8.Length; k++)
                        {
                            if (word == tokensOrange8[k])
                            {
                                colorText(word, rtb.Text.Length - tokensOrange8[k].Length, Color.Orange, Color.Black, rtb);
                            }
                        }

                        for (int k = 0; k < tokensBrown8.Length; k++)
                        {
                            if (word == tokensBrown8[k])
                            {
                                colorText(word, rtb.Text.Length - tokensBrown8[k].Length, Color.Orange, Color.Black, rtb);
                            }
                        }
                    }

                    // 10 characters length
                    if (word.Length == 10)
                    {
                        for (int k = 0; k < tokensGreen10.Length; k++)
                        {
                            if (word == tokensGreen10[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen10[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }
                    }

                    // 12 characters length
                    if (word.Length == 12)
                    {
                        for (int k = 0; k < tokensGreen12.Length; k++)
                        {
                            if (word == tokensGreen12[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen12[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }
                    }

                    // 14 characters length
                    if (word.Length == 14)
                    {
                        for (int k = 0; k < tokensGreen14.Length; k++)
                        {
                            if (word == tokensGreen14[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen14[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }
                    }

                    // 15 characters length
                    if (word.Length == 15)
                    {
                        for (int k = 0; k < tokensGreen15.Length; k++)
                        {
                            if (word == tokensGreen15[k])
                            {
                                colorText(word, rtb.Text.Length - tokensGreen15[k].Length, Color.Green, Color.Black, rtb);
                            }
                        }
                    }


                    //////////////////////////////////////////////

                    // Testing if a word is boolean
                    if (isBoolean(word))
                    {
                        colorText(word, rtb.Text.Length - word.Length, Color.Orange, Color.Black, rtb);
                        //tokenList += "\nNuevo Token = " + word;
                        //token = word;
                        break;
                    }

                    // Testing if a word is string
                    if (closedString == false /*&& isString(word)*/)
                    {
                        colorText(word, rtb.Text.Length - word.Length, Color.Gray, Color.Black, rtb);
                        //tokenList += "\nNuevo Token = " + word;
                        //token = word;
                        break;
                    }

                    // Testing if a word is character
                    if (isCharacter(word))
                    {
                        colorText(word, rtb.Text.Length - word.Length, Color.Brown, Color.Black, rtb);
                        //tokenList += "\nNuevo Token = " + word;
                        //token = word;
                    }

                    // Testing if a word is decimal before integer
                    if (isDecimal(word))
                    {
                        colorText(word, rtb.Text.Length - word.Length, Color.Cyan, Color.Black, rtb);
                        //tokenList += "\nNuevo Token = " + word;
                        //token = word;
                    }

                    // Testing if a word is integer after decimal
                    if (isInteger(word))
                    {
                        colorText(word, rtb.Text.Length - word.Length, Color.Purple, Color.Black, rtb);
                        //tokenList += "\nNuevo Token = " + word;
                        //token = word;
                    }

                }

                //////////////////////////////////////////////

                // To paint the short commentary //.........
                if (word == "//")
                {
                    closedShortCommentary = false;
                    colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Red, rtb);
                }
                if (word.Length >= 2 && closedShortCommentary == false && word[0] == '/' && word[1] == '/' && word[word.Length - 1] == '\n')
                {
                    colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Black, rtb);
                    closedShortCommentary = true;
                    break;
                }

                // To paint the long commentary between /*....*/
                if (word == "/*")
                {
                    closedLongCommentary = false;
                    colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Red, rtb);
                    break;
                }
                if (closedLongCommentary == false && word == "*/")
                {

                    closedLongCommentary = true;
                    colorText(word, rtb.Text.Length - word.Length, Color.Red, Color.Black, rtb);
                    break;
                }

                //////////////////////////////////////////////

                // This limits the maximun length of "word"
                if (i == lineFirstIndex)
                {
                    break;
                }

                // This limits the word to the size of the actual line
                /*if (rtb.Text[i] == '\n')
                {
                    return rtb.Text.Length;
                }*/
            }

            return rtb.Text.Length;
        }

        public string compile(string text)
        {
            string tokenLog = "********Think Outside the BOX********";
            string line = "";
            string word = "";
            string tempText = "";
            string token = "";
            string tokenTemp = "";
            int start = 0;
            int wordLength = 0;
            bool isLongComment = false;
            bool isShortComment = false;
            bool identifierExpected = false;
            List<string> identifiers = new List<string>();
            bool identifierNotValid = false;

            // To process the commentaries we cut off the characters enclosed inside it and we only left the '\n' characters
            for (int i = 0; i < text.Length; i++)
            {
                if (i + 1 < text.Length )
                {
                    if (isLongComment == false && text[i] == '/' && text[i + 1] == '/')
                    {
                        isShortComment = true;
                    }

                    if (isShortComment == false && text[i] == '/' && text[i + 1] == '*')
                    {
                        isLongComment = true;
                    }

                    if (isLongComment == true && text[i] == '*' && text[i + 1] == '/')
                    {
                        isLongComment = false;

                        if (i + 2 < text.Length)
                        {
                            i += 2;
                        }
                        else
                        {
                            // Here the text ends if i + 2 == text.length and we dont need the reading of */
                            break;
                        }
                    }
                }

                if (isShortComment == false && isLongComment == false)
                {
                    tempText += Convert.ToString(text[i]);
                    continue;
                }

                if (text[i] == '\n')
                {
                    isShortComment = false;
                    tempText += Convert.ToString(text[i]);
                    continue;
                }
            }

            for (int i = 0; i < tempText.Length; i++)
            {
                // We find a line to work with
                if (tempText[i] != '\n' && i != tempText.Length - 1)
                {
                    line += Convert.ToString(tempText[i]);
                }
                else
                {
                    // If we are in text.Length - 1 index
                    if (i == tempText.Length - 1)
                    {
                        line += Convert.ToString(tempText[i]);
                    }

                    start = 0;
                    identifierExpected = false;

                    while (start < line.Length)
                    {
                        word = "";
                        token = "";

                        for (int j = start; j < line.Length; j++)
                        {
                            if (identifierExpected == false)
                            {
                                word += Convert.ToString(line[j]);

                                // Defined tokens
                                // Needed, because compareToDefinedTokens erases tokenTemp if is not a defined token
                                if ((tokenTemp = compareToDefinedTokens(word)).Length > 0)
                                {
                                    token = tokenTemp;
                                    wordLength = token.Length;
                                }
                                if (token == "booleano" || token == "cadena" || token == "caracter" || token == "decimal" || token == "entero")
                                {
                                    identifierExpected = true;
                                    break;
                                }

                                // To test if is a boolean type
                                if (isBoolean(word))
                                {
                                    token = word;
                                    wordLength = token.Length;
                                }
                                // To test if is a string type
                                if (isString(word))
                                {
                                    token = word;
                                    wordLength = token.Length;
                                }
                                // To test if is a character type
                                if (isCharacter(word))
                                {
                                    token = word;
                                    wordLength = token.Length;
                                }
                                // To test if is a decimal type, we need to test decimal before integer
                                if (isDecimal(word))
                                {
                                    token = word;
                                    wordLength = token.Length;
                                }
                                // To test if is an integer type
                                if (isInteger(word))
                                {
                                    token = word;
                                    wordLength = token.Length;
                                }

                                // To test if it is an identifier
                                for (int k = 0; k < identifiers.Count; k++)
                                {
                                    if (word.Length == identifiers[k].Length)
                                    {
                                        if (word == identifiers[k])
                                        {
                                            token = word;
                                            wordLength = token.Length;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                word = "";
                                for (int k = start; k < line.Length; k++)
                                {
                                    if (line[k] != '=' && line[k] != ';')
                                    {
                                        word += Convert.ToString(line[k]);
                                        wordLength = word.Length;
                                        if (k == line.Length - 1)
                                        {
                                            // Nedeed if the line ends without a '=' or ';'
                                            tokenLog += "\nIdentificador NO Válido";
                                            identifierNotValid = true;
                                        }
                                    }
                                    else
                                    {
                                        wordLength = word.Length;
                                        word = trimWord(word);
                                        if (isIdentifier(word))
                                        {
                                            identifiers.Add(word);
                                            token = word;
                                            wordLength = word.Length;
                                        }
                                        else
                                        {
                                            tokenLog += "\nIdentificador NO Válido";
                                            identifierNotValid = true;
                                        }

                                        break;
                                    }
                                }

                                identifierExpected = false;
                                break;
                            }
                        }

                        if (token.Length > 0 || identifierNotValid == true)
                        {
                            start += wordLength;
                            if (identifierNotValid == true)
                            {
                                identifierNotValid = false;
                            }
                            else
                            {
                                tokenLog += "\nToken = \"" + token + "\"";
                            }
                        }
                        else
                        {
                            start++;
                        }
                    }

                    line = "";
                }
            }

            return tokenLog;
        }

        private string trimWord(string word)
        {
            string temp1 = "";
            string temp2 = "";

            if (word.Length > 0)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        for (int j = i; j < word.Length; j++)
                        {
                            temp1 += Convert.ToString(word[j]);
                        }
                        break;
                    }
                }

                for (int i = temp1.Length - 1; i >= 0; i--)
                {
                    if (temp1[i] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j <= i; j++)
                        {
                            temp2 += Convert.ToString(temp1[j]);
                        }
                        break;
                    }
                }
            }

            return temp2;
        }

        private string compareToDefinedTokens(string word)
        {
            string token = "";

            // 1 character length
            if (word.Length == 1)
            {
                for (int k = 0; k < tokensPink1.Length; k++)
                {
                    if (word == tokensPink1[k])
                    {
                        token = word;
                    }
                }

                for (int k = 0; k < tokensBlue1.Length; k++)
                {
                    if (word == tokensBlue1[k])
                    {
                        token = word;
                    }
                }
            }

            // 2 characters length
            if (word.Length == 2)
            {
                for (int k = 0; k < tokensBlue2.Length; k++)
                {
                    if (word == tokensBlue2[k])
                    {
                        token = word;
                    }
                }

                for (int k = 0; k < tokensGreen2.Length; k++)
                {
                    if (word == tokensGreen2[k])
                    {
                        token = word;
                    }
                }
            }

            // 4 characters length
            if (word.Length == 4)
            {
                for (int k = 0; k < tokensGreen4.Length; k++)
                {
                    if (word == tokensGreen4[k])
                    {
                        token = word;
                    }
                }
            }

            // 5 characters length
            if (word.Length == 5)
            {
                for (int k = 0; k < tokensGreen5.Length; k++)
                {
                    if (word == tokensGreen5[k])
                    {
                        token = word;
                    }
                }
            }

            // 6 characters length
            if (word.Length == 6)
            {
                for (int k = 0; k < tokensGreen6.Length; k++)
                {
                    if (word == tokensGreen6[k])
                    {
                        token = word;
                    }
                }

                for (int k = 0; k < tokensPurple6.Length; k++)
                {
                    if (word == tokensPurple6[k])
                    {
                        token = word;
                    }
                }

                for (int k = 0; k < tokensGray6.Length; k++)
                {
                    if (word == tokensGray6[k])
                    {
                        token = word;
                    }
                }
            }

            // 7 characters length
            if (word.Length == 7)
            {
                for (int k = 0; k < tokensGreen7.Length; k++)
                {
                    if (word == tokensGreen7[k])
                    {
                        token = word;
                    }
                }

                for (int k = 0; k < tokensCyan7.Length; k++)
                {
                    if (word == tokensCyan7[k])
                    {
                        token = word;
                    }
                }
            }

            // 8 characters length
            if (word.Length == 8)
            {
                for (int k = 0; k < tokensGreen8.Length; k++)
                {
                    if (word == tokensGreen8[k])
                    {
                        token = word;
                    }
                }

                for (int k = 0; k < tokensOrange8.Length; k++)
                {
                    if (word == tokensOrange8[k])
                    {
                        token = word;
                    }
                }

                for (int k = 0; k < tokensBrown8.Length; k++)
                {
                    if (word == tokensBrown8[k])
                    {
                        token = word;
                    }
                }
            }

            // 10 characters length
            if (word.Length == 10)
            {
                for (int k = 0; k < tokensGreen10.Length; k++)
                {
                    if (word == tokensGreen10[k])
                    {
                        token = word;
                    }
                }
            }

            // 12 characters length
            if (word.Length == 12)
            {
                for (int k = 0; k < tokensGreen12.Length; k++)
                {
                    if (word == tokensGreen12[k])
                    {
                        token = word;
                    }
                }
            }

            // 14 characters length
            if (word.Length == 14)
            {
                for (int k = 0; k < tokensGreen14.Length; k++)
                {
                    if (word == tokensGreen14[k])
                    {
                        token = word;
                    }
                }
            }

            // 15 characters length
            if (word.Length == 15)
            {
                for (int k = 0; k < tokensGreen15.Length; k++)
                {
                    if (word == tokensGreen15[k])
                    {
                        token = word;
                    }
                }
            }

            return token;
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

        public bool isInteger(string token)
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

            if (token[0] == '"' && token[token.Length - 1] == '"' && (token.Length - 1) != 0)
            {
                for (int i = 1; i < token.Length; i++)
                {
                    if (token[i] == '"')
                    {
                        if (i == token.Length - 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
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

        // The acdepted identifier begins with a letter and then it can have letters, numbers or '_'
        public bool isIdentifier(string token)
        {
            bool acceptedCharacter = false;

            char[] initialCharacter = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] acceptedCharacters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_' };

            if (token.Length > 0)
            {
                // This step assures we have one letter as the begining character of the variable
                for (int i = 0; i < initialCharacter.Length; i++)
                {
                    if (token[0] == initialCharacter[i])
                    {
                        // Next we test every consecutive character is defined as accepted one
                        for (int j = 1; j < token.Length; j++)
                        {
                            acceptedCharacter = false;

                            for (int k = 0; k < acceptedCharacters.Length; k++)
                            {
                                if (token[j] == acceptedCharacters[k])
                                {
                                    acceptedCharacter = true;
                                    break;
                                }
                            }

                            if (acceptedCharacter == true)
                            {
                                if (j == token.Length - 1)
                                {
                                    return true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
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
