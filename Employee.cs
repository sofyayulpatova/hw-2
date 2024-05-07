// Homework 1 is created by Sofya Yulpatova sy21002

/*
Create a subclass "Employee" for the class "Person":
With a property "AgreementDate".
With a property "AgreementNr".
With override of the ToString method to return both superclass and subclass properties.
*/
namespace homework2 
    {
    public class Employee: Person
    {
        // you have not said we need attributes, so there is no

        // property for AgreementDate
        public DateTime AgreementDate { get; set; }

        // property for AgreementNr
        public int AgreementNr { get; set; }

        public override string ToString()
        {
            return $"name is: {Name}, surname is: {Surname}, full name is: {FullName}, email is: {Email}, agreement date is: {AgreementDate}, agreement number is: {AgreementNr}";
        }
    }
}