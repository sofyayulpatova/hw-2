namespace homework2;

public partial class MainPage : ContentPage
{
	private readonly IDataManager _dataManager; // to allow data display
	private readonly IOrderManager _orderManager; // to allow data display

	public MainPage()
	{
		InitializeComponent();
	}

	private async void GoToDataExploreClicked(object sender, EventArgs e)
	{
		// here we are redirecting to a new page if user wants to explore the data
		await Navigation.PushAsync(new DataExplore(App.DataManager));
	}
	private async void CreateTestDataClicked(object sender, EventArgs e)
	{

		// Create Test data (see Homework 1).
		String msg = App.DataManager.CreateTestData(); // the datamanager is the App property
		await DisplayAlert("Alert", "Test data is create", "OK");
	}

	private async void ImportDataClicked(object sender, EventArgs e)
	{
		// Import data from a file (see Homework 1).

		App.DataManager.Load(App.DataManager.Path);
		await DisplayAlert("Alert", "Imported from a file!", "OK");


	}

	private async void SaveDataClicked(object sender, EventArgs e)
	{
		
		// Save data in a file (see Homework 1).
		
		try
		{
			if (App.DataManager.Save(App.DataManager.Path)){
				await DisplayAlert("Alert", "Saved!", "OK");
			}
			else{
				await DisplayAlert("Alert", "errerererer!", "OK");
			}
			
			//  Block of code to try
		}
		catch (Exception er)
		{
			if (er.InnerException != null)
            	await DisplayAlert("Alert", er.InnerException.ToString(), "OK");

			await DisplayAlert("Alert", er.Message, "OK");
			// Console.WriteLine(er.Message);
			//  Block of code to handle errors
		}
	}
	
	private async void CreateOrderClicked(object sender, EventArgs e)
	{
		// user wants to create order
		await Navigation.PushAsync(new OrderCreation());


	}



}

