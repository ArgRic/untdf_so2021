namespace ProcessScheduling.WinApp
{
    using ProcessScheduling.Scheduler.Model;
    using ProcessScheduling.WinApp.Tools;
    using System;
    using System.Collections.Generic;

    public class AppService
    {
        private readonly CSVFileManager csvFileHandler;
        private readonly TextFileManager textFileHandler;

        public string CurrentFilePath { get; set; }

        public AppService()
        {
            this.csvFileHandler = new CSVFileManager();
            this.textFileHandler = new TextFileManager();
            this.CurrentFilePath = string.Empty;
        }

        public void InitializeEnviroment()
        {
            //this.CreateMissingFolders();
            //this.CreateExampleFile();
        }

        private void CreateExampleFile()
        {
            throw new NotImplementedException();
        }

        private void CreateMissingFolders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProcessEntry> TryLoadFiles()
        {
            var entries = new List<ProcessEntry>();
            var entradasLeidas = this.csvFileHandler.LoadCSVRecords(this.CurrentFilePath);
            foreach (var entrada in entradasLeidas)
            {
                entries.Add(entrada.ToProcessEntry());
            }
            return entries;
        }

        public void TryWriteResultFile(SchedulerResult result)
        {
            this.textFileHandler.WriteResultFileAsync(this.CurrentFilePath, result);
        }

    }
}
