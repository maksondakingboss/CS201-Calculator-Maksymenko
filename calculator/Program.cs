using System;
using calculator;

Console.WriteLine("Enter math equation:");

string inputExpression = Console.ReadLine();

if (string.IsNullOrEmpty(inputExpression))
{
    Console.WriteLine("Error enter smth");
    return; 
}

try
{
    string[] tokens = Tokenz.GetTokens(inputExpression);
    
    string[] polyaki = ShuntingYardAlg.ConvertToRPN(tokens);
    Console.WriteLine($"RPN: {string.Join(" ", polyaki)}");
    
    double result = Polska.Evaluate(polyaki);

    Console.WriteLine($"result: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"error: {ex.Message}");
}

Console.WriteLine("Press any button to exit");
Console.ReadKey();