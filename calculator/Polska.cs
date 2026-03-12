using System;

namespace calculator
{
    public class Polska
    {
        public static int Evaluate(string[] rpnTokens)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < rpnTokens.Length; i++)
            {
                string token = rpnTokens[i];

                if (int.TryParse(token, out int number))
                {
                    stack.Push(number); 
                }
                else
                {
                    int b = stack.Pop();
                    int a = stack.Pop();

                    int result = 0;

                    switch (token)
                    {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":
                            if (b == 0)
                            {
                                throw new DivideByZeroException("dividing on 0 is prohibited!");
                            }
                            result = a / b;
                            break;
                        case "^":
                            result = (int)Math.Pow(a, b); 
                            break;
                        default:
                            throw new InvalidOperationException($"unknown opp: {token}");
                    }

                    stack.Push(result);
                }
            }

            int finalResult = stack.Pop();
            
            if (!stack.IsEmpty())
            {
                throw new Exception("Error there are extra numbers.");
            }

            return finalResult;
        }
    }
}