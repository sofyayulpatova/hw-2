namespace homework2;
// Explore all stored data, including Orders, Products, Customers, and Employees.
using System.Collections.ObjectModel;
public partial class OrderCreation : ContentPage

{
    private ObservableCollection<Product> _selectedProducts = new ObservableCollection<Product>();
    public OrderCreation()
	{
		InitializeComponent();
        // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
        //ProductsView.ItemsSource = App.DataManager.GetProducts();

        
	}

    public async void OrderCreateClicked(object sender, EventArgs e){
        var customerId = Convert.ToInt32(CustomerIdEntry.Text);
        var employeeId = Convert.ToInt32(EmployeeIdEntry.Text);

        Person customer = App.DataManager.FindCustomer(customerId);
        Person employee = App.DataManager.FindEmployee(employeeId);

        if (customer == null || employee == null)
    {
        // Handle the case where the customer or employee wasn't found
        await DisplayAlert("Error", "Customer or Employee not found.", "OK");
        return;
    }

        Order neworder = new Order(customer, employee);

        var orderdetails = ProductDetails.Text;


        // string currentmpn = "";
        // int quantity = 0;

        string[] productLines = orderdetails.Split('\n');


        foreach (var line in productLines){
        // Split each line by ';'
            string[] parts = line.Split(';');
            neworder.AddProduct(App.DataManager.GetProductMpn(parts[0]), Int32.Parse(parts[1]));
        }

        App.DataManager.orders.Add(neworder);


    await DisplayAlert("Success", "Order created successfully.", "OK");
    }
}