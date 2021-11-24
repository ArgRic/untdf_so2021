namespace ProcessScheduling.WinApp
{
    using ProcessScheduling.Scheduler.Model;
    using ProcessScheduling.WinApp.Tools;
    using System;
    using System.Collections.Generic;

    public class AppService
    {
        private readonly PayloadFileManager reader;
        public AppService() { 
            this.reader = new PayloadFileManager();
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

        public IEnumerable<ProcessEntry> TryLoadFiles(string filename)
        {
            var entries = new List<ProcessEntry>();
            var entradasLeidas = this.reader.LoadCSVRecords(filename);
            foreach (var entrada in entradasLeidas)
            {
                entries.Add(entrada.ToProcessEntry());
            }
            return entries;
        }
    }
}
