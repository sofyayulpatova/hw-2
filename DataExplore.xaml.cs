
namespace homework2;
using Microsoft.Maui.Controls;
using System;
// Explore all stored data, including Orders, Products, Customers, and Employees.

public partial class DataExplore : ContentPage

{
    private readonly IDataManager _dataManager; // to allow data display
    private readonly IOrderManager _orderManager; // to allow data display

    public DataExplore(FigureXMLDataManager dataManager)
    {
        InitializeComponent();
        // when data is updated -> view updated itslef
        ProductsView.ItemsSource = dataManager.GetProducts();
        PeronsView.ItemsSource = dataManager.GetPersons();
        OrdersView.ItemsSource = dataManager.GetOrders();


    }
    protected override void OnAppearing()
{
    base.OnAppearing();
    // https://learn.microsoft.com/en-us/dotnet/api/xamarin.forms.page.onappearing?view=xamarin-forms
    
    // Explicitly refresh the product list every time the page appears
    ProductsView.ItemsSource = App.DataManager.GetProducts();
}

  


    private async void CreateNewObjectClicked(object sender, EventArgs e){
        // Create new Products and Customers
		await Navigation.PushAsync(new DataCreation());
	}
    
    private async void EditProductClicked(object sender, EventArgs e){
        // edit roduct object
        await Navigation.PushAsync(new DataEditing());
    }
    private async void DeleteOrderClicked(object sender, EventArgs e){
        await Navigation.PushAsync(new OrderDeletion());
    }


    /* 
     Create new Orders allowing specification of order details and customer.
    Provide data editing capabilities for at least one class.
    // edit products
    Implement the functionality to remove objects for at least one class.*/
    //remove orders
}
