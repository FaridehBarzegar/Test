using OpenQA.Selenium;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Pages;
using Test.Senario;
using Test.Tools.Senario;

namespace Payvast.OATest.Test;
public class FormTest:TestsBase
{
	 /// <summary>
        /// نمایش صفحه ایجاد فرم اداری کارکنان
        /// </summary>
        /// <param name="Form"></param>
        [Test, TestCaseSource( typeof( FormData ) , nameof( FormData.S_FormData ))]
        [Order( 1000 )]
        public static void LoadKarkonanCreationFormPage( Form Form )
        {
            CartableSenario.LoadFormList( );
            CartablePage.ClickOnKarkonanFormFromFormsList( );
            FormPage.VerifyFormImageDisplay( );
        }

        /// <summary>
        /// ذخیره فرم اداری کارکنان
        /// </summary>
        /// <param name="Form"></param>
        [Test, TestCaseSource( typeof( FormData ) , nameof( FormData.S_FormData ) )]
        [Order( 2000 )]
        public static void SaveKarkonan( Form Form )
        {
            LoadKarkonanCreationFormPage( Form );
            FormPage.SetPersonnelInformationFormFields( Form );
            FormPage.ClickOnSaveButton();
            FormPage.SetFormTitle( Form.FormTitle );
            FormPage.AcceptSaveAlert();
            FormPage.VerifyFormFieldSave( Form );
            CartablePage.OpenServices();
            CartablePage.ClickOnDraftPanel();
            DraftPage.DraftPanelLoad();
            DraftPage.ClickOnFormDraftPanel();
            FormDraftPage.FormDraftPanelLoad();
            FormDraftPage.VerifyFormSaveInDraft(Form.FormTitle);
            FormDraftPage.ClickOnFormViewCommand( Form );
            FormDraftPage.VerifyFormFieldsSave( Form );
        }

        /// <summary>
        ///  ایجاد و تایید فرم اداری کارکنان
        /// </summary>
        /// <param name="Form"></param>
       // [Test, TestCaseSource( typeof( FormData ) , nameof( FormData.S_FormData ) )]
       // [Order( 3000 )]
        public static void CreateAndConfirmKarkonanFormInCreationStage( Form Form , IWebDriver webDriver )
        {
            LoadKarkonanCreationFormPage( Form );
            FormPage.SetPersonnelInformationFormFields( Form );
            FormPage.ClickOnConfirmCommand();
            FormPage.SetFormTitleInConfirmation( Form.FormTitle );
            FormPage.AcceptSendAlert();
            CartablePage.VerifyLoadCartable();
            CartablePage.ClickOnFollowUpPanel();
            FollowUpCartablePage.VerifyFollowUpCartablePageIsLoadedCorrectly();
            FollowUpCartablePage.VerifyFormIsSendCorrectly(Form.FormTitle);
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad( webDriver );
        }

        /// <summary>
        /// رسیدگی فرم اداری در مرحله اول
        /// </summary>
        /// <param name="Form"></param>
        //[Test, TestCaseSource( typeof( FormData ) , nameof( FormData.S_FormData ) )]
        //[Order( 4000 )]
        public static void ConfirmKarkonanFormInFirstStage( Form Form,IWebDriver webDriver )
        {
            CreateAndConfirmKarkonanFormInCreationStage( Form,webDriver );
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("razaghian");
            LoginSenario.LoginSucceed( userLogin,webDriver );
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( Form );
            CartablePage.ClickOnForm( Form );
            CartablePage.VerifyFormCommandIsLoadCorrectly();
            CartablePage.ClickOnFormAccept(Form);
            FormPage.VerifyFormFieldSave( Form );
            FormPage.ClickOnConfirmCommand();
            FormPage.AcceptConfirmationAlert();
            CartablePage.VerifyLoadCartable();
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad(webDriver);
        }

