namespace homework2;
public partial class DataEditing : ContentPage
{
    private Product _product;
    private IDataManager _dataManager; 
    public DataEditing()
    {
        InitializeComponent();
    }

    private async void OnLoadProductClicked(object sender, EventArgs e)
    {
        var mpn = mpnEntry.Text;
        _product = App.DataManager.GetProductMpn(mpn); // get product by MPN new method in manager
        if (_product != null)
        {
            // Editing fileds contain product infos
            productNameEntry.Text = _product.Name;
            productPriceEntry.Text = _product.Price.ToString();
            productNameEntry.IsVisible = true;
            productPriceEntry.IsVisible = true;
            buttonSave.IsVisible = true;
            buttonLoad.IsVisible = false;
            
        }
        else
        {
            // Handle the case where no product is found for the given MPN
            await DisplayAlert("Error", "Product not found.", "OK");
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // when save clicked
        _product.Name = productNameEntry.Text;
        _product.Price = decimal.Parse(productPriceEntry.Text); // https://learn.microsoft.com/it-it/dotnet/api/system.decimal.parse?view=net-8.0

        // Update the product 
        
        if (App.DataManager.UpdateProduct(_product) != null){
            // return back
            await Navigation.PopAsync();
        }
        await DisplayAlert("Error", "Something went wrong, try again.", "OK");
        
    }
}
