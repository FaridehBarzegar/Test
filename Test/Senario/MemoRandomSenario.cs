using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Data.Object;
using Test.Pages;
using Test.Support;

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
            memorandomPage.MemorandomSave( memorandom );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithImportance( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSaveWithImportance( memorandom );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithTranscriptReciver( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSaveWithTranscriptReciver( memorandom );
            cartablePage.CartableBackToShell( );
        } 
        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveWithTranscriptReciver2( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSaveWithTranscriptReciver2( memorandom );
            cartablePage.CartableBackToShell( );
        } 

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSaveSelectTranscriptFromChart( Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSaveSelectTranscriptFromChart( memorandom );
            cartablePage.CartableBackToShell( );
        } 

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.S_MemorandomData))]
        public void MemorandomSend(Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.MemorandomSend(memorandom);
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.ReadMemorandomFromExcell))]
        public void MemorandomSaveAndSend(Memorandom memorandom )
        {
            CartablePage cartablePage;
            MemorandomPage memorandomPage;
            OpenNewMemorandomPage( out cartablePage, out memorandomPage );
            memorandomPage.SaveAndSendNewMemorandom( memorandom);
            cartablePage.CartableBackToShell( );
        }
       
    }
}
