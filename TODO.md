# TODO

- [x] Learn to manage data collections using List<T> in C# → `5_ListCollections`

---

Learn to manage data collections using List<T> in C#
07/10/2025
This introductory tutorial provides an introduction to the C# language and the basics of the class.

This tutorial teaches you C# interactively, using your browser to write C# code and see the results of compiling and running your code. It contains a series of lessons that create, modify, and explore collections and arrays. You work primarily with the List<T> class.

A basic list example
 Tip

When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

Run the following code in the interactive window. Replace <name> with your name and select Run:

C#

Copy

Run
List<string> names = ["<name>", "Ana", "Felipe"];
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
You created a list of strings, added three names to that list, and printed the names in all CAPS. You're using concepts that you learned in earlier tutorials to loop through the list.

The code to display names makes use of the string interpolation feature. When you precede a string with the $ character, you can embed C# code in the string declaration. The actual string replaces that C# code with the value it generates. In this example, it replaces the {name.ToUpper()} with each name, converted to capital letters, because you called the String.ToUpper method.

Let's keep exploring.

Modify list contents
The collection you created uses the List<T> type. This type stores sequences of elements. You specify the type of the elements between the angle brackets.

One important aspect of this List<T> type is that it can grow or shrink, enabling you to add or remove elements. You can see the results by modifying the contents after you displayed its contents. Add the following code after the code you already wrote (the loop that prints the contents):

C#

Copy
Console.WriteLine();
names.Add("Maria");
names.Add("Bill");
names.Remove("Ana");
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
You added two more names to the end of the list. You also removed one as well. The output from this block of code shows the initial contents, then prints a blank line and the new contents.

The List<T> enables you to reference individual items by index as well. You access items using the [ and ] tokens. Add the following code after what you already wrote and try it:

C#

Copy
Console.WriteLine($"My name is {names[0]}.");
Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");
You're not allowed to access past the end of the list. You can check how long the list is using the Count property. Add the following code:

C#

Copy
Console.WriteLine($"The list has {names.Count} people in it");
Select Run again to see the results. In C#, indices start at 0, so the largest valid index is one less than the number of items in the list.

For more information about indices, see the Explore indexes and ranges article.

Search and sort lists
Our samples use relatively small lists, but your applications might often create lists with many more elements, sometimes numbering in the thousands. To find elements in these larger collections, you need to search the list for different items. The IndexOf method searches for an item and returns the index of the item. If the item isn't in the list, IndexOf returns -1. Try it to see how it works. Add the following code after what you wrote so far:

C#

Copy
var index = names.IndexOf("Felipe");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}

index = names.IndexOf("Not Found");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}
You might not know if an item is in the list, so you should always check the index returned by IndexOf. If it's -1, the item wasn't found.

The items in your list can be sorted as well. The Sort method sorts all the items in the list in their normal order (alphabetically for strings). Add this code and run again:

C#

Copy
names.Sort();
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
Lists of other types
You've been using the string type in lists so far. Let's make a List<T> using a different type. Let's build a set of numbers. Delete the code you wrote so far, and replace it with the following code:

C#

Copy

Run
List<int> fibonacciNumbers = [1, 1];
That creates a list of integers, and sets the first two integers to the value 1. The Fibonacci Sequence, a sequence of numbers, starts with two 1's. Each next Fibonacci number is found by taking the sum of the previous two numbers. Add this code:

C#

Copy
var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

fibonacciNumbers.Add(previous + previous2);

foreach (var item in fibonacciNumbers)
{
    Console.WriteLine(item);
}
Press Run to see the results.

Challenge
See if you can put together some of the concepts from this and earlier lessons. Expand on what you built so far with Fibonacci Numbers. Try to write the code to generate the first 20 numbers in the sequence. (As a hint, the 20th Fibonacci number is 6765.)

Did you come up with something like this?

Details
You completed the list interactive tutorial, the final introduction to C# interactive tutorial. You can visit the .NET site to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials. Or, you can continue with the Explore object oriented programming with classes and objects tutorial.

You can learn more about .NET collections in the following articles:

Selecting a collection type
Commonly used collection types
When to use generic collections
 Collaborate with us on GitHub
The source for this content can be found on GitHub, where you can also create and review issues and pull requests. For more information, see our contributor guide.

.NET feedback

.NET is an open source project. Select a link to provide feedback:

 Open a documentation issue
 Provide product feedback
Additional resources
Documentation

Branches and loops - Introductory tutorial - A tour of C#

In this tutorial about branches and loops, you write C# code to explore the language syntax that supports conditional branches and loops to execute statements repeatedly. You write C# code and see the results of compiling and running your code directly in the browser.

Pattern matching - A tour of C#

In this tutorial about pattern matching, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.

Tuples and types - Introductory interactive tutorial - A tour of C#

In this tutorial about creating types, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.

Show 5 more
Training

Module

Implement Collection Types - Training

Learn, to use C# tools for managing groups of objects dynamically, ensuring type safety and efficient data manipulation.

Certification

Microsoft Certified: Azure Developer Associate - Certifications

Build end-to-end solutions in Microsoft Azure to create Azure Functions, implement and manage web apps, develop solutions utilizing Azure storage, and more.

Events

.NET Conf 2025

Oct 24, 6 PM - Oct 24, 6 PM

.NET 10 launches at .NET Conf 2025! Tune in with the .NET community to celebrate and learn about the new release on November 11 - 13.

Save the date
# TODO

- [x] Learn to manage data collections using List<T> in C# → `5_ListCollections`

---
