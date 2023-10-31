using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test.Tools;

public class Driver
{
	private Driver( )
	{
	}

	public static IWebDriver Instance { get; private set; }

	public static IWebDriver ChromeInstance( )
	{
		ChromeOptions options = new ChromeOptions();
		options.AddArguments( "--disable-notifications" ); // to disable notification

		//if( Instance == null )
			Instance = new ChromeDriver( options );
		return Instance;
	}
	public static void DisposeInstance( )
	{
		Instance.Close( );
		Instance.Quit( );
		Instance.Dispose( );

		Instance = null;
	}

	//public static IWebDriver GetEdgeInstance( )
	//{
	//    if( s_edgeDriver == null )
	//        s_edgeDriver = new EdgeDriver();

	//    return s_edgeDriver;
	//}

}
