using System;
using System.Globalization;

namespace calculator
{
    public class Polska
    {
        public static double Evaluate(string[] rpnTokens)
        {
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < rpnTokens.Length; i++)
            {
                string token = rpnTokens[i];

               
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(number); 
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    double result = 0;

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
                            result = Math.Pow(a, b); 
                            break;
                        default:
                            throw new InvalidOperationException($"unknown opp: {token}");
                    }

                    stack.Push(result);
                }
            }

            double finalResult = stack.Pop();
            
            if (!stack.IsEmpty())
            {
                throw new Exception("Error there are extra numbers.");
            }

            return finalResult;
        }
    }
}