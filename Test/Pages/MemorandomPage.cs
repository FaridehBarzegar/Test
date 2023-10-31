using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Payvast.OATest.Data.Objects;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Security.Principal;
using Test.Data;
using Test.Data.Objects;
using Test.Public;
using Test.Senario;
using Test.Tools;

namespace Test.Pages
{
	public class MemorandomPage
    {
        /// <summary>
        /// انتخاب گروه پست سازمانی به عنوان گیرنده
        /// </summary>
        /// <param name="tool"></param>
        internal static void ChooseReciverFromPositionGroup( PositionAndContactGroup group )
        {
            IWebElement reciverobjpiker = Driver.Instance.FindElement(By.Id("To_text"));
            reciverobjpiker.SendKeys(group.SearchKeyText);
            Driver.Instance.WaitForLoadAnElementByXPath($"//div[.='{group.PositionGroupTitle}']","Result Of Object Piker").Click();
        }

        /// <summary>
        /// نمایش صحیح پست‌های گروه انتخاب شده در فیلد گیرنده 
        /// </summary>
        /// <param name="tool"></param>
        internal static void VerifyChooseGroupMembersAsReciver( PositionAndContactGroup group )
        {
            string [] reciverMembers = group.PositionMember.Split("|");
            for(int i = 0; i < reciverMembers.Length; i++ )
            {
                IWebElement reciverMember =Driver.Instance.FindElement( By.CssSelector( $"[title='{reciverMembers[i]}'] > .item-text"));
                Assert.That(reciverMember.Displayed,Is.EqualTo(true));
            }
        }

