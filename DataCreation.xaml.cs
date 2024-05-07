namespace homework2;
// Explore all stored data, including Orders, Products, Customers, and Employees.

public partial class DataCreation : ContentPage


{
    public DataCreation()
	{
		InitializeComponent();

	}

	private async void AddCustomerClicked(object sender, EventArgs e)
    {
        var customerName = CustomerNameEntry.Text;
        var customerSurname = CustomerSurnameEntry.Text;
        var customerEmail = CustomerEmailEntry.Text;

        // validate that it is not null and not white space
        if (string.IsNullOrWhiteSpace(customerName) ||
            string.IsNullOrWhiteSpace(customerSurname) ||
            string.IsNullOrWhiteSpace(customerEmail))
        {
            // Ideally, inform the user about the requirement
            await DisplayAlert("Alert", "You should enter customer's data !", "OK");
			return;
        }

       

        var addedcustomer = new Customer
        {
            Name = customerName,
            Surname = customerSurname,
            Email = customerEmail
        };

        App.DataManager.AddPerson(addedcustomer, true);
         //App.DataManager.persons.Add(addedcustomer);

        // clear the form fields after adding
        CustomerNameEntry.Text = string.Empty;
        CustomerSurnameEntry.Text = string.Empty;
        CustomerEmailEntry.Text = string.Empty;

		// user is notified of successful opaeration

		await DisplayAlert("Alert", "Customer is added!", "OK");
		await Navigation.PopAsync();


    }
	private async void AddProductClicked(object sender, EventArgs e)
    {
		var productName = ProductNameEntry.Text;
        var productPrice = ProductPriceEntry.Text;
        var productMpn = ProductMpnEntry.Text;

		 // validate that it is not null and not white space
        if (string.IsNullOrWhiteSpace(productName) ||
            string.IsNullOrWhiteSpace(productPrice) ||
            string.IsNullOrEmpty(productMpn))
        {
            // Ideally, inform the user about the requirement
            await DisplayAlert("Alert", "You should enter product's data !", "OK");
			return;
        }
        // 
        var addedproduct = new Product
        {
            Name = productName,
            Mpn = productMpn,
            Price = Convert.ToDecimal(productPrice)
        };

        App.DataManager.AddProduct(addedproduct);

        // clear the form fields after adding
        ProductNameEntry.Text = string.Empty;
        ProductPriceEntry.Text = string.Empty;

		// user is notified of successful opaeration
		MessagingCenter.Send<DataCreation, string>(this, "ProductUpdated", "Update the list");
		// we want to notify thet thae products list should be updated because of the new product added


		await DisplayAlert("Alert", "Product is added!", "OK");
	
		await Navigation.PopAsync();

        

    }
}