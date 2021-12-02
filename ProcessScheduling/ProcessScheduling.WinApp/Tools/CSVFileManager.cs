namespace ProcessScheduling.WinApp.Tools
{
    using CsvHelper;
    using ProcessScheduling.Scheduler.Model;
    using ProcessScheduling.WinApp.ViewModel;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class CSVFileManager
    {
        public CSVFileManager()
        {
        }

        public IEnumerable<TandaRecord> LoadCSVRecords(string file)
        {
            IList<TandaRecord> result = new List<TandaRecord>();

            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<TandaRecord>();
                foreach (var record in records)
                {
                    result.Add(record);
                }
            }

            return result;
        }
    }

}
