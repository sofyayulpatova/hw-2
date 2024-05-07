  
using System.Collections.ObjectModel;


namespace  homework2
{
  public interface IOrderManager
    {
        void AddOrder(Order order);
        void AddPerson(Person person, bool iscustomer);
        void AddProduct(Product product);
        ObservableCollection<Order> GetOrders();
        ObservableCollection<Product> GetProducts();
        ObservableCollection<Person> GetPersons();
    }
}