using Aspose.Cells;
using Newtonsoft.Json;
using NUnit.Framework.Internal.Execution;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;

namespace Test.Data.ReadData
{
    public class LoginData
    {
        public static UserLogin? FindUserByUserName(string username)
        {
            //IEnumerable<UserLogin> users = roots;
            return users.FirstOrDefault(u => u.UserName == username);
        }
        public static UserLogin userLoginAhmadi = new UserLogin()
        {
            UserName = "ahmadi",
            Password = "1"
        };
        public static UserLogin userLoginRahimi = new UserLogin()
        {
            UserName = "rahimi",
            Password = "1"
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
         },
        {
           'userName':'niknam',
           'password':'1'
        }
        ]";
       // public static IEnumerable<UserLogin> roots = JsonConvert.DeserializeObject<IEnumerable<UserLogin>>(json);
       public static IEnumerable<UserLogin> users = ReadExcell();
        private static IEnumerable<UserLogin> s_userLoginsData = new List<UserLogin>();
        public static IEnumerable<UserLogin> S_UserLoginData
        {
            get
            {
                if (!s_userLoginsData.Any())
                {
                    s_userLoginsData = GetRandomUsers();
                }
                return s_userLoginsData;
            }
            private set
            {
                s_userLoginsData = value;
            }
        }
        public static IEnumerable<UserLogin> GetRandomUsers(int count = 1)
        {

            ReadExcell();
            List<UserLogin> userLogins = new List<UserLogin>();
            for (int i = 0; i < count; i++)
            {
                int num = new Random().Next(0, S_UserLoginData.Count() - 1);
                userLogins.Add(S_UserLoginData.ToArray()[num]);
            }
            return userLogins;
        }
        public static IEnumerable<UserLogin> ReadExcell()
        {
            Workbook workbook = new Workbook("C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx");
            Worksheet worksheet1 = workbook.Worksheets[0];
            int rowCount = worksheet1.Cells.MaxDataRow;
            List<UserLogin> userLogins = new List<UserLogin>();

            for (int i = 1; i < rowCount; i++)
            {
                userLogins.Add(new UserLogin
                {
                    UserName = worksheet1.Cells[i, 0].Value?.ToString().Trim(),
                    Password = worksheet1.Cells[i, 1].Value?.ToString().Trim()
                });
            }
            S_UserLoginData = userLogins;
            return userLogins;
        }
    }
}
