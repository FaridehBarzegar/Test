using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Data.Objects;
using Test.Pages;
using Test.Support;
using System.Runtime.InteropServices;

namespace Test.Senario
{
    public class MemorandomSenario : AutomationSenarioBase
    {
         private void OpenNewMemorandomPage( out CartablePage cartablePage, out MemorandomPage memorandomPage )
        {
            cartablePage = new CartablePage( driver );
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenCreateMemorandom( );
            memorandomPage = new MemorandomPage( driver );
            memorandomPage.MemorandomCreateLoadPage( );
        }

        [Test]
        public void MemorandomCreateLoadPage( )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSave( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSave( memorandom , objectPiker );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithImportance( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSaveWithImportance( memorandom , objectPiker );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithTranscriptReciver( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSaveWithTranscriptReciver( memorandom , objectPiker );
            cartablePage.CartableBackToShell( );
        } 
        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithTranscriptReciver2( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            //ObjectPiker reciver = ObjectPikerData.GetRandomRecivers().First();
            memorandomPage.MemorandomSaveWithTranscriptReciver2( memorandom , objectPiker );
            cartablePage.CartableBackToShell( );
        } 

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveSelectReciversFromChartAndPersonalList( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSaveSelectReciversFromChartAndPersonalList( memorandom , objectPiker );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithPrepareContent( Memorandom memorandom  )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            ReadyText readyText= ReadyTextData.FindReadyTextByUserName(  objectPiker.userLogin );
            memorandomPage. MemorandomSavewithPrepareContent( memorandom, readyText , objectPiker );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithTranscriptOrderFromReferralCommand( Memorandom memorandom  )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            string referralCommnd = UserSettingData.FindRandomReferralCommandByUserName( objectPiker.userLogin );
            memorandomPage.MemorandomSaveWithTranscriptOrderFromReferralCommand( memorandom, objectPiker , referralCommnd );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveSelectMemorandomAttachment( Memorandom memorandom  )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage. MemorandomSaveSelectMemorandomAttachment( memorandom , objectPiker );
            cartablePage.CartableBackToShell( );
        }

         [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSend(Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            ObjectPiker reciver = ObjectPikerData.GetRandomRecivers( ).First();
            memorandomPage.MemorandomSend(memorandom , reciver);
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveAndSend(Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            ObjectPiker reciver = ObjectPikerData.GetRandomRecivers().First();
            memorandomPage.SaveAndSendNewMemorandom( memorandom , reciver);
            cartablePage.CartableBackToShell( );
        }
       
    }
}
