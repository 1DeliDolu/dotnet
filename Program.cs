using System;
using System.Text;

public class Program
{
  public static void Main()
  {
    Console.WriteLine("Hello world!");

    Console.WriteLine("This is a test.");
    string message = "This is a test.        ";
    Console.WriteLine($"My message is: {message.TrimEnd()}");
    message = message.Replace("test", "experiment");
    /* string myReplace = message.Replace("test", "experiment");
    test is old value
    experiment is new value
    
    
     */
    Console.WriteLine($"After replace: {message.TrimEnd()}");

    // Replace with your own code

    /* Contains */
    if (message.Contains("experiment"))
    {
      Console.WriteLine("The message contains the word 'experiment'.");
    }

    /* Uppercase */
    Console.WriteLine($"Uppercase: {message.ToUpper()}");
  }
}