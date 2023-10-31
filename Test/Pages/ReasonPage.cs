using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public class ReasonPage
	{

		internal static void ClickOnActionReasonPanel( )
		{
			Driver.Instance.FindElement( By.Id( "DoActionReason" ) ).Click( );
			Driver.Instance.ImplicitWaitFor( "Action Reson Page" );
		}

		internal static void ClickOnAutomaticOpration( )
		{
			Driver.Instance.FindElement( By.CssSelector( "[href='javascript:psg.ui.layout.load( \"/oa/AutomaticOperations\" );void(0);']" ) ).Click( );
			Driver.Instance.ImplicitWaitFor( "Load Automatic Opration Page" );
		}

		internal static void ClickOnConfirmButton( )
		{
			Driver.Instance.FindElement( By.Id( "button-ok" ) ).Click( );
			Driver.Instance.ImplicitWaitFor( "Save Prepared Content" );
		}

		internal static void ClickOnNewLink( )
		{
			Driver.Instance.FindElement( By.CssSelector( ".new-refer-reason-link" ) ).Click( );
		}

		internal static void ClickOnPersonnelSetting( )
		{
			Driver.Instance.FindElement( By.CssSelector( "[href='javascript:psg.ui.layout.load( \"/oa/Settings/PersonalSettings\" );void(0);']" ) ).Click( );
			Driver.Instance.ImplicitWaitFor( "Load Personnel Setting" );
		}

		internal static void ClickOnPreparedContents( )
		{
			Driver.Instance.FindElement( By.Id( "PreparedContents" ) ).Click( );
			Driver.Instance.ImplicitWaitFor( "Prepared Content Page" );
		}

		internal static void ClickOnEditPreparedContentTitle( string preparedContentTitle )
		{
			Driver.Instance.WaitForLoadAnElementByXPath( $"//div[@id='referReasonList']//div[@class='table-row']/div[.='{preparedContentTitle}']", $"{preparedContentTitle} In List" ).Click( );
			Driver.Instance.FindElement( By.XPath( "//div[@class='referReasonItem selected']//div[@class='table-cell edit-zone edit']" ) ).Click( );
			Driver.Instance.ImplicitWaitFor( " Load PreparedContent" );
		}

		internal static void ClickOnReferResonPanel( )
		{
			Driver.Instance.FindElement( By.CssSelector( ".menu-items > div:nth-of-type(6) .item-link" ) ).Click( );
			Driver.Instance.ImplicitWaitFor( "Refer Reson" );
		}

		internal static void ClickOnTool( )
		{
			IWebElement btnetting = Driver.Instance.FindElement(By.XPath("//a[@data-title='ابزار']"));
			btnetting.Click( );
			Driver.Instance.ImplicitWaitFor( "Setting Page" );
		}



		internal static void FillPreparedContentDiscreption( string preparedContentDiscreption )
		{
			IJavaScriptExecutor javaScriptc=(IJavaScriptExecutor) Driver.Instance;
			IWebElement ckEditor = Driver.Instance.FindElement(By.CssSelector(".cke_wysiwyg_frame"));
			Driver.Instance.SwitchTo( ).Frame( ckEditor );
			IWebElement body = Driver.Instance.FindElement(By.TagName("body"));
			javaScriptc.ExecuteScript( $"arguments[0].innerHTML = '{preparedContentDiscreption}';", body );
			Driver.Instance.SwitchTo( ).DefaultContent( );
			Driver.Instance.ImplicitWaitFor( " Prepared Content" );
		}

		internal static void FillPreparedContentTitle( string preparedContentTitle )
		{
			Driver.Instance.FindElement( By.Id( "title" ) ).SendKeys( preparedContentTitle );
		}

		internal static void FillReferReason( string referReason )
		{
			Driver.Instance.WaitForLoadAnElementById( "refer-reason-input", "" ).SendKeys( referReason );
			Driver.Instance.FindElement( By.CssSelector( ".referReasonList-content-wrapper" ) ).Click( );
		}

		internal static void VerifyAddReason( string referReson )
		{
			IWebElement reasonTitle = Driver.Instance.WaitForLoadAnElementByXPath($"//div[@id='referReasonList']//div[@class='table-row']/div[.='{referReson}']",$"{referReson} In List");
			ErrorDetector.Detect( );
			Assert.That( reasonTitle.Displayed, Is.EqualTo( true ) );
		}

		internal static void VerifyLoadAutomaticOpration( )
		{
			//IWebElement btnAuto  = Driver.Instance.FindElement(By.Id("nav-macro-type-auto"));
			IWebElement btnMacro = Driver.Instance.FindElement(By.Id("nav-macro-type-nonAuto"));
			// IWebElement lstMacro = Driver.Instance.FindElement(By.Id("macro-list"));
			IWebElement macroNew = Driver.Instance.FindElement(By.Id("macro-new"));
			ErrorDetector.Detect( );
			//Assert.That(btnAuto.Displayed,Is.EqualTo(true));
			Assert.That( btnMacro.Displayed, Is.EqualTo( true ) );
			// Assert.That(lstMacro.Displayed,Is.EqualTo(true));
			Assert.That( macroNew.Displayed, Is.EqualTo( true ) );
		}



		internal static void VerifyLoadPersonnelSetting( string userLogin )
		{
			string settingView = userLogin+"Personnelsettingview.jpg";
			string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{settingView}";
			IWebElement imgSettingPage = Driver.Instance.WaitForLoadAnElementById( "personal-settings-form" , "personal settings form" );
			Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(imgSettingPage);

			if( !File.Exists( filePath ) )
			{
				bmpPageScreenshot.Save( filePath );
			}

			Bitmap bmpSettingImage = new Bitmap(filePath);
			bool result = Utility.CompareBitmapImages(bmpSettingImage, bmpPageScreenshot);
			ErrorDetector.Detect( );
			Assert.That( result, Is.True );
		}



		internal static void VerifyLoadReferReson( )
		{
			IWebElement  resonList = Driver.Instance.FindElement(By.CssSelector(".personal-list-section"));
			IWebElement  reson = Driver.Instance.FindElement(By.Id("referReasonList"));
			IWebElement  newReson = Driver.Instance.FindElement(By.Id("addNewReferReason"));
			ErrorDetector.Detect( );
			Assert.That( resonList.Displayed, Is.EqualTo( true ) );
			// Assert.That( reson.Displayed , Is.EqualTo( true ) );
			Assert.That( newReson.Displayed, Is.EqualTo( true ) );
		}

		internal static void VerifyLoadToolPage( )
		{
			string settingView = "settingview.jpg";
			string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{settingView}";
			IWebElement imgSettingPage = Driver.Instance.WaitForLoadAnElementById( "workspaceToolsView" , "Tools Tamplate" );
			Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(imgSettingPage);

			if( !File.Exists( filePath ) )
			{
				bmpPageScreenshot.Save( filePath );
			}

			Bitmap bmpSettingImage = new Bitmap(filePath);
			bool result = Utility.CompareBitmapImages(bmpSettingImage , bmpPageScreenshot);
			ErrorDetector.Detect( );
			Assert.That( result, Is.True );
		}

		internal static void VerifyPreparedContentSave( string userLogin, string title )
		{
			string preparedContentView = userLogin+title+"preparecontent.jpg";
			string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{preparedContentView}";
			IWebElement imgpreparedContentPage = Driver.Instance.WaitForLoadAnElementById( "editor" , "prepared Content Page" );
			Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(imgpreparedContentPage);

			if( !File.Exists( filePath ) )
			{
				bmpPageScreenshot.Save( filePath );
			}

			Bitmap bmpSettingImage = new Bitmap(filePath);
			bool result = Utility.CompareBitmapImages(bmpSettingImage , bmpPageScreenshot);
			ErrorDetector.Detect( );
			Assert.That( result, Is.True );
		}
	}
}
