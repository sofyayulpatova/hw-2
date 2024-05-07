namespace homework2;

public partial class App : Application
{
	public static FigureXMLDataManager DataManager { get; private set; }
	public static string Path { get; set; } = "/Users/sofya/Downloads/homework2/data.txt";


	public App()
	{
		InitializeComponent();

		DataManager = new FigureXMLDataManager(); // datamanager initialization

		MainPage = new AppShell();
		MainPage = new NavigationPage(new MainPage());

	}
}
