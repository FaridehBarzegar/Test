using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data
{
    public static class LoginData
    {
      public static UserLogin FindUserByUserName( string username )
        {
           IEnumerable<UserLogin> users = roots;
            return  users.Where(u=>u.userName==username).FirstOrDefault();
           // return users.Contains((new UserLogin { userName=userName }));
                


        }
        public static UserLogin userLoginAhmadi = new UserLogin()
       {
           userName="ahmadi",
           password="1"
       }; public static UserLogin userLoginRahimi = new UserLogin()
       {
           userName="rahimi",
           password="1"
       };
       static string json = @"[
        {
          'userName': 'ahmadi',
          'password': 1
        },
        { 'userName': 'administrator',
          'password': 1
        },  
        {
          'userName': 'rahimi',
          'password': '1'
         },
        {
          'userName': 'fatemi',
          'password': '1'
         },
        {
          'userName': 'razaghian',
          'password': '1'
         },
{
          'userName': 'asadi',
          'password': '1'
         }
        ]";
       public   static IEnumerable<UserLogin> roots = JsonConvert.DeserializeObject <IEnumerable<UserLogin>>(json);
    
       
       
        public static IEnumerable<UserLogin [ ]> ReadExcell( )
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo existingFile = new FileInfo("C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx");
          
            using ( ExcelPackage package = new ExcelPackage( existingFile )  )
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["LoginSuccess"];
                int rowCount = worksheet.Dimension.End.Row;
                // List<UserLogin> loginsuser = new List<UserLogin>();
                for ( int i = 2 ; i <= rowCount ; i++ )
                {
              UserLogin[] users = new UserLogin[]
                {
                  new UserLogin
                    {
                        userName = worksheet.Cells[ i, 1 ].Value?.ToString( ).Trim(),
                        password = worksheet.Cells[ i, 2 ].Value?.ToString( ).Trim(),
                    }
                };
                     yield  return users;
                   // yield return new object[ ]
                  //UserLogin login = new UserLogin()
                  //  {
                  //    userName=  worksheet.Cells[ i, 1 ].Value?.ToString( ).Trim(),
                  //     password= worksheet.Cells[ i, 2 ].Value?.ToString( ).Trim()

                  //  };
                   
            }
                  
        } }
        public static object[] LoginTestData=
        {
               new object[]{ "ahmadi", "1" },
               new object[]{"administrator", "1" },
               new object[]{ "fatemi", "1" }

         };
    }
}
