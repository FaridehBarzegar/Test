
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Pages;
using Test.Tools.Senario;

namespace Test.Senario
{
	public class MemorandomSenario : SenarioTestBase
    {
       /* [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void Save( Memorandom memorandom )
        {
            
            CartablePage cartablePage = new CartablePage( WebDriver );
            MemorandomPage memorandomPage = new MemorandomPage( memorandom , WebDriver );
            CartableSenario.LoadMemorandomCreationPage( memorandom);
            memorandomPage.SetReciver();
            memorandomPage.SetTitle();
            memorandomPage.SetDescription();
            memorandomPage.Save();
            cartablePage.OpenServices();
            DraftPage draftPage = cartablePage.ClickOnDraftPanel( );
            draftPage.DraftPanelLoad();
            MemorandomDraftPage memorandomDraftPage = draftPage.ClickOnMemorandomDraftPanel( );
            memorandomDraftPage.EnsureMemorandomDraftPageReady();
            memorandomDraftPage.EnsureMemorandomISSave( memorandom.MemorandomTitle );
            
        }

        [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void Send( Memorandom memorandom )
        {
            MemorandomPage memorandomPage = new MemorandomPage(memorandom , WebDriver );
            CartableSenario.LoadMemorandomCreationPage( memorandom );
            memorandomPage.SetReciver();
            memorandomPage.SetTitle();
            memorandomPage.SetDescription();
            memorandomPage.Send();
            CartablePage cartablePage = new CartablePage( WebDriver );
            cartablePage.VerifyCartableLoad();
            FollowUpCartablePage followUpCartablePage = cartablePage.ClickOnFollowUpPanel( );
            followUpCartablePage.VerifyFollowUpCartablePageIsLoadedCorrectly();
            followUpCartablePage.EnsureMemorandomISSend( memorandom );
            ShellPage shellPage = cartablePage.BackToShell( );
            shellPage.VerifyShellPageLoad();
            shellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName( memorandom.UserLoginReciver );
            LoginSenario.LoginSucceed( userLogin );
            ShellSenario.CartableLoad();
            cartablePage.EnsureMemorandomIsRecived( memorandom.MemorandomTitle );
        }

        [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void SaveAndSend( Memorandom memorandom )
        {
            MemorandomPage memorandomPage = new MemorandomPage( memorandom, WebDriver );
            CartableSenario.LoadMemorandomCreationPage( memorandom);
            memorandomPage.SetReciver(  );
            memorandomPage.SetTitle(  );
            memorandomPage.SetDescription(  );
            memorandomPage.Save();
            memorandomPage.Send();
            CartablePage cartablePage = new CartablePage( WebDriver );
            cartablePage.VerifyCartableLoad();
            FollowUpCartablePage followUpCartablePage = cartablePage.ClickOnFollowUpPanel( );
            followUpCartablePage.VerifyFollowUpCartablePageIsLoadedCorrectly();
            followUpCartablePage.EnsureMemorandomISSend( memorandom );
            ShellPage shellPage = cartablePage.BackToShell();
            shellPage.VerifyShellPageLoad();
            LoginPage loginPage = shellPage.ClickOnExit();
            loginPage.LoadPage();
            UserLogin userLogin = LoginData.FindUserByUserName( memorandom.UserLoginReciver );
            LoginSenario.LoginSucceed( userLogin );
            ShellSenario.CartableLoad();
            cartablePage.EnsureMemorandomIsRecived( memorandom.MemorandomTitle );
        }

        [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void SaveWithTransctiptReciver( Memorandom memorandom )
        {
            MemorandomPage memorandomPage = new MemorandomPage(  memorandom ,WebDriver );
            CartableSenario.LoadMemorandomCreationPage( memorandom);
            memorandomPage.SetReciver(  );
            memorandomPage.SetTranscriptReciver( memorandom );
            memorandomPage.SetTranscriptOrder( memorandom.TranscriptOrder );
            memorandomPage.SetTitle(  );
            memorandomPage.SetDescription(  );
            memorandomPage.Save();
            CartablePage cartablePage = new CartablePage( WebDriver );
            cartablePage.OpenServices();
            DraftPage draftPage = cartablePage.ClickOnDraftPanel( );
            draftPage.DraftPanelLoad();
            MemorandomDraftPage memorandomDraftPage = draftPage.ClickOnMemorandomDraftPanel( );
            memorandomDraftPage.EnsureMemorandomDraftPageReady();
            memorandomDraftPage.EnsureMemorandomISSave( memorandom.MemorandomTitle );
            MemorandomViewPage memorandomViewPage = new MemorandomViewPage( WebDriver);
            memorandomDraftPage.ClickMemorandomInList();
            memorandomViewPage = memorandomDraftPage.ClickOnViewCommand();
            memorandomViewPage.EnsureMemorandomViewPageLoadWithTranscriptReciver( memorandom.TranscriptReciver );
        }

        [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void SendWithTranscriptReciver( Memorandom memorandom )
        {
            CartableSenario.LoadMemorandomCreationPage(memorandom );
            MemorandomPage memorandomPage = new MemorandomPage(  memorandom ,WebDriver );
            memorandomPage.SetReciver(  );
            memorandomPage.SetTranscriptReciver( memorandom );
            memorandomPage.SetTranscriptOrder( memorandom.TranscriptOrder );
            memorandomPage.SetTitle(  );
            memorandomPage.SetDescription(  );
            memorandomPage.Send();
            CartablePage cartablePage = new CartablePage( WebDriver );
            cartablePage.VerifyCartableLoad();
            FollowUpCartablePage followUpCartablePage = cartablePage.ClickOnFollowUpPanel();
            followUpCartablePage.VerifyFollowUpCartablePageIsLoadedCorrectly();
            followUpCartablePage.EnsureMemorandomISSend( memorandom );
            ShellPage shellPage = cartablePage.BackToShell();
            shellPage.VerifyShellPageLoad();
            shellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName( memorandom.UserLoginTranscriptReciver );
            LoginSenario.LoginSucceed( userLogin );
            ShellSenario.CartableLoad();
            cartablePage.EnsureMemorandomIsRecived( memorandom.MemorandomTitle );
        }

        [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void SaveAndSendWithTranscriptReciver( Memorandom memorandom )
        {
            CartableSenario.LoadMemorandomCreationPage(memorandom);
            MemorandomPage memorandomPage = new MemorandomPage( memorandom , WebDriver );
            memorandomPage.SetReciver(  );
            memorandomPage.SetTranscriptReciver( memorandom );
            memorandomPage.SetTitle(  );
            memorandomPage.SetDescription(  );
            memorandomPage.Save();
            memorandomPage.Send();
            CartablePage cartablePage = new CartablePage( WebDriver );
            cartablePage.VerifyCartableLoad();
            FollowUpCartablePage followUpCartablePage = cartablePage.ClickOnFollowUpPanel();
            followUpCartablePage.VerifyFollowUpCartablePageIsLoadedCorrectly();
            followUpCartablePage.EnsureMemorandomISSend( memorandom );
            ShellPage shellPage = cartablePage.BackToShell();
            shellPage.VerifyShellPageLoad();
            shellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName( memorandom.UserLoginTranscriptReciver );
            LoginSenario.LoginSucceed( userLogin );
            ShellSenario.CartableLoad();
            cartablePage.EnsureMemorandomIsRecived( memorandom.MemorandomTitle );
        }

        [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void SaveWihAddTranscriptReciver( Memorandom memorandom )
        {
            MemorandomPage memorandomPage = new MemorandomPage( memorandom,  WebDriver );
            CartableSenario.LoadMemorandomCreationPage(memorandom);
            memorandomPage.SetReciver(  );
            memorandomPage.SetTranscriptReciver( memorandom );
            memorandomPage.SetTranscriptOrder( memorandom.TranscriptOrder );
            memorandomPage.ClickOnAddTranscriptReciver();
            memorandomPage.SetTranscriptReciver2( memorandom );
            memorandomPage.SetTranscriptOrder2( memorandom.TranscriptOrder2 );
            memorandomPage.SetTitle(  );
            memorandomPage.SetDescription(  );
            memorandomPage.Save();
            CartablePage cartablePage = new CartablePage( WebDriver );
            cartablePage.OpenServices();
            DraftPage draftPage = cartablePage.ClickOnDraftPanel( );
            draftPage.DraftPanelLoad();
            MemorandomDraftPage memorandomDraftPage = draftPage.ClickOnMemorandomDraftPanel( );
            memorandomDraftPage.EnsureMemorandomDraftPageReady();
            memorandomDraftPage.EnsureMemorandomISSave( memorandom.MemorandomTitle );
            MemorandomViewPage memorandomViewPage = new MemorandomViewPage( WebDriver);
            memorandomDraftPage.ClickMemorandomInList();
            memorandomViewPage = memorandomDraftPage.ClickOnViewCommand();
            memorandomViewPage.EnsureMemorandomViewPageLoad( memorandom );
            memorandomViewPage.EnsureMemorandomViewPageLoadWithTranscriptReciver( memorandom.TranscriptReciver2 );

        }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveWithImportance( Memorandom memorandom )
        // {
        //     //MemorandomPage.SaveWithImportance( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }



        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveWithTranscriptReciver( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SaveWithTranscriptReciver( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // } 
        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveWithTranscriptReciver2( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //ObjectPiker reciver = ObjectPikerData.GetRandomRecivers().First();
        //    // MemorandomPage.SaveWithTranscriptReciver2( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // } 

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveSelectReciversFromChartAndPersonalList( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage.SaveSelectReciversFromChartAndPersonalList( memorandom , objectPiker );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveWithPrepareContent( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     ReadyText readyText= ReadyTextData.FindReadyTextByUserName(  objectPiker.userLogin );
        //    // MemorandomPage. SavewithPrepareContent( memorandom, readyText , objectPiker );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveWithTranscriptOrderFromReferralCommand( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     string referralCommnd = UserSettingData.FindRandomReferralCommandByUserName( objectPiker.userLogin );
        //    // MemorandomPage.SaveWithTranscriptOrderFromReferralCommand( memorandom, objectPiker , referralCommnd );
        //     //CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveSelectMemorandomAttachment( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage. SaveSelectMemorandomAttachment( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }

        //  [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveWithoutTitle( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage. SaveWithoutTitle( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }  

        //[Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void CancelationOfSave( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage. SaveCanceled( memorandom , objectPiker , true );
        //    // CartablePage.BackToShell( );
        // }

        //  [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveWithoutCanceling( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage.SaveCanceled( memorandom , objectPiker , false );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void DeleteSavedMemorandom ( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage ( );
        //    // MemorandomPage. SaveThenDelete( memorandom , objectPiker , true );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void CancelToDeleteSavedMemorandom( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage. SaveThenDelete( memorandom , objectPiker , false );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SendWithTransciptReciver( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage.SendWithTransciptReciver( memorandom , objectPiker);
        //    // CartablePage.BackToShell( );
        // }
        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]

        // public void SendWithTranscriptReciver2( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage.SendWithTranscriptReciver2( memorandom , objectPiker);
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SendSelectReciversFromChartAndPersonnelList( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SendSelectReciversFromChartAndPersonalList( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SendWithPrepareContent( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     ReadyText readyText= ReadyTextData.FindReadyTextByUserName(  objectPiker.userLogin );
        //     //MemorandomPage. SendwithPrepareContent( memorandom, readyText , objectPiker );
        //     //CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SendSelectMemorandomAttachment( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage. SendSelectMemorandomAttachment( memorandom , objectPiker );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SendWithTranscriptOrderFromReferralCommand( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     string referralCommnd = UserSettingData.FindRandomReferralCommandByUserName( objectPiker.userLogin );
        //    // MemorandomPage.SendWithTranscriptOrderFromReferralCommand( memorandom, objectPiker , referralCommnd );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SendeWithImportance( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SendWithImportance( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }

        //  [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        //  public void CheckSendWithoutTitle( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SendWithoutTitle( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }
        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        //  public void CheckSendWithoutReciver( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //    CreateLoadPage( );
        //    // MemorandomPage.SendWithoutReciver( memorandom , objectPiker );
        //    // CartablePage.BackToShell( );
        // }

        ///* [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        //  public void SendWithoutAccessToRegisterBook( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     LoginPage loginPage = new LoginPage( driver );
        //     UserLogin userLogin = new UserLogin(){ userName="ebadi",password="1"};
        //     loginPage.LoginSucceed( userLogin );
        //     OpenNewMemorandomPage( out CartablePage, out memorandomPage );
        //     memorandomPage. SendWithoutAccessToRegisterBook( memorandom , objectPiker );
        //     CartablePage.BackToShell( );
        // }*/


        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendWithTransciptReciver( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage.SaveAndSendWithTransciptReciver( memorandom , objectPiker);
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendWithTranscriptReciver2( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SaveAndSendWithTranscriptReciver2( memorandom , objectPiker);
        //     //CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendReciversFromChartAndPersonnelList( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SaveAndSendSelectReciversFromChartAndPersonalList( memorandom , objectPiker);
        //     //CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendWithPrepareContent( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     ReadyText readyText= ReadyTextData.FindReadyTextByUserName(  objectPiker.userLogin );
        //    // MemorandomPage. SaveAndSendwithPrepareContent( memorandom, readyText , objectPiker );
        //    // CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendSelectMemorandomAttachment( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage. SaveAndSendSelectMemorandomAttachment( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendWithTranscriptOrderFromReferralCommand( Memorandom memorandom  )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     string referralCommnd = UserSettingData.FindRandomReferralCommandByUserName( objectPiker.userLogin );
        //   //  MemorandomPage.SaveAndSendWithTranscriptOrderFromReferralCommand( memorandom, objectPiker , referralCommnd );
        //   //  CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendeWithImportance( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;

        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SaveAndSendWithImportance( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }

        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SaveAndSendWithoutTranscriptFollowUp( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //    // MemorandomPage.SaveAndSendWithoutTranscriptFollowUp( memorandom , objectPiker );
        //    // CartablePage.BackToShell( );
        // }
        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SendWithoutTranscriptFollowUp( Memorandom memorandom )
        // {
        //     CartablePage CartablePage;
        //     MemorandomPage memorandomPage;
        //     CreateLoadPage( );
        //     //MemorandomPage.SendWithoutTranscriptFollowUp( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }
        // [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        // public void SucceedEditMemorandomField( Memorandom memorandom )
        // {


        //     //CartablePage.CartableLoad( );
        //     //MemorandomPage.MemorandomSucceedEdit( memorandom , objectPiker );
        //     //CartablePage.BackToShell( );
        // }

    }
}