        /// <summary>
        /// رسیدگی فرم اداری در مرحله خاتمه
        /// </summary>
        /// <param name="Form"></param>
       // [Test, TestCaseSource( typeof( FormData ) , nameof( FormData.S_FormData ) )]
       // [Order( 5000 )]
        public static void ConfirmKarkonanFormInFinalStage( Form form,IWebDriver webDriver )
        {
            //ConfirmKarkonanFormInFirstStage( form );
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("ahmadi");
            LoginSenario.LoginSucceed( userLogin, webDriver);
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( form );
            CartablePage.ClickOnForm( form );
            CartablePage.VerifyFormCommandIsLoadCorrectly();
            CartablePage.ClickOnFormAccept(form);
            FormPage.VerifyFormFieldSave( form );
            FormPage.ClickOnConfirmCommand();
            FormPage.AcceptConfirmationAlert();
            CartablePage.VerifyEntityInCartableListSelect();
            CartablePage.VerifyKarkonanFormComplete( form.FormTitle );
        }

        /// <summary>
        /// عدم تایید فرم اداری کارکنان
        /// </summary>
        /// <param name="Form"></param>
        // [Test, TestCaseSource( typeof( FormData ) , nameof( FormData.S_FormData ) )]
         //[Order(7000)]
        public static void RejectKarkonanForm( Form form, IWebDriver webDriver )
        {
           // ConfirmKarkonanFormInFirstStage( form );
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("ahmadi");
            LoginSenario.LoginSucceed( userLogin,webDriver );
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( form );
            CartablePage.ClickOnForm( form );
            CartablePage.VerifyFormCommandIsLoadCorrectly();
            CartablePage.ClickOnFormAccept(form);
            FormPage.VerifyFormFieldSave( form );
            FormPage.ClickOnRejectButton();
            FormPage.AcceptRejectionAlert();
            CartablePage.VerifyLoadCartable();
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad( webDriver );
            ShellPage.ClickOnExit();
            userLogin = LoginData.FindUserByUserName( "razaghian" );
            LoginSenario.LoginSucceed( userLogin,webDriver );
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( form );
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad( webDriver );
        }

        /// <summary>
        /// رسیدگی فرم اداری در مرحله مسئول دفتر در جستجو عادی 
        /// </summary>
        /// <param name="Form"></param>
       // [Test, TestCaseSource( typeof( FormData ) , nameof( FormData.S_FormData ) )]
       // [Order( 6000 )]
        public static void ConfirmKarkonanFormInSearch( Form form ,IWebDriver webDriver)
        {
            CreateAndConfirmKarkonanFormInCreationStage( form ,webDriver );
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("razaghian");
            LoginSenario.LoginSucceed( userLogin,webDriver );
            ShellSenario.CartableLoad();
            CartablePage.ClickOnSearchText();
            CartablePage.SendKeysSearchText(form.FormTitle);
            SearchPage.VerifyResultOfSearchPageIsLoadedCorrectly();
            IWebElement FormRecived= SearchPage.VerifyFormIsFindInSearchResult(form.FormTitle);
            SearchPage.ClickOnFormInSearchResult( FormRecived );
            SearchPage.VerifyFormCammandsLoadInSearchResult();
            SearchPage.ClickOnFormAccept(form);
            FormPage.VerifyFormFieldSave( form );
            FormPage.ClickOnConfirmCommand();
            FormPage.AcceptConfirmationAlert();
            SearchPage.VerifyResultOfSearchPageIsLoadedCorrectly();
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad( webDriver );
            ShellPage.ClickOnExit();
            userLogin = LoginData.FindUserByUserName( "ahmadi" );
            LoginSenario.LoginSucceed( userLogin,webDriver );
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( form );
        }

      /// <summary>
      /// نمایش صحیح دستور "‫عدم تاييد فرم"
      /// </summary>
      /// <param name="Form"></param>
      // [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
      // [Order(8000)]
        public static void VerifyWILListCommentForRejectedForm(Form Form )
        {
           // RejectKarkonanForm(Form);
            CartablePage.VerifyWILListCommentForRejectedForm(Form);
        }

