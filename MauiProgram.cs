using Microsoft.Extensions.Logging;


namespace homework2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IDataManager>(new FigureXMLDataManager());
		builder.Services.AddSingleton<IOrderManager>(provider => provider.GetRequiredService<IDataManager>() as IOrderManager);

		return builder.Build();
	}
}
