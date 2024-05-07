// Homework 1 is created by Sofya Yulpatova sy21002


/*


Create an abstract class "Person":

With private attributes and public properties: "Name" and "Surname".
With read-only property "FullName". Property returns the concatenation of the first name and last name with one space in between.
With property "EMail". The value can be set only, if it matches the email address format. (the minimum requirement is it contains the symbol "@" and the symbol is not the first or the last character).
With override of the ToString method to return the values of all properties as text.


*/


// Well, in the beginning I thought it is not very necessary to include all the links to the documentation, 
// but still I was using them. so that is why i tried to comment with the links to the official documentation. But of course not for a very simple things like class creation....
// okay, found a very good article on medium, could be useful :) 
// https://medium.com/itthirit-technology/how-to-use-interfaces-to-create-abstract-classes-in-net-core-d5651e84df7e

using System.Xml.Serialization;

namespace homework2 {

    [XmlInclude(typeof(Customer))]
    [XmlInclude(typeof(Employee))]
    public abstract class Person
    {
        // variables for the attributes name, surname and email
        private string _name;
        private string _surname;
        private string _email;

        private int _id; //  

        public int Id
        {
            get => _id;
            set => _id = value;

        }


        // Public property for name with get and set
        // defining public properties https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
        public string Name
        {
            get => _name;
            set => _name = value;

        }

        // Public property for surname with get and set
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        // ReadOnly property FullName that returns name and surname (simply without setter)
        public string FullName
        {
            get => Name + " " + Surname; 
        }

        // Public property for email
        // The setter includes a validation for email format
        public string Email
        {


            get => _email; 
            // so it is old version of defining getters and setters, I use it here as I need to check the value before setting it
            set
            {
                // Checks if the email contains '@' and it is not the first or last character.
                // this is link to hte documentatiuon about strings and specifically mwthod contains 

                // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
                // https://learn.microsoft.com/en-us/dotnet/api/system.string.contains?view=net-8.0


                if (value[0] != '@' && value[value.Length - 1] != '@' && value.Contains('@'))
                {
                    _email = value;
                }
                else
                {
                    // https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-8.0
                    // I use ArgumentException as it will be more friendly to undestand what is worng :)
                    // Basically, it is used when one of the arguments provided to a method is not valid, as in our case - value for email property
                    throw new ArgumentException("not an email. Email contains '@' and it is not the first or last character");
                }
            }



        }

        // Override of ToString method to return the values of all properties as text.
        // so I should you several possibilties of using formatting - addition of strings (works for very simple tasks as fullname), and String interpolation (still from the same doc page "Strings")
        public override string ToString()
        {
            return $"name is: {Name}, surname is: {Surname}, full name is: {FullName}, email is: {Email}, id is {Id}";
        }
    }
}