        /// <summary>
        /// نمایش صحیح دستور "جهت رسیدگی"
        /// </summary>
        /// <param name="Form"></param>
       // [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
       // [Order(9000)]
        public static void VerifyWIllListCommentForConfirmedForm(Form form,IWebDriver webDriver )
        {
           // ConfirmKarkonanFormInFirstStage(form);
            UserLogin userLogin =LoginData.FindUserByUserName(form.UserLogin);
            ShellPage.ClickOnExit();
            userLogin = LoginData.FindUserByUserName(form.UserLogin);
            LoginSenario.LoginSucceed(userLogin,webDriver);
            ShellSenario.CartableLoad();
            CartablePage.VerifyWillListCommentForConfirmedForm(form);
        }

        /// <summary>
        ///  نمایش صفحه رسیدگی تجمیعی
        /// </summary>
        /// <param name="Form"></param>
      //  [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
      //  [Order(10000)]
        public static void LoadBatchAcceptPage(Form form, IWebDriver webDriver )
        {
            ShellSenario.CartableLoad( );
            for(int i =0; i < 3; i++ )
            {
                CartablePage.OpenFormList();
                FormPage.EnsureFormListIsLoaded();
                CartablePage.ClickOnKarkonanFormFromFormsList( );
                FormPage.VerifyFormImageDisplay();
                FormPage.SetPersonnelInformationFormFields( form );
                FormPage.ClickOnConfirmCommand();
                FormPage.SetFormTitleInConfirmation( form.FormTitle );
                FormPage.AcceptSendAlert();
                CartablePage.VerifyLoadCartable();
                CartablePage.ClickOnFollowUpPanel();
                FollowUpCartablePage.VerifyFollowUpCartablePageIsLoadedCorrectly();
                FollowUpCartablePage.VerifyFormIsSendCorrectly(form.FormTitle);
                CartablePage.ClickOnInboxPanel();
                CartablePage.VerifyLoadCartable();
            }
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad(webDriver);
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("razaghian");
            LoginSenario.LoginSucceed(userLogin, webDriver);
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable(form);
            CartablePage.ClickOnFirstThreForms(form);
            CartablePage. VerifyChosenFormsCommandsDisplayCorrectly();
            CartablePage.ClickOnFormBatchAcceptCommand();
            FormBatchAcceptPage.VerifyFormBatchAcceptPageLoad(form);
        }

