using OpenQA.Selenium;
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
	[TestFixture]
    public class CartableSenario : SenarioTestBase
    {
       [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void FollowUpLoad( Memorandom memorandom )
        {
            ShellSenario.CartableLoad();
            CartablePage.ClickOnFollowUpPanel( );
            FollowUpCartablePage.VerifyFollowUpCartablePageIsLoadedCorrectly();
        }

        /*[Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void LoadMemorandomCreationPage( Memorandom memorandom )
        {
            ShellSenario.CartableLoad();
            CartablePage.OpenCreationMemorandomPage( );
            MemorandomPage.EnsureCreationMemorandomPageReady();
        }*/

         [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void DraftLoad( Memorandom memorandom )
        {
            ShellSenario.CartableLoad();
            CartablePage.OpenServices();
            CartablePage.ClickOnDraftPanel( );
            DraftPage.DraftPanelLoad();
        }

        //we cant run this test alone
       //  [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void BackToShell(Memorandom memorandom,IWebDriver webDriver )
        {
            ShellPage.ClickOnOfficeAutomation( );
            CartablePage.VerifyLoadCartable();
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad(webDriver);
        }

        [Test]
        public static void LoadFormList()
        {
            ShellSenario.CartableLoad( );
            CartablePage.OpenFormList();
            FormPage.EnsureFormListIsLoaded();
        }

       
    }
}
