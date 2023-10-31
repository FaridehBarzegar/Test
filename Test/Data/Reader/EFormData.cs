using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;

namespace Test.Data.ReadData
{
    public class FormData
    {
        private static IEnumerable<Form> s_FormmData = new List<Form>();
        public static IEnumerable<Form> S_FormData
        {
            get
            {
                if (!s_FormmData.Any())
                {
                    s_FormmData = GetRandomFormsData();
                }
                return s_FormmData;
            }
            private set
            {
                s_FormmData = value;
            }
        }

       public static IEnumerable<Form> GetRandomFormsData(int count = 1)
        {
            ReadFormFromExcell();
            List<Form> forms = new List<Form>();
            for (int i = 0; i < count; i++)
            {
                int num = new Random().Next(0, s_FormmData.Count() - 1);
                forms.Add(s_FormmData.ToArray()[num]);
            }
            return forms;
        }

        public static IEnumerable<Form> ReadFormFromExcell( )
        {
            Workbook workbook = new Workbook(@"C:\Users\Administrator\source\repos\Test\Test\Data\Data.xlsx");
            Worksheet worksheet = workbook.Worksheets["فرم اطلاعات پرسنل"];
            int rowCount = worksheet.Cells.Rows.Count;
            List<Form> forms = new List<Form>();
            for( int i = 1 ; i < rowCount ; i++ )
            {
                int colIndex = 0;
                forms.Add( new Form
                {
                    UserLogin = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    FormTitle = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    FullName = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    PersonnelCode = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    Age = Int32.Parse( worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ),
                    DateOfBirth = worksheet.Cells[i , colIndex++].Value?.ToString().Trim(),
                    NationalCode = worksheet.Cells[i , colIndex++].Value?.ToString().Trim(),
                    FathersName = worksheet.Cells[i , colIndex++].Value?.ToString().Trim(),
                    JoinDate = worksheet.Cells[i , colIndex++].Value?.ToString().Trim(),
                    Gender = worksheet.Cells[i , colIndex++].Value?.ToString().Trim(),
                    Degree = worksheet.Cells[i , colIndex++].Value?.ToString().Trim(),
                    PhoneNumber = worksheet.Cells[i , colIndex++].Value?.ToString().Trim(),
                    StartStep = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    FirstStep = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    EndStep   = worksheet.Cells[i , colIndex++].Value?.ToString().Trim()
                } );
            }
            S_FormData = forms;
            return forms;
        }
    }
}
