// Homework 1 is created by Sofya Yulpatova sy21002
using System.Xml.Serialization; 
namespace homework2; 
using System.Collections.Generic;

    /*
Create a class "Order":
With Property "Number". The property may contain letters and is read-only outside the class. Generate unique order number when new order is created.
With property "OrderDate". Set to the system time when new order is created, if not specified explicitly.
With property "State". State is an enumerable with values: New, Completed, Canceled, AwaitingPayment, Pending, AwaitingPickup. The value should be set to "New", when creating a new order.
With property "Customer" (type Customer).
With property "ResponsibleEmployee" (type Employee).
With property "Details". It should be a list (or array) of OrderDetail instances.
With atleast 2 constructors. One of them without parameters - setting the default values.

With method addProduct to allow adding a product to the order. (The method has 2 parameters: name and amount.)
Override the ToString method to return information about the order as text.
*/

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
public enum OrderState { New, Completed, Canceled, AwaitingPayment, Pending, AwaitingPickup }

public class Order
{
    
    //. private static int orderNumberSeed = 1; // i will just create a unique order numbers with this :)
    // unlicky did not work, firstly thought I am genious, then the disappointment came :)
    public string order_number; // I do not know how to use the property with a private setter during the ser. process so yeah....

    // https://www.w3schools.com/cs/cs_properties.php
    [XmlIgnore]
    public string Number { 
        get => order_number; 
        private set => order_number = value; } // private set us providing the possibility to make a property read-only outside the class


    // Auto-Implemented Properties
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties?redirectedfrom=MSDN
    public DateTime OrderDate { get; set; } = DateTime.Now;


    public OrderState State { get; set; }
    // we previously defined Customer class
    public Person Customer { get; set; }

    public Person ResponsibleEmployee { get; set; }

    public List<OrderDetail> Details { get; } = new List<OrderDetail>();

    // Constructors
   

    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types

    public Order(Person customer, Person employee, DateTime? orderDate = null)
    {
        // was just the most simple way to replace my perfect (from the 1st glance) idea with the counter
        order_number = Guid.NewGuid().ToString(); //  // https://learn.microsoft.com/en-us/dotnet/api/system.guid?view=net-8.0
        Customer = customer;
        ResponsibleEmployee = employee;

    

        // HasValue https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1.hasvalue?view=net-8.0
        if (orderDate.HasValue)
        {
            OrderDate = orderDate.Value; // getting value provided from nullable datatype
        }

    }
     public Order()
      { 
        order_number = Guid.NewGuid().ToString(); //  https://learn.microsoft.com/en-us/dotnet/api/system.guid?view=net-8.0

     } 
  


    public void AddProduct(Product product, int amount)
    {
        var orderDetail = new OrderDetail { Product = product, Amount = amount };
        Details.Add(orderDetail);
    }

    public override string ToString()
    {
        var details_string = string.Join(", ", Details.Select(d => $"{d.Product.Name} in am of: {d.Amount}")); // https://learn.microsoft.com/en-us/dotnet/api/system.string.join?view=net-8.0 very simple, basically as in python :)
        return $"Order Number: {Number}, Date: {OrderDate.ToShortDateString()}, State: {State}, Customer: {Customer.FullName}, Employee: {ResponsibleEmployee.FullName}, Details: {details_string}";
    }


}
