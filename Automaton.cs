using System;

namespace LFP_PROYECTO1_Basic_IDE
{
    class Automaton
    {
        public string[] states = new string[0]; // { get; set;}

        public string[] alphabet = new string[0]; // { get; set;}

        public string[,] transitionFunction = new string[0,0]; // { get; set;}

        public string initialState = ""; // { get; set;}

        public string[] finalStates = new string[0]; // { get; set;}

        public string actualState = "";
        public string actualLetter = "";

        //**************************************

        public string[] GetStates ()
        {
            return states;
        }

        public void SetStates (string[] myStates)
        {
            states = myStates;
        }

        public string[] GetAlphabet ()
        {
            return alphabet;
        }

        public void SetAlphabet (string[] myAlphabet)
        {
            alphabet = myAlphabet;
        }

        public string[,] GetTransitionFunction ()
        {
            return transitionFunction;
        }

        public void SetTransitionFunction (string[,] myTransitionFunction)
        {
            transitionFunction = myTransitionFunction;
        }

        public string GetInitialState ()
        {
            return initialState;
        }

        public void SetInitialState (string myInitialState)
        {
            initialState = myInitialState;
        }

        public string[] GetFinalStates ()
        {
            return finalStates;
        }

        public void SetFinalStates (string[] myFinalStates)
        {
            finalStates = myFinalStates;
        }

        //**************************************

        public Automaton()
        {

        }

        //**************************************

        private string nextState (int actualState, int letter, string[,] transitionFunction)
        {
            string nextState = "";

            try
            {
                for (int i = 0; i < transitionFunction.GetLength(0); i++)
                {
                    for (int j = 0; j < transitionFunction.GetLength(1); j++)
                    {
                        if (actualState == i && letter == j)
                        {
                            nextState = transitionFunction[i, j];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return nextState;
        }

        public string AFD (string actualState, string letter, string[] finalStates)
        {
            string myNextState = "";

            try
            {
                for (int i = 0; i < transitionFunction.GetLength(0); i++)
                {
                    for (int j = 0; j < transitionFunction.GetLength(1); j++)
                    {
                        if (states[i] == actualState && alphabet[j] == letter)
                        {
                            myNextState = nextState(i, j, transitionFunction);
                            return myNextState;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return myNextState;
        }
    }
}
