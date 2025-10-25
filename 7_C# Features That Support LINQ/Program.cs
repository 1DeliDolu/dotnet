using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public int OrderSize { get; set; }
}

public class Program
{
    public static void Main()
    {
        string[] stringArray = { "mike", "mary", "john", "matt", "lisa" };

        var query = from str in stringArray
                    group str by str[0] into stringGroup
                    orderby stringGroup.Key
                    select stringGroup;

        foreach (var group in query)
        {
            Console.WriteLine($"Group {group.Key}:");
            foreach (var name in group)
                Console.WriteLine($"  {name}");
        }

        var cust = new Customer { Name = "Mike", Phone = "555-1212" };

        var IncomingOrders = new List<Customer>
        {
            new Customer { Name = "Alice", Phone = "111-1111", OrderSize = 3 },
            new Customer { Name = "Bob", Phone = "222-2222", OrderSize = 7 },
            new Customer { Name = "Charlie", Phone = "333-3333", OrderSize = 9 }
        };

        var newLargeOrderCustomers = 
            IncomingOrders
                .Where(x => x.OrderSize > 5)
                .Select(y => new Customer { Name = y.Name, Phone = y.Phone });

        foreach (var c in newLargeOrderCustomers)
            Console.WriteLine($"New Customer: {c.Name}, {c.Phone}");

        int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        IEnumerable<string> QueryMethod1(int[] ints) =>
            from i in ints
            where i > 4
            select i.ToString();

        void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
            returnQ = from i in ints
                      where i < 4
                      select i.ToString();

        var myQuery1 = QueryMethod1(nums);
        foreach (var s in myQuery1)
            Console.WriteLine(s);

        QueryMethod2(nums, out IEnumerable<string> myQuery2);
        foreach (var s in myQuery2)
            Console.WriteLine(s);

        myQuery1 = from item in myQuery1
                   orderby item descending
                   select item;

        Console.WriteLine("\nModified myQuery1:");
        foreach (var s in myQuery1)
            Console.WriteLine(s);
    }
}
