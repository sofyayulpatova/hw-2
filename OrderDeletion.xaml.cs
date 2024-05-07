namespace homework2;
// Explore all stored data, including Orders, Products, Customers, and Employees.
using System.Collections.ObjectModel;
public partial class OrderDeletion : ContentPage

{
    public OrderDeletion()
	{
		InitializeComponent();
        // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
        
	}

    private async void DeleteOrderClicked(object sender, EventArgs e){
        var orderid = OrderId.Text;
        if (App.DataManager.FindAndDeleteOrder(orderid)){
            await DisplayAlert("Alert", "Order is deleted!", "OK");
        }
        else{
            await DisplayAlert("Alert", "Something went wrong!", "OK");
        }
        // find order by its id and delete it

    }





    
}