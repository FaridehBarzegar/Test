using Aspose.Cells;
using Test.Data.Objects;

namespace Test.Data.ReadData
{
    public static class ReasonData
    {
        private static IEnumerable<Reason> s_ReasonData = new List<Reason>();
        public static IEnumerable<Reason> S_ReasonData
        {
            get
            {
                if (!s_ReasonData.Any())
                {
                    s_ReasonData = GetRandomReasonData();
                }
                return s_ReasonData;
            }
            private set
            {
                s_ReasonData = value;
            }
        }
        public static IEnumerable<Reason> GetRandomReasonData(int count = 1)
        {
            ReadReasonFromExcell();
            List<Reason>   settings = new List<Reason>();
            for (int i = 0; i < count; i++)
            {
                int num = new Random().Next(0, s_ReasonData.Count() - 1);
                settings.Add(s_ReasonData.ToArray()[num]);
            }
            return settings;
        }

        public static IEnumerable<Reason> ReadReasonFromExcell( )
        {
            Workbook workbook = new Workbook(@"C:\Users\Administrator\source\repos\Test\Test\Data\Data.xlsx");
            Worksheet worksheet = workbook.Worksheets["عبارات پرکاربرد"];
            int rowCount = worksheet.Cells.Rows.Count;
            List<Reason> settings = new List<Reason>();
            for( int i = 1 ; i < rowCount ; i++ )
            {
                int colIndex = 0;
                settings.Add( new Reason
                {
                    UserLogin = worksheet.Cells[i , colIndex++].Value?.ToString().Trim() ,
                    ReferReson = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    ActionReason = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    PreparedContentTitle = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                    PreparedContentDiscreption = worksheet.Cells[i,colIndex++].Value?.ToString().Trim(),
                } );
            }
            S_ReasonData = settings;
            return settings;
        }
    }
}
