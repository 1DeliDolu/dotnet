C# if statements and loops - conditional logic tutorial
03/12/2025
This tutorial teaches you how to write C# code that examines variables and changes the execution path based on those variables. You write C# code and see the results of compiling and running it. The tutorial contains a series of lessons that explore branching and looping constructs in C#. These lessons teach you the fundamentals of the C# language.

 Tip

When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

Run the following code in the interactive window. Select Run:

C#

Copy

Run
int a = 5;
int b = 6;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10.");
Modify the declaration of b so that the sum is less than 10:

C#

Copy
int b = 3;
Select the Run button again. Because the answer is less than 10, nothing is printed. The condition you're testing is false. You don't have any code to execute because you only wrote one of the possible branches for an if statement: the true branch.

 Tip

As you explore C# (or any programming language), you make mistakes when you write code. The compiler finds those errors and report them to you. When the output contains error messages, look closely at the example code, and the code in the interactive window to see what to fix. That exercise helps you learn the structure of C# code.

This first sample shows the power of if and boolean types. A boolean is a variable that can have one of two values: true or false. C# defines a special type, bool for boolean variables. The if statement checks the value of a bool. When the value is true, the statement following the if executes. Otherwise, it's skipped.

This process of checking conditions and executing statements based on those conditions is powerful. Let's explore more.

Make if and else work together
To execute different code in both the true and false branches, you create an else branch that executes when the condition is false. Try the following code:

C#

Copy

Run
int a = 5;
int b = 3;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10");
else
    Console.WriteLine("The answer is not greater than 10");
The statement following the else keyword executes only when the condition being tested is false. Combining if and else with boolean conditions provides all the power you need.

 Important

The indentation under the if and else statements is for human readers. The C# language doesn't treat indentation or white space as significant. The statement following the if or else keyword executes based on the condition. All the samples in this tutorial follow a common practice to indent lines based on the control flow of statements.

Because indentation isn't significant, you need to use { and } to indicate when you want more than one statement to be part of the block that executes conditionally. C# programmers typically use those braces on all if and else clauses. The following example is the same as what you created. Try it.

C#

Copy
int a = 5;
int b = 3;
if (a + b > 10)
{
    Console.WriteLine("The answer is greater than 10");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
}
 Tip

Through the rest of this tutorial, the code samples all include the braces, following accepted practices.

You can test more complicated conditions:

C#

Copy
int a = 5;
int b = 3;
int c = 4;
if ((a + b + c > 10) && (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is equal to the second");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not equal to the second");
}
The == symbol tests for equality. Using == distinguishes the test for equality from assignment, which you saw in a = 5.

The && represents "and". It means both conditions must be true to execute the statement in the true branch. These examples also show that you can have multiple statements in each conditional branch, provided you enclose them in { and }.

You can also use || to represent "or":

C#

Copy
if ((a + b + c > 10) || (a == b))
Modify the values of a, b, and c and switch between && and || to explore. You gain more understanding of how the && and || operators work.

Use loops to repeat operations
Another important concept to create larger programs is loops. You use loops to repeat statements that you want executed more than once. Try this code in the interactive window:

C#

Copy

Run
int counter = 0;
while (counter < 10)
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
}
The while statement checks a condition and executes the statement following the while. It repeats checking the condition and executing those statements until the condition is false.

There's one other new operator in this example. The ++ after the counter variable is the increment operator. It adds 1 to the value of counter, and stores that value in the counter variable.

 Important

Make sure that the while loop condition does switch to false as you execute the code. Otherwise, you create an infinite loop where your program never ends. Let's not demonstrate that, because the engine that runs your code times out and you see no output from your program.

The while loop tests the condition before executing the code following the while. The do ... while loop executes the code first, and then checks the condition. It looks like this:

C#

Copy
int counter = 0;
do
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
} while (counter < 10);
This do loop and the earlier while loop work the same.

Let's move on to one last loop statement.

Work with the for loop
Another common loop statement that you see in C# code is the for loop. Try this code in the interactive window:

C#

Copy

Run
for (int counter = 0; counter < 10; counter++)
{
    Console.WriteLine($"Hello World! The counter is {counter}");
}
The preceding for loop does the same work as the while loop and the do loop you already used. The for statement has three parts that control how it works:

The first part is the for initializer: int counter = 0; declares that counter is the loop variable, and sets its initial value to 0.
The middle part is the for condition: counter < 10 declares that this for loop continues to execute as long as the value of counter is less than 10.
The final part is the for iterator: counter++ specifies how to modify the loop variable after executing the block following the for statement. Here, it specifies that counter increments by 1 each time the block executes.
Experiment with these conditions yourself. Try each of the following changes:

Change the initializer to start at a different value.
Change the condition to stop at a different value.
When you're done, let's move on to write some code yourself to use what you learned.

There's one other looping statement that isn't covered in this tutorial: the foreach statement. The foreach statement repeats its statement for every item in a sequence of items. It's most often used with collections. It's covered in the next tutorial.

Created nested loops
A while, do, or for loop can be nested inside another loop to create a matrix using the combination of each item in the outer loop with each item in the inner loop. Let's do that to build a set of alphanumeric pairs to represent rows and columns.

One for loop can generate the rows:

C#

Copy

Run
for (int row = 1; row < 11; row++)
{
    Console.WriteLine($"The row is {row}");
}
Another loop can generate the columns:

C#

Copy
for (char column = 'a'; column < 'k'; column++)
{
    Console.WriteLine($"The column is {column}");
}
You can nest one loop inside the other to form pairs:

C#

Copy
for (int row = 1; row < 11; row++)
{
    for (char column = 'a'; column < 'k'; column++)
    {
        Console.WriteLine($"The cell is ({row}, {column})");
    }
}
You can see that the outer loop increments once for each full run of the inner loop. Reverse the row and column nesting, and see the changes for yourself.

Combine branches and loops
Now that you saw the if statement and the looping constructs in the C# language, see if you can write C# code to find the sum of all integers 1 through 20 that are divisible by 3. Here are a few hints:

The % operator gives you the remainder of a division operation.
The if statement gives you the condition to see if a number should be part of the sum.
The for loop can help you repeat a series of steps for all the numbers 1 through 20.
Try it yourself. Then check how you did. As a hint, you should get 63 for an answer.

Did you come up with something like this?

Details
You completed the "branches and loops" interactive tutorial. You can select the list collection link to start the next interactive tutorial, or you can visit the .NET site to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials.

You can learn more about these concepts in these articles:

Selection statements
Iteration statements
 Collaborate with us on GitHub
The source for this content can be found on GitHub, where you can also create and review issues and pull requests. For more information, see our contributor guide.

.NET feedback

.NET is an open source project. Select a link to provide feedback:

 Open a documentation issue
 Provide product feedback
Additional resources
Documentation

Data collections - Introductory interactive tutorial - A tour of C#

In this tutorial, you use your browser to learn about C# collections. You write C# code and see the results of compiling and running your code directly in the browser.

Pattern matching - A tour of C#

In this tutorial about pattern matching, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.

Tuples and types - Introductory interactive tutorial - A tour of C#

In this tutorial about creating types, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.

Show 5 more
Training

Learning path

Add logic to C# console applications (Get started with C#, Part 3) - Training

Deepen your experience with C# logic and iteration statements, Boolean expressions, and code blocks in this Learning Path.

Events

.NET Conf 2025

Oct 24, 6 PM - Oct 24, 6 PM

.NET 10 launches at .NET Conf 2025! Tune in with the .NET community to celebrate and learn about the new release on November 11 - 13.

Save the date