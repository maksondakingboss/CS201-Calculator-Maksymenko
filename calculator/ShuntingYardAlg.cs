using System;

namespace calculator
{
    public class ShuntingYardAlg
    {
        private static int GetPriority(string op)
        {
            switch (op)
            {
                case "^":
                    return 3;
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 1;
                default:
                    return 0;
            }
        }

        private static bool IsRightAssociative(string oper)
        {
            return oper == "^";
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
        }
        
        public static string[] ConvertToRPN(string[] tokens)
        {
            Stack<string> stack = new Stack<string>();
            
            Queue<string> outputQueue = new Queue<string>();

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                if (!IsOperator(token) && token != "(" && token != ")")
                {
                    outputQueue.Enqueue(token); 
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (!stack.IsEmpty() && stack.Peek() != "(")
                    {
                        outputQueue.Enqueue(stack.Pop()); 
                    }
                    if (!stack.IsEmpty()) stack.Pop(); 
                }
                else if (IsOperator(token))
                {
                    while (!stack.IsEmpty() && stack.Peek() != "(")
                    {
                        string topOperator = stack.Peek();
                        int p1 = GetPriority(token);
                        int p2 = GetPriority(topOperator);

                        if (p2 > p1 || (p1 == p2 && !IsRightAssociative(token)))
                        {
                            outputQueue.Enqueue(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }
                    stack.Push(token);
                }
            }

            while (!stack.IsEmpty())
            {
                outputQueue.Enqueue(stack.Pop());
            }

            int count = outputQueue.Count();
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = outputQueue.Dequeue();
            }

            return result;
        }
    }
}