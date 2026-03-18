namespace calculator;

public class Tokenz
{
    public static string[] GetTokens(string input)
    {
        string[] tokens = new string[10];
        int tokenCount = 0;
        string numberBuffer = "";

        void AddToken(string token)
        {
            if (tokenCount == tokens.Length)
            {
                string[] newArray = new string[tokens.Length * 2];
                Array.Copy(tokens, newArray, tokens.Length);
                tokens = newArray;
            }

            tokens[tokenCount] = token;
            tokenCount++;
        }
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsDigit(c) || c == '.' || c == ',')
            {
                numberBuffer += c;
            }
          
            else if (c == ' ')
            {
                if (numberBuffer != "")
                {
                    AddToken(numberBuffer); 
                    numberBuffer = "";    
                }
            }
            else if ("+-*/^()@".Contains(c))
            {
                if (numberBuffer != "")
                {
                    AddToken(numberBuffer); 
                    numberBuffer = "";
                }
                AddToken(c.ToString());
            }
        }
        if (numberBuffer != "")
        {
            AddToken(numberBuffer);
        }

        string[] result = new string[tokenCount];
        Array.Copy(tokens, result, tokenCount);
            
        return result;
    }
}