        /// <summary>
        /// رسیدگی تجمیعی فرم اداری
        /// </summary>
        /// <param name="Form"></param>
        [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
        [Order(11000)]
        public static void BatchAccept(Form form )
        {
          //  LoadBatchAcceptPage(form);
            FormBatchAcceptPage.ClickOnStartBathAccept();
            FormBatchAcceptPage.VerifyBathAcceptOprationDone();
        }

        /// <summary>
        /// رسیدگی فرم اداری در جستجو پیشرفته
        /// </summary>
        /// <param name="Form"></param>
      //  [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
       // [Order(12000)]
        public static void ConfirmFormInAdvancedSearch(Form form, IWebDriver webDriver )
        {
            CreateAndConfirmKarkonanFormInCreationStage(form,webDriver);
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("razaghian");
            LoginSenario.LoginSucceed(userLogin, webDriver);
            ShellSenario.CartableLoad();
            CartablePage.ClickOnSearchText();
            CartablePage.ClickOnAdvancedSearch();
            SearchPage.VerifyLoadAdvancedSearchPage();
            SearchPage.ClickOnFormOptions();
            SearchPage.VerifyLoadFormAdvancedPage();
            SearchPage.FillSearchText();
            SearchPage.SetFormAttributes(form);
            SearchPage.ClickOnSearchCommand();
            SearchPage.VerifyResultOfSearchPageIsLoadedCorrectly();
            IWebElement formRecived= SearchPage.VerifyFormIsFindInAdvancedSearchResult(form.FormTitle);
            SearchPage.ClickOnFormInSearchResult( formRecived );
            SearchPage.VerifyFormCammandsLoadInSearchResult();
            SearchPage.ClickOnFormAccept(form);
            FormPage.VerifyFormFieldSave(form );
            FormPage.ClickOnConfirmCommand();
            FormPage.AcceptConfirmationAlert();
            SearchPage.VerifyResultOfSearchPageIsLoadedCorrectly();
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad(webDriver);
            ShellPage.ClickOnExit();
            userLogin = LoginData.FindUserByUserName( "ahmadi" );
            LoginSenario.LoginSucceed( userLogin,webDriver);
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( form );
        }

       /// <summary>
       /// رسیدگی تجمیعی فرم اداری در جستجوعادی
       /// </summary>
       /// <param name="Form"></param>
       // [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
      //  [Order(13000)]
        public static  void BatchAcceptInSearch( Form form,IWebDriver webDriver )
        {
            CreateAndConfirmKarkonanFormInCreationStage( form , webDriver );
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("razaghian");
            LoginSenario.LoginSucceed(userLogin, webDriver);
            ShellSenario.CartableLoad();
            CartablePage.ClickOnSearchText();
            CartablePage.SendKeysSearchText(form.FormTitle);
            SearchPage.VerifyResultOfSearchPageIsLoadedCorrectly();
            IWebElement FormRecived= SearchPage.VerifyFormIsFindInSearchResult(form.FormTitle);
            SearchPage.ClickOnFormInSearchResult( FormRecived );
            SearchPage.VerifyFormCammandsLoadInSearchResult();
            SearchPage.ClickOnFormBatchAcceptCommand(form);
            FormBatchAcceptPage.VerifyFormBatchAcceptPageLoad(form);
            FormBatchAcceptPage.ClickOnStartBathAccept();
            FormBatchAcceptPage.VerifyBathAcceptOprationDone();
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad(webDriver );
            ShellPage.ClickOnExit();
            userLogin = LoginData.FindUserByUserName( "ahmadi" );
            LoginSenario.LoginSucceed( userLogin,webDriver );
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( form );
        }

        /// <summary>
        /// رسیدگی تجمیعی فرم اداری در جستجو پیشرفته
        /// </summary>
        /// <param name="form"></param>
       // [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
       // [Order(14000)]
        public static void BatchAcceptInAdvancedSearch(Form form, IWebDriver webDriver )
        {
            CreateAndConfirmKarkonanFormInCreationStage( form,webDriver );
            ShellPage.ClickOnExit();
            UserLogin userLogin = LoginData.FindUserByUserName("razaghian");
            LoginSenario.LoginSucceed(userLogin, webDriver);
            ShellSenario.CartableLoad();
            CartablePage.ClickOnSearchText();
            CartablePage.ClickOnAdvancedSearch();
            SearchPage.VerifyLoadAdvancedSearchPage();
            SearchPage.ClickOnFormOptions();
            SearchPage.VerifyLoadFormAdvancedPage();
            SearchPage.FillSearchText();
            SearchPage.SetFormAttributes(form);
            SearchPage.ClickOnSearchCommand();
            SearchPage.VerifyResultOfSearchPageIsLoadedCorrectly();
            IWebElement FormRecived= SearchPage.VerifyFormIsFindInAdvancedSearchResult(form.FormTitle);
            SearchPage.ClickOnFormInSearchResult( FormRecived );
            SearchPage.VerifyFormCammandsLoadInSearchResult();
            SearchPage.ClickOnFormBatchAcceptCommand(form);
            FormBatchAcceptPage.VerifyFormBatchAcceptPageLoad(form);
            FormBatchAcceptPage.ClickOnStartBathAccept();
            FormBatchAcceptPage.VerifyBathAcceptOprationDone();
            CartablePage.BackToShell();
            ShellPage.VerifyShellPageLoad(webDriver);
            ShellPage.ClickOnExit();
            userLogin = LoginData.FindUserByUserName( "ahmadi" );
            LoginSenario.LoginSucceed( userLogin, webDriver );
            ShellSenario.CartableLoad();
            CartablePage.VerifyKarkonanFormReciveInCartable( form );
        }

        [Test , TestCaseSource(typeof(FormData),nameof(FormData.S_FormData))]
        [Order(15000)]
        public static void CheckConditionOfAgeInStageForm(Form form )
        {
            LoadKarkonanCreationFormPage(form);
            FormPage.SetPersonnelInformationFormFields(form);
            FormPage.SetInvalidValueOfPersonnelInformationAgeField();
            FormPage.ClickOnConfirmCommand();
            FormPage.SetFormTitleInConfirmation( form.FormTitle );
            FormPage.VerifyNotifyConditionAlert();
        }
}
