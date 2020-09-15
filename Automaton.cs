namespace LFP_PROYECTO1_Basic_IDE
{
    class Automaton
    {
        private string[] states { get; set;}

        private string[] alphabet { get; set; }

        private string[][] transitionFunction { get; set; }

        private string initialState { get; set; }

        private string[] finalStates { get; set; }

        private string nextState (int actualState, int letter, string[][] transitionFunction)
        {
            string nextState = "";

            if (transitionFunction.Length > 0)
            {
                for (int i = 0; i < transitionFunction.Length; i++)
                {
                    if (transitionFunction[i].Length > 0)
                    {
                        for (int j = 0; j < transitionFunction[i].Length; j++)
                        {
                            if (actualState == i && letter == j)
                            {
                                nextState = transitionFunction[i][j];
                            }
                        }
                    }
                }
            }

            return nextState;
        }

        public string AFD (string actualState, string letter, string[] acceptationStates)
        {
            string log = "";

            string myNextState = "";
            if (states.Length > 0)
            {
                for (int i = 0; i < states.Length; i++)
                {
                    if (states[i].Length > 0)
                    {
                        for (int j = 0; j < states.Length; i++)
                        {
                            if (states[i] == actualState && alphabet[j] == letter)
                            {
                                myNextState = nextState(i, j, transitionFunction);
                                
                            }
                        }
                    }
                }
            }

            return log;
        }
    }
}
