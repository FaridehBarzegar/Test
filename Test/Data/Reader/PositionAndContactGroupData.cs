using Aspose.Cells;
using Payvast.OATest.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;

namespace Payvast.OATest.Data.Reader;
public class PositionAndContactGroupData
{
	 private static IEnumerable<PositionAndContactGroup> s_GroupsData = new List<PositionAndContactGroup>();
        public static IEnumerable<PositionAndContactGroup> S_GroupsData
        {
            get
            {
                if (!s_GroupsData.Any())
                {
                    s_GroupsData = GetRandomGroupData();
                }
                return s_GroupsData;
            }
            private set
            {
                s_GroupsData = value;
            }
        }
        public static IEnumerable<PositionAndContactGroup> GetRandomGroupData(int count = 1)
        {
            ReadReferReasonFromExcell();
            List<PositionAndContactGroup>   groups = new List<PositionAndContactGroup>();
            for (int i = 0; i < count; i++)
            {
                int num = new Random().Next(0, s_GroupsData.Count() - 1);
                groups.Add(s_GroupsData.ToArray()[num]);
            }
            return groups;
        }

        public static IEnumerable<PositionAndContactGroup> ReadReferReasonFromExcell( )
        {
            Workbook workbook = new Workbook(@"C:\Users\Administrator\source\repos\Test\Test\Data\Data.xlsx");
            Worksheet worksheet = workbook.Worksheets["گروه پست سازمانی و طرف مکاتبه"];
            int rowCount = worksheet.Cells.Rows.Count;
            List<PositionAndContactGroup> groups = new List<PositionAndContactGroup>();
            for( int i = 1 ; i < rowCount ; i++ )
            {
                int colIndex = 0;
                groups.Add( new PositionAndContactGroup
                {
                    UserLogin = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    PositionGroupTitle = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    PositionMember = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    SearchKeyText = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    ContactGroupTitle = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    ContactMember = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    SearckKeyContact = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    ContactFullName = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                } );
            }
            S_GroupsData = groups;
            return groups;
        }
    }

