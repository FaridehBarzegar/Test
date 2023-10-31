using Aspose.Cells;
using Test.Data.Objects;

namespace Test.Data.ReadData
{
    public static class MemorandomData
    {
        private static IEnumerable<Memorandom> s_memorandomData = new List<Memorandom>();
        public static IEnumerable<Memorandom> S_MemorandomData
        {
            get
            {
                if (!s_memorandomData.Any())
                {
                    s_memorandomData = GetRandomMemorandoms();
                }
                return s_memorandomData;
            }
            private set
            {
                s_memorandomData = value;
            }
        }

        public static IEnumerable<Memorandom> GetRandomMemorandoms(int count = 1)
        {
            ReadMemorandomFromExcell();
            List<Memorandom> memorandoms = new List<Memorandom>();
            for (int i = 0; i < count; i++)
            {
                int num = new Random().Next(0, s_memorandomData.Count() - 1);
                memorandoms.Add(s_memorandomData.ToArray()[num]);
            }
            return memorandoms;
        }

        public static IEnumerable<Memorandom> ReadMemorandomFromExcell()
        {
            Workbook workbook = new Workbook("C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx");
            Worksheet worksheet = workbook.Worksheets["Memorandom"];
            int rowCount = worksheet.Cells.Rows.Count;
            List<Memorandom> memorandoms = new List<Memorandom>();
            for (int i = 1; i < rowCount; i++)
            {
                var colIndex = 0;
                memorandoms.Add(new Memorandom
                {
                    UserLogin = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    MemorandomTitle = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    Description = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    SearchReciver = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    Reciver = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    SearchReciverFromChart = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    ReciverFromChart = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    ReciverFromPersonnelList = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    TranscriptSearchReciver = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    TranscriptReciver = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    TranscriptOrder = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    SearchTranscriptReciverFromChart = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    TranscriptReciverFromChart = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    TranscriptReciverFromPersonnelList = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    SearchTranscriptReciver2 = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    TranscriptReciver2 = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    TranscriptOrder2 = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    SemilarMemorandom = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    FollowUpCompanion = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    Priority = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    FileAttachmentName = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    UserLoginReciver = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    UserLoginTranscriptReciver = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    ReadyTextTitle = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    ReadyTextDescription = worksheet.Cells[i, colIndex++].Value?.ToString().Trim(),
                    ReferralCommands = worksheet.Cells[i, colIndex++].Value?.ToString().Trim()
                });
            }
            S_MemorandomData = memorandoms;
            return memorandoms;
        }
    }
}