        /*private string m_title;
private string m_description;
private string m_reciver;
private string m_searchReciver;
private string m_transcriptReciver;
private string m_searchTranscriptReciver;
private string m_transcriptOrder;
private IWebDriver Driver.Instance;
private IWebElement m_ObjTo => Driver.Instance.FindElement( By.XPath( "//div[@class='items-container']//*[@id='To_text']" ) );
private IWebElement m_ObjToselect => Driver.Instance.FindElement( By.CssSelector( "#To_objectPicker .items-container" ) );
private IWebElement m_ObjTranscriptItems0TranscriptToAsPosition => Driver.Instance.FindElement( By.Id( "TranscriptItems_0_TranscriptToAsPosition_text" ) );
private IWebElement m_ObjTranscriptItems1TranscriptToAsPosition => Driver.Instance.FindElement( By.Id( "TranscriptItems_1_TranscriptToAsPosition_text" ) );
private IWebElement m_TxtTranscriptItems0TranscriptReason => Driver.Instance.FindElement( By.Id( "TranscriptItems_0__TranscriptReason" ) );
private IWebElement m_TxtTranscriptItems1TranscriptReason1 => Driver.Instance.FindElement( By.Id( "TranscriptItems_1__TranscriptReason" ) );
private IWebElement m_BtnAdd => Driver.Instance.FindElement( By.Id( "add" ) );
private IWebElement m_ChckCopyMemorandom => Driver.Instance.FindElement( By.XPath( "//div[@id='memorandum-button-wrapper']/div[1]/div[@class='table-cell']" ) );
// priv staticate IWebElement m_ChckAdditionalData_HasTranscriptFol lowUp m_driverh( "//div[@class='icheckbox_minimal-purple checked']/ins[@class='iCheck-helper']" ));
private IWebElement m_Txtmemorandumtitle => Driver.Instance.FindElement( By.Id( "memorandum-title" ) );
private IWebElement m_Btnimportanceflag => Driver.Instance.FindElement( By.ClassName( "importance-flag" ) );
private IWebElement m_CkEditor => Driver.Instance.FindElement( By.Id( "cke_1_top" ) );
private IWebElement m_ContentMemorandom => Driver.Instance.FindElement( By.CssSelector( "#cke_1_contents > iframe" ) );

public MemorandomPage(
   string memorandomTitle , string description , string reciver , string searchReciver , string transcriptReciver ,
   string transcriptOrder , string searchTranscriptReciver , IWebDriver driver )
{
   Driver.Instance = driver;
   m_title = memorandomTitle;
   m_description = description;
   m_reciver = reciver;
   m_searchReciver = searchReciver;
   m_transcriptReciver = transcriptReciver;
   m_searchTranscriptReciver = searchTranscriptReciver;
   m_transcriptOrder = transcriptOrder;
}
public MemorandomPage( Memorandom memorandom , IWebDriver driver ) :
   this( memorandom.MemorandomTitle , memorandom.Description , memorandom.Reciver , memorandom.SearchReciver ,
       memorandom.TranscriptReciver , memorandom.SearchTranscriptReciver2 , memorandom.TranscriptOrder , driver )
{
}
public MemorandomPage( IWebDriver driver ) : this( string.Empty , string.Empty , string.Empty , string.Empty , string.Empty , string.Empty , string.Empty , driver ) { }

public void SetReciver( )
{
   try
   {
     Driver.Instance.FindElement(By.CssSelector( "#To_objectPicker .items-container")).Click();
     Driver.Instance.ImplicitWaitFor(PageEnums.objectPiker.ToString());
     m_ObjTo.SendKeys( m_searchReciver );
       //string[ ] searchResult = m.searchReciverResult.Split( "،" );
       //foreach( string searchItem in searchResult )
      //    DefaultWaitManagement.WaitForLoadAnElementByXPath( Driver.Instance, 2, $"//li[. = '{searchItem}']" );
      Driver.Instance.FindElement( By.XPath( $"//li[ .= '{m_reciver}']" ) ).Click();
   }
   catch( Exception exp )
   {
       throw;

   }
}

public void SetTitle( )
{
   m_Txtmemorandumtitle.Click();
   m_Txtmemorandumtitle.SendKeys( m_title );
}

public void SetDescription( )
{
   Driver.Instance.SwitchTo().Frame( m_ContentMemorandom );
   IWebElement body = Driver.Instance.FindElement( By.TagName( "body" ) );
   if( string.IsNullOrEmpty( body.Text ) )
   {
       body.Click();
       body.SendKeys( m_description );
       Assert.AreEqual( true , body.Displayed );
   }
   Driver.Instance.SwitchTo().ParentFrame();
}

public void SetTranscriptReciver( Memorandom memorandom )
{
   //  string[ ] searchtranscriptResult = memorandom.t.Split( "،" );
   m_ObjTranscriptItems0TranscriptToAsPosition.Click();
   m_ObjTranscriptItems0TranscriptToAsPosition.SendKeys( memorandom.TranscriptSearchReciver );
   //foreach( string searchItem in searchtranscriptResult )
   //   DefaultWaitManagement.WaitForLoadAnElementByXPath( Driver.Instance, 5, $"//li[. = '{searchItem}']" );
   Driver.Instance.FindElement( By.XPath( $"//li[. = '{memorandom.TranscriptReciver}']" ) ).Click();
}

public void SetTranscriptOrder( string order )
{
   m_TxtTranscriptItems0TranscriptReason.Click();
   m_TxtTranscriptItems0TranscriptReason.SendKeys( order );
}

public void SetTranscriptReciver2( Memorandom memorandom )
{
   m_ObjTranscriptItems1TranscriptToAsPosition.Click();
   m_ObjTranscriptItems1TranscriptToAsPosition.SendKeys( memorandom.SearchTranscriptReciver2 );
   Driver.Instance.FindElement( By.XPath( $"//li[. = '{memorandom.TranscriptReciver2}']" ) ).Click();
}

public void SetTranscriptOrder2( string order )
{
   m_TxtTranscriptItems0TranscriptReason.Click();
   m_TxtTranscriptItems0TranscriptReason.SendKeys( order );
}

public void Save( )
{
   Driver.Instance.FindElement( By.Id( "f8f76661-500a-4ed5-bcd4-bd1db55c96bf-label" ) ).Click();
   Driver.Instance.ImplicitWaitFor(PageEnums.saveMemorandom.ToString());
}

public void Send( )
{
   Driver.Instance.FindElement( By.Id( "7f4bc636-4abb-41f1-82f9-d0ed7c036819" ) ).Click();
   Driver.Instance.ImplicitWaitFor(PageEnums.sendMemorandom.ToString());
}


public void ClickOnAddTranscriptReciver( )
{
   Driver.Instance.FindElement( By.Id( "add" ) ).Click();
}







// private  void SelectTranscriptWithReferralOrder( ObjectPiker reciver , string referralCommand )
//{
//        string[] searchtranscriptResult = reciver.transcriptSearchResult.Split("،" );
//        m_ObjTranscriptItems0TranscriptToAsPosition.Click( );
//        m_ObjTranscriptItems0TranscriptToAsPosition.SendKeys( reciver.transcriptSearchReciver );
//        foreach( string searchItem in searchtranscriptResult )
//            DefaultWaitManagement.WaitForLoadAnElementByXPath( Driver.Instance, 5, $"//li[. = '{searchItem}']");
//        Driver.Instance.FindElement( By.XPath( $"//li[. = '{reciver.transcriptReciver}']" ) ).Click( );
//        Driver.Instance.FindElement( By.XPath( "//input[@id='TranscriptItems_0__TranscriptReason']" )).Click( );
//        new Actions( Driver.Instance ).DoubleClick( Driver.Instance.FindElement( By.XPath( "//input[@id='TranscriptItems_0__TranscriptReason']" ))).Build( ).Perform( );
//        Driver.Instance.ImplicitWaitFor( 3 );
//        Driver.Instance.FindElement ( By.XPath($"//div[@text='{referralCommand}']")).Click( );
//}

//private  void SelectTranscript2( ObjectPiker  reiver )
//{
//        string[] searchtranscriptResult = reiver.searchResultTranscriptReciver2.Split("،" );
//       Driver.Instance.FindElement( By.Id( "add" ) ).Click( );
//        m_ObjTranscriptItems1TranscriptToAsPosition.Click( );
//        m_ObjTranscriptItems1TranscriptToAsPosition.SendKeys( reiver.searchTranscriptReciver2 );
//        foreach( string searchItem in searchtranscriptResult )
//            DefaultWaitManagement.WaitForLoadAnElementByXPath( Driver.Instance, 5, $"//li[. = '{searchItem}']" );
//       Driver.Instance.FindElement( By.XPath( $"//li[. = '{reiver.transcriptReciver2}']" ) ).Click( );
//        m_TxtTranscriptItems1TranscriptReason1.SendKeys( reiver.transcriptOrder2 );
//}

//private  void SelectReciverFromChart( ObjectPiker reciver )
//{
//    string[] searchresult = reciver.searchResultReciverFromChart.Split("،");
//    Driver.Instance.FindElement( By.XPath( "//div[@class='custom-selector-icon']" )).Click( );
//    Driver.Instance.ImplicitWaitFor( 3 );
//    Driver.Instance.FindElement( By.XPath( "//div[@class='custom-selector-closer shown']" ));
//    Driver.Instance.FindElement( By.XPath( "//div[@id='To_customSelectorContainer']" ));
//    Driver.Instance.FindElement( By.XPath( "//div[contains(text(),'نمایش چارت')]" )).Click( );
//    Driver.Instance.FindElement( By.Id("To_customSelectorContainer_Search" )).SendKeys(reciver.searchReciverFromChart );
//    foreach( string searchItem in searchresult )
//    {
//        IJavaScriptExecutor javaScriptc=(IJavaScriptExecutor)Driver.Instance; 
//         IWebElement element1= DefaultWaitManagement.WaitForLoadAnElementByXPath( Driver.Instance, 5, $"//a[@class='jstree-anchor jstree-search'][contains(text(),'{searchItem}')]" );
//         javaScriptc.ExecuteScript("arguments[0].scrollIntoView();", element1);
//    }
//    IJavaScriptExecutor javaScript=(IJavaScriptExecutor) Driver.Instance;
//    IWebElement element = Driver.Instance.FindElement( By.XPath($"//a[contains(text(),'{reciver.reciverFromChart}')]"));
//    javaScript.ExecuteScript("arguments[0].scrollIntoView();", element);
//    Driver.Instance.ImplicitWaitFor( 2 );
//    Driver.Instance.FindElement( By.XPath($"//a[contains(text(),'{reciver.reciverFromChart}')]//i[@class='jstree-icon jstree-checkbox']")).Click();
//    Driver.Instance.FindElement(By.Id( "To_objectPicker" )).Click( );
//}

// private  void SelectReciverFromPersonelList( ObjectPiker reciver )
//{
//    Driver.Instance.FindElement( By.XPath("//div[@class='custom-selector-icon']")).Click( );
//    Driver.Instance.ImplicitWaitFor( 3 );
//    Driver.Instance.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
//    Driver.Instance.FindElement( By.XPath("//div[@id='To_customSelectorContainer']"));
//    Driver.Instance.FindElement( By.XPath("//div[@class='header selected'][contains(text(),'لیست شخصی')]")).Click( );
//    Driver.Instance.FindElement( By.XPath("//div[@class='favorite-list']")).Click( );
//    ReadOnlyCollection<IWebElement> elements = Driver.Instance.FindElements(By.XPath("//div[@id='To_customSelectorContainer']//div[@class='favoriteItem table fixed']"));
//    string [] PersonelListItem = reciver.searchResultReciverFromPersonelList.Split( "،" );
//    foreach(string searchItem in PersonelListItem )
//    {
//        Driver.Instance.FindElement( By.XPath( $"//div[@id='To_customSelectorContainer']//a[text()='{searchItem}']"));
//    }
//    Driver.Instance.FindElement( By.XPath($"//div[@text='{reciver.reciverFromPersonelList}']")).Click( );
//    Driver.Instance.FindElement(By.Id("To_objectPicker")).Click( );
//}

// private void SelectTranscriptReciverFromChart( ObjectPiker reciver )
//{
//    string[] searchresult = reciver.searchResultTranscriptReciverFromChart.Split("،");
//    Driver.Instance.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']//div[@class='custom-selector-icon']")).Click( );
//    Driver.Instance.ImplicitWaitFor( 3 );
//    Driver.Instance.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
//    Driver.Instance.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//div[contains(text(),'نمایش چارت')]")).Click( );
//    Driver.Instance.FindElement( By.Id("TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer_Search")).SendKeys(reciver.searchTranscriptReciverFromChart );
//    foreach( string searchItem in searchresult )
//    {
//        IJavaScriptExecutor javaScriptc=(IJavaScriptExecutor) Driver.Instance; 
//         IWebElement element1= DefaultWaitManagement.WaitForLoadAnElementByXPath( Driver.Instance, 5, $"//a[@class='jstree-anchor jstree-search'][contains(text(),'{searchItem}')]" );
//         javaScriptc.ExecuteScript("arguments[0].scrollIntoView();", element1);
//    }
//    IJavaScriptExecutor javaScript=(IJavaScriptExecutor) Driver.Instance;
//    IWebElement element = Driver.Instance.FindElement( By.XPath($"//a[contains(text(),'{reciver.transcriptReciverFromChart}')]"));
//    javaScript.ExecuteScript("arguments[0].scrollIntoView();", element);
//    Driver.Instance.ImplicitWaitFor(2);
//    Driver.Instance.FindElement( By.XPath($"//a[@class='jstree-anchor jstree-search'][contains(text(),'{reciver.transcriptReciverFromChart}')]")).Click();
//    Driver.Instance.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']")).Click( );
//    //driver.FindElement( By.Id("TranscriptItems_0_TranscriptToAsPosition_objectPicker")).Click( );
//    //IWebElement closeCustomer = driver.FindElement( By.XPath("//[@class='custom-selector-closer']"));
//    //Assert.AreEqual(true , closeCustomer.Displayed);
//}

// private  void SelectTranscriptReciverFromPersonelList(ObjectPiker reciver )
//{
//    string[] searchresult = reciver.searchResultTranscriptReciverFromPersonelList.Split("،");
//    ReadOnlyCollection<IWebElement> reciversSelected = Driver.Instance.FindElements( By.XPath("//div[@id='To_objectPicker']//span[@class='item']"));
//    Driver.Instance.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']//div[@class='custom-selector-icon']")).Click( );
//    Driver.Instance.ImplicitWaitFor( 3 );
//    Driver.Instance.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
//    Driver.Instance.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//div[contains(text(),'لیست شخصی')]")).Click( );
//    ReadOnlyCollection<IWebElement> elements = Driver.Instance.FindElements( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//div[@class='favoriteItem table fixed']"));
//    foreach( string searchItem in searchresult )
//    Driver.Instance.FindElement( By.XPath( $"//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//a[text()='{searchItem}']"));
//    Driver.Instance.FindElement( By.XPath($"//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//a[text()='{reciver.transcriptReciverFromPersonelList}']")).Click( );
//    Driver.Instance.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']")).Click( );

//}

//private  void SetImportance( string priority )
//{
//        switch( priority )
//        {
//            case "آنی":
//            Driver.Instance.FindElement( By.XPath( "//span[@class='importance-flag normal']" ) ).Click( );
//            Driver.Instance.FindElement( By.XPath( "//span[@class='importance-flag important']" ) ).Click( );
//            break;
//            case "فوری":
//            Driver.Instance.FindElement( By.XPath( "//span[@class='importance-flag normal']" ) ).Click( );
//            break;
//        }
//}


//private  void SetMemorandomDiscriptionWithPrepareContent( ReadyText readyText )
//{
//    Actions action  = new Actions(Driver.Instance);
//   Driver.Instance.FindElement( By.XPath( "//span[@class='cke_button_icon cke_button__readytexts_icon']" )).Click( );
//   Driver.Instance.FindElement( By.XPath( "//span[@class='cke_button_icon cke_button__readytexts_icon']" )).Click( );
//   Driver.Instance.ImplicitWaitFor( 3 );
//   Driver.Instance.FindElement( By.XPath( $"//li[.='{readyText.readyTextTitle}']" )).Click( );
//    IWebElement pop= Driver.Instance.FindElement( By.CssSelector("#popup-container-closer"));
//    pop.Click();
//    Driver.Instance.SwitchTo( ).Frame( m_ContentMemorandom );
//    IWebElement body = Driver.Instance.FindElement(By.TagName("body"));
//    Assert.AreEqual( readyText.readyTextDiscription,body.Text );
//    Driver.Instance.SwitchTo( ).ParentFrame( );
//}

//private  void SelectMemorandomAttachment( string fileName )
//{
//    IWebElement fileUploadContent = Driver.Instance.FindElement( By.Id( "3fa525f9-4419-47bd-8bc2-f8c4166450b7" ));
//    fileUploadContent.Click();
//    Driver.Instance.ImplicitWaitFor( 2 );
//    HandleOpenDialog hndOpen = new HandleOpenDialog();  
//    hndOpen.fileOpenDialog(@"E:\FileUpload\MemorandomAttachment", fileName); 
//    IWebElement attachmentsUploaded = Driver.Instance.WaitForLoadAnElementByXPath( 3 , "//div[@class='attachment-containter']");
//    Assert.That( attachmentsUploaded.Displayed ,Is.EqualTo( true ));
//}

//public  void DeselectTranscriptFollowup( )
//{

//    //driver.FindElement( By.CssSelector("#memorandum-button-wrapper > div:nth-child(2) > div > div > ins")).Click( );
//    Driver.Instance.FindElement( By.XPath("(//ins[@class='iCheck-helper'])[2]")).Click( );
//    IWebElement m_checkWithFollowup = Driver.Instance.FindElement( By.CssSelector("#memorandum-button-wrapper > div:nth-child(2) > div >div "));
//    string classElementm_checkWithFollowup = m_checkWithFollowup.GetAttribute("class");
//    Assert.That( classElementm_checkWithFollowup , Is.EqualTo( "icheckbox_minimal-purple hover" ));

//}

//#region MemorandomMethod


//private  void SendCreateMemorandom( )
//{

//}

//private  void MemorandomPrepare (Memorandom memorandom , ObjectPiker reciver )
//{
//    SetDescription( memorandom );
//    SetTitle( memorandom.memorandomTitle );
//    SetReciver( reciver );
//}

//#endregion

//private  void LogoutUser( )
//{
//   // LogoutPage.LogoutSucceed( );
//}
//private  void LoginUser( string userLogin )
//{
//    UserLogin user = LoginData.FindUserByUserName(userLogin);
//    LoginSenario.LoginSucceed( user);
//}

//#region Internal
//private  void CheckImportance( string priority )
//{
//    if( priority == "آنی" )
//    {
//       Assert.AreEqual(true, Driver.Instance.FindElement(By.CssSelector( ".row-font-color-C80000" )).Displayed);
//    }
//    else if( priority == "فوری" )
//    {
//        Assert.AreEqual(true,Driver.Instance.FindElement(By.CssSelector( ".row-font-color-0000C8" )).Displayed);
//    }
//}



//private  void CheckMemorandomIsSavedWithImportance( string priority)
//{
//    //MemorandomActionsPage.MemorandomEditPageLoad( );
//    if( priority == "آنی" )
//    {
//       Assert.AreEqual(true, Driver.Instance.FindElement(By.XPath("//span[@class='importance-flag critical']")).Displayed);
//    }
//    else if( priority == "فوری" )
//    {
//        Assert.AreEqual(true,Driver.Instance.FindElement(By.XPath("//span[@class='importance-flag important']")).Displayed);
//    }
//    else
//    {
//        Assert.AreEqual(true,Driver.Instance.FindElement( By.XPath( "//span[@class='importance-flag normal']" )).Displayed);
//    }
//}


//private  void CheckMemorandomIsRecivedWithTranscript( Memorandom memorandom , ObjectPiker objectPiker ,string persianFromDate )
//{
//    //LoginUser( objectPiker.userLoginTranscriptReciver );
//    //ShellPage.OpenOfficeAutomation( );
//    CartablePage cartablePage = new CartablePage( Driver.Instance );
//    cartablePage.EnsureCartablePageIsLoaded( );
//    IWebElement recivedMemorandomTitile =
//    Driver.Instance.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
//    IWebElement recivedMemorandomDate =
//    Driver.Instance.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
//    Assert.AreEqual( true, recivedMemorandomTitile.Displayed );
//    Assert.AreEqual( true, recivedMemorandomDate.Displayed );

//}
// private  void CheckMemorandomIsSavedWithTrascriptReciver2( ObjectPiker reciver )
//{
//    IWebElement transcriptReciver2 = Driver.Instance.FindElement(By.CssSelector($"[title='{reciver.transcriptReciver2}'] > .item-text"));
//    IWebElement transcriptOrder2 = Driver.Instance.FindElement(By.Id("TranscriptItems_1__TranscriptReason"));
//    transcriptOrder2.GetAttribute("value");
//    //question
//    Assert.AreEqual(true,transcriptReciver2.Displayed );
//  //  Assert.AreEqual( memorandom.transcriptOrder,transcriptOrder.GetAttribute("value"));
//}



//private  void CheckMemorandomIsSendWithAttachment( Memorandom memorandom , ObjectPiker objectPiker )
//{
//    IWebElement attacmentIcon = Driver.Instance.FindElement( By.XPath( "//tr[2]//span[@class='wil-icon itemFlag']" ));
//    Assert.That( attacmentIcon.Displayed , Is.EqualTo(true));
//    //MemorandomActionsPage.MemorandomViewPageLoad( memorandom , objectPiker );
//}
//private  void CheckMemorandomIsSavedWithAttachment( Memorandom memorandom ,ObjectPiker objectPiker )
//{
//   // MemorandomActionsPage.MemorandomViewPageLoadAttachment( memorandom , objectPiker );
//}

//private  void CheckMemorandomIsSavedWithReferralTranscriptOrder( Memorandom memorandom ,ObjectPiker objectPiker , string transcriptOrder )
//{
//    //MemorandomActionsPage.DraftMemorandomViewPageLoadTranscriptReferral( memorandom , objectPiker , transcriptOrder );
//}

//private void CheckMemorandomIsSendWithoutTranscriptFollowUp( string transcriptReciver )
//{
//     IWebElement m_reciver =Driver.Instance.FindElement( By.XPath("(//tr[@class='ui-widget-content jqgrow ui-row-rtl unviewedRow'])[1]")).FindElement(By.XPath("//td[@aria-describedby='WIL-list_workTransactionReceiver']"));
//     string memorandomReciver = m_reciver.GetAttribute("title") ; 
//     Assert.That(memorandomReciver , Is.Not.EqualTo(transcriptReciver));
//}
//#endregion



#region Save
//public  void Save( Memorandom memorandom , ObjectPiker reciver )
//{
//    DateTime fromDateTime = DateTime.Now;
//    string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
//    //SaveCreatedMemorandom( );
//    //CheckMemorandomIsSavedInDraft( memorandom, persianFromDate );
//}

//        public  void SaveWithImportance( Memorandom memorandom , ObjectPiker reciver )
//        {
//            SetImportance( memorandom.priority);

//        }

//        public  void SaveWithTranscriptReciver( Memorandom memorandom , ObjectPiker reciver)
//        {
//            SetTranscriptReciver(reciver);
//            Save( memorandom , reciver );
//            CheckMemorandomIsSavedWithTrascript( reciver );
//        }

//        public  void SaveWithTranscriptReciver2( Memorandom memorandom , ObjectPiker reciver )
//        {
//            SelectTranscript2(reciver);
//            SaveWithTranscriptReciver(  memorandom , reciver );
//            CheckMemorandomIsSavedWithTrascriptReciver2( reciver );
//        }

//        public  void SaveSelectReciversFromChartAndPersonalList( Memorandom memorandom, ObjectPiker reciver)
//        {
//            SelectReciverFromChart(  reciver );
//            SelectReciverFromPersonelList( reciver );
//            SelectTranscriptReciverFromChart( reciver );
//            SelectTranscriptReciverFromPersonelList( reciver );
//            Save( memorandom , reciver );

//        }

//        public  void SavewithPrepareContent( Memorandom memorandom , ReadyText readyText , ObjectPiker objectPiker )
//        {
//            //driver.ImplicitWaitFor( 7 );
//            SetMemorandomDiscriptionWithPrepareContent( readyText );
//            Save( memorandom , objectPiker );
//        }

//        public  void SaveWithTranscriptOrderFromReferralCommand( Memorandom memorandom , ObjectPiker objectPiker , string referralCommand )
//        {
//            SelectTranscriptWithReferralOrder( objectPiker , referralCommand );
//            Save( memorandom , objectPiker );
//            CheckMemorandomIsSavedWithReferralTranscriptOrder( memorandom , objectPiker , referralCommand );
//        }

//        public  void SaveSelectMemorandomAttachment( Memorandom memorandom, ObjectPiker objectPiker )
//        {
//            SelectMemorandomAttachment( memorandom.fileAttachmentName );
//            Save( memorandom, objectPiker );
//            CheckMemorandomIsSavedWithAttachment( memorandom , objectPiker );
//        }

//        public  void SaveWithoutTitle( Memorandom memorandom, ObjectPiker objectPiker )
//        {
//            //SelectReciver( objectPiker );
//            SetDescription( memorandom );
//            //SaveCreatedMemorandom( );
//            IWebElement showAlertMessageForTitle = Driver.Instance.FindElement( By.XPath("//div[@id='dialogMessageText'] [text()='لطفاً عنوان را وارد نمایید']"));
//            Assert.That(showAlertMessageForTitle.Text , Is.EqualTo( "لطفاً عنوان را وارد نمایید" ));
//        }

//         public  void SaveCanceled( Memorandom memorandom, ObjectPiker objectPiker , bool cancel )
//        {
//            SetTitle( memorandom.memorandomTitle );
//            //SelectReciver( objectPiker );
//            SetDescription( memorandom );
//            //SaveCreatedMemorandom( );
//            Driver.Instance.FindElement( By.Id( "6a7f931c-73d6-4543-8eb5-d3cf28befbbb-label" )).Click( );
//            IWebElement showAlertMessageForCancel = Driver.Instance.FindElement( By.XPath("//div[@id='dialogConfirmationText']" +
//                " [text()='لطفا قبل از خروج، از ذخیره سازی اطلاعات اطمینان حاصل کنید.']"));
//            Assert.That(showAlertMessageForCancel.Text , Is.EqualTo( "لطفا قبل از خروج، از ذخیره سازی اطلاعات اطمینان حاصل کنید.\r\nآیا می خواهید ادامه دهید؟" ));
//            if( cancel )
//            {
//              Driver.Instance.FindElement( By.XPath("//button[@id='button1']")).FindElement(By.XPath("//span[text()='بلی']")).Click( );
//              //CartablePage.CartableLoad( ); 
//            }
//            else
//                Driver.Instance.FindElement( By.XPath("//button[@id='button1']")).FindElement(By.XPath("//span[text()='خیر']")).Click( );
//        }

//        public  void SaveThenDelete( Memorandom memorandom , ObjectPiker objectPiker , bool delete )
//        {
//            Save( memorandom , objectPiker );
//            //MemorandomActionsPage.MemorandomDeleteInDraft( delete );
//        }
//        #endregion

//        # region Send
//        

//        public  void SendWithTransciptReciver( Memorandom memorandom , ObjectPiker reciver )
//        {
//            SetTranscriptReciver( reciver );
//            DateTime fromDateTime = DateTime.Now;
//            //Send( memorandom , reciver );
//            CartableSenario.BackToShell( );
//            LogoutUser( );
//            LoginUser( reciver.userLoginTranscriptReciver );
//            string persianFromDate = Utility.ConvertDateToPersianDate(fromDateTime);
//            //CheckMemorandomIsRecived(  memorandom , persianFromDate );
//        }

//         public  void SendWithTranscriptReciver2( Memorandom memorandom , ObjectPiker reciver )
//        {
//           Driver.Instance.ImplicitWaitFor( 3 );
//            SelectTranscript2(reciver);
//            DateTime fromDateTime = DateTime.Now;
//            SendWithTransciptReciver(  memorandom , reciver );
//            CartableSenario.BackToShell( );
//            LogoutUser( );
//            LoginUser( reciver.userLoginTranscriptReciver2 );
//            string persianFromDate = Utility.ConvertDateToPersianDate(fromDateTime);
//            //CheckMemorandomIsRecived(  memorandom , persianFromDate );
//        }

//         public  void SendSelectReciversFromChartAndPersonalList( Memorandom memorandom, ObjectPiker reciver)
//        {
//            SelectReciverFromChart(  reciver );
//            SelectReciverFromPersonelList( reciver );
//            SelectTranscriptReciverFromChart( reciver );
//            SelectTranscriptReciverFromPersonelList( reciver );
//            //Send( memorandom , reciver );

//        }

//         public  void SendwithPrepareContent( Memorandom memorandom , ReadyText readyText , ObjectPiker objectPiker )
//        {
//            SetMemorandomDiscriptionWithPrepareContent( readyText );
//           // Send( memorandom , objectPiker );
//        }

//         public  void SendSelectMemorandomAttachment( Memorandom memorandom, ObjectPiker objectPiker )
//        {
//            Driver.Instance.ImplicitWaitFor(5);
//            SelectMemorandomAttachment( memorandom.fileAttachmentName );
//            //Send( memorandom, objectPiker );
//            CheckMemorandomIsSendWithAttachment( memorandom , objectPiker );
//        }

//         public  void SendWithTranscriptOrderFromReferralCommand( Memorandom memorandom , ObjectPiker objectPiker , string referralCommand )
//        {
//            Driver.Instance.ImplicitWaitFor( 5 );
//            SelectTranscriptWithReferralOrder( objectPiker , referralCommand );
//          //  Send( memorandom , objectPiker );
//            CheckMemorandomIsSavedWithReferralTranscriptOrder( memorandom , objectPiker , referralCommand );
//        }

//         public  void SendWithImportance( Memorandom memorandom , ObjectPiker reciver )
//        {
//            SetImportance( memorandom.priority);
//            //Send( memorandom , reciver );
//            CheckImportance( memorandom.priority );
//        }

//         public  void SendWithoutTranscriptFollowUp( Memorandom memorandom , ObjectPiker reciver )
//        {
//            DeselectTranscriptFollowup( );
//            SetTranscriptReciver( reciver );
//            MemorandomPrepare( memorandom , reciver );
//            DateTime fromDateTime = DateTime.Now;
//            SendCreateMemorandom( );
//            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
//            //CheckMemorandomIsSended( memorandom, persianFromDate );
//            CheckMemorandomIsSendWithoutTranscriptFollowUp( reciver.transcriptReciver );
//            CartableSenario.BackToShell( );
//            LogoutUser( );
//            LoginUser( reciver.userLoginReciver );
//            //CheckMemorandomIsRecived( memorandom, persianFromDate );

//        }

//         public  void SendWithoutTitle( Memorandom memorandom, ObjectPiker objectPiker )
//        {
//            Driver.Instance.ImplicitWaitFor(5);
//            //SelectReciver( objectPiker );
//            SetDescription( memorandom );
//            SendCreateMemorandom( );
//            IWebElement showAlertMessageForTitle = Driver.Instance.FindElement( By.XPath("//div[@id='dialogMessageText'] [text()='لطفاً عنوان را وارد نمایید']"));
//            Assert.That(showAlertMessageForTitle.Text , Is.EqualTo( "لطفاً عنوان را وارد نمایید" ));
//        }

//         public  void SendWithoutReciver( Memorandom memorandom, ObjectPiker objectPiker )
//        {
//            Driver.Instance.ImplicitWaitFor(5);
//            SetTitle( memorandom.memorandomTitle );
//            SetDescription( memorandom );
//            SendCreateMemorandom( );
//            IWebElement showAlertMessageForTitle = Driver.Instance.FindElement( By.XPath("//div[@id='dialogMessageText'] [text()='لطفاً گیرنده را انتخاب نمایید']"));
//            Assert.That(showAlertMessageForTitle.Text , Is.EqualTo( "لطفاً گیرنده را انتخاب نمایید" ));
//        }

//         public  void SendWithoutAccessToRegisterBook( Memorandom memorandom, ObjectPiker objectPiker )
//        {
//            Driver.Instance.ImplicitWaitFor(5);
//            SetTitle( memorandom.memorandomTitle );
//            SetDescription( memorandom );
//           // SelectReciver( objectPiker );
//            SendCreateMemorandom( );
//            IWebElement showAlertMessageForTitle = Driver.Instance.FindElement( By.XPath("//div[@id='dialogMessageText'] [text()='شما به هیچ دفتر ثبت یا الگوی شماره ثبتی دسترسی ندارید']"));
//            Assert.That(showAlertMessageForTitle.Text , Is.EqualTo( "شما به هیچ دفتر ثبت یا الگوی شماره ثبتی دسترسی ندارید" ));
//        }
//         #endregion

//        public  void SaveAndSend( Memorandom memorandom , ObjectPiker reciver)
//        {
//            MemorandomPrepare( memorandom , reciver );
//            DateTime fromDateTime = DateTime.Now;
//           // SaveCreatedMemorandom( );
//            SendCreateMemorandom( );
//            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
//            //CheckMemorandomIsSended( memorandom, persianFromDate );
//            CartableSenario.BackToShell( );
//            LogoutUser( );
//            LoginUser( reciver.userLoginReciver );
//           //CheckMemorandomIsRecived( memorandom, persianFromDate );
//        }

//        //checkagain
//         public  void SaveAndSendWithTransciptReciver( Memorandom memorandom , ObjectPiker reciver )
//        {
//            SetTranscriptReciver( reciver );
//            DateTime fromDateTime = DateTime.Now;
//            SaveAndSend( memorandom , reciver );
//            CartableSenario.BackToShell( );
//            LogoutUser( );
//            LoginUser( reciver.userLoginTranscriptReciver );
//            string persianFromDate = Utility.ConvertDateToPersianDate(fromDateTime);
//           // CheckMemorandomIsRecived(  memorandom , persianFromDate );
//        }

//         public  void SaveAndSendWithTranscriptReciver2( Memorandom memorandom , ObjectPiker reciver )
//        {
//            SelectTranscript2(reciver);
//            DateTime fromDateTime = DateTime.Now;
//            SaveAndSendWithTransciptReciver(  memorandom , reciver );
//            CartableSenario.BackToShell( );
//            LogoutUser( );
//            LoginUser( reciver.userLoginTranscriptReciver2 );
//            string persianFromDate = Utility.ConvertDateToPersianDate(fromDateTime);
//            //CheckMemorandomIsRecived(  memorandom , persianFromDate );
//        }

//         public void SaveAndSendSelectReciversFromChartAndPersonalList( Memorandom memorandom, ObjectPiker reciver)
//        {
//            SelectReciverFromChart(  reciver );
//            SelectReciverFromPersonelList( reciver );
//            SelectTranscriptReciverFromChart( reciver );
//            SelectTranscriptReciverFromPersonelList( reciver );
//            SaveAndSend( memorandom , reciver );

//        }

//         public void SaveAndSendwithPrepareContent( Memorandom memorandom , ReadyText readyText , ObjectPiker objectPiker )
//        {
//            SetMemorandomDiscriptionWithPrepareContent( readyText );
//            SaveAndSend( memorandom , objectPiker );
//        }

//         public void SaveAndSendSelectMemorandomAttachment( Memorandom memorandom, ObjectPiker objectPiker )
//        {
//            SelectMemorandomAttachment( memorandom.fileAttachmentName );
//            SaveAndSend( memorandom, objectPiker );
//            CheckMemorandomIsSendWithAttachment( memorandom , objectPiker );
//        }

//         public void SaveAndSendWithTranscriptOrderFromReferralCommand( Memorandom memorandom , ObjectPiker objectPiker , string referralCommand )
//        {
//            SelectTranscriptWithReferralOrder( objectPiker , referralCommand );
//            SaveAndSend( memorandom , objectPiker );
//            CheckMemorandomIsSavedWithReferralTranscriptOrder( memorandom , objectPiker , referralCommand );
//        }

//         public  void SaveAndSendWithImportance( Memorandom memorandom , ObjectPiker reciver )
//        {
//            SetImportance( memorandom.priority );
//            SaveAndSend( memorandom , reciver );
//            CheckImportance( memorandom.priority );
//        }

//         public  void SaveAndSendWithoutTranscriptFollowUp( Memorandom memorandom , ObjectPiker reciver )
//        {
//            DeselectTranscriptFollowup( );
//            SetTranscriptReciver( reciver );
//            MemorandomPrepare( memorandom , reciver );
//            DateTime fromDateTime = DateTime.Now;
//           // SaveCreatedMemorandom( );
//            SendCreateMemorandom( );
//            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
//            //CheckMemorandomIsSended( memorandom, persianFromDate );
//            CheckMemorandomIsSendWithoutTranscriptFollowUp( reciver.transcriptReciver );
//            CartableSenario.BackToShell( );
//            LogoutUser( );
//            LoginUser( reciver.userLoginReciver );
//           // CheckMemorandomIsRecived( memorandom, persianFromDate );

//        }

//         public  void MemorandomSucceedEdit( Memorandom memorandom , ObjectPiker objectPiker )
//        {
//           // CartablePage.CartableOpenDraft( );
//           // DraftPage.DraftPageLoad( );
////DraftPage.OpenSuccedMemorandomDraft( );
//            //MemorandomDraftPage.LoadMemorandomDraftList( );
//          //  MemorandomActionsPage.MemorandomEditPageLoad( );
//            Driver.Instance.FindElement( By.XPath("//span[@data-for='To_objectPicker']")).FindElement( By.XPath("//span[@title='حذف']")).Click( );
//           // SelectReciver( objectPiker );
//            Driver.Instance.FindElement( By.XPath("//input[@id='memorandum-title'] ")).Clear();
//            SetTitle( memorandom.memorandomTitle );
//            SetDescription( memorandom );
//            //SaveCreatedMemorandom( );
//           // CartablePage.CartableOpenDraft( );
//           // DraftPage.DraftPageLoad( );
//           // DraftPage.OpenSuccedMemorandomDraft( );
//           // MemorandomDraftPage.LoadMemorandomDraftList( );
//            IWebElement title =
//                Driver.Instance.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
//            Assert.AreEqual( true, title.Displayed );



// }
#endregion
*/
        internal static void VerifyLoadCreationMemorandomPage( )
        {
            string CreationMemorandomPage = "CreationMemorandomPage.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{CreationMemorandomPage}";
            IWebElement creationMemorandomPage = Driver.Instance.WaitForLoadAnElementById( "inputs" , "Memorandom Creation Page" );
            Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(creationMemorandomPage);

            if( !File.Exists( filePath ) )
            {
                bmpPageScreenshot.Save( filePath );
            }

            Bitmap bmpCreationMemorandomPageImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpCreationMemorandomPageImage, bmpPageScreenshot);
            ErrorDetector.Detect();
            Assert.That( result , Is.True );
        }
    }
}




