namespace ProcessScheduling.WinApp.Tools
{
    using CsvHelper;
    using ProcessScheduling.Scheduler.Model;
    using ProcessScheduling.WinApp.ViewModel;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class TextFileManager
    {
        public TextFileManager()
        {
        }

        public async void WriteResultFileAsync(string filePath, SchedulerResult result)
        {
            string directoryPath = Path.GetDirectoryName(filePath) ?? string.Empty;
            string resultFilename = Path.GetFileNameWithoutExtension(filePath) + "_result.txt";
            var lines = result.GetResultReportLinesArray();
            await File.WriteAllLinesAsync(Path.Combine(directoryPath, resultFilename), lines);
        }

    }

}
