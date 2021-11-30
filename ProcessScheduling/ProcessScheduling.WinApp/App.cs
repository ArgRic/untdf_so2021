
namespace ProcessScheduling.WinApp
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using ProcessScheduling.Scheduler;
    using ProcessScheduling.Scheduler.Model;
    using ProcessScheduling.Scheduler.Policies;

    public partial class App : Form
    {
        readonly AppService appService;
        string currentPath = string.Empty;

        public App(AppService appService)
        {
            this.appService = appService ?? throw new ArgumentNullException(nameof(appService));
            this.appService.InitializeEnviroment();

            // UI Init
            InitializeComponent();
            policySelect.DataSource = Enum.GetNames(typeof(PolicyEnum));
        }

        private void StartScheduler(IEnumerable<ProcessEntry> entries, ProcessSchedulerConfig config)
        {
            var scheduler = new ProcessScheduler(config.Policy, entries, config);
            var result = scheduler.Work();
            this.SetDataTable(result);
        }

        private void SetDataTable(SchedulerResult result)
        {
            dgvOutput.Visible = false;
            dgvOutput.DataSource = null;
            // Event DataTable
            var dt = new DataTable();
            dt.Columns.Add("t", typeof(int));
            foreach (var entryResult in result.Processes) 
            {
                dt.Columns.Add(entryResult.ProcessEntry.Name, typeof(string));
            }
            dt.Columns.Add("Evento", typeof(string));

            // Filas
            int time = 0;
            foreach(var schedulerEvent in result.SchedulerEvents)
            {
                time++;
                var row = dt.NewRow();
                row["t"] = time;
                foreach(var shot in schedulerEvent.ProcessSnapshots)
                { 
                    row[shot.ProcessEntryName] = shot.ToString();
                }
                row["Evento"] = schedulerEvent.Message;
                dt.Rows.Add(row);
            }

            dgvOutput.DataSource = dt;

            // Pintamos
            // Color de celdas.
            foreach (DataGridViewRow viewRow in dgvOutput.Rows)
            {
                foreach (var entryResult in result.Processes)
                {
                    // Acoplado al override ToString en ProcessSnapshot
                    Color color;
                    int columnIndex = dgvOutput.Columns.IndexOf(dgvOutput.Columns[entryResult.ProcessEntry.Name]);
                    switch (viewRow.Cells[columnIndex].Value?.ToString() ?? String.Empty)
                    {
                        case "S": color = Color.Green; break;
                        case "W": color = Color.LightGray; break;
                        case "L": color = Color.PaleVioletRed; break;
                        case "C": color = Color.Gray; break;
                        default: color = Color.White; break;
                    }
                    viewRow.Cells[entryResult.ProcessEntry.Name].Style.BackColor = color;
                }
            }
            // Ancho de columnas
            foreach (var entryResult in result.Processes)
            {
                int columnIndex = dgvOutput.Columns.IndexOf(dgvOutput.Columns[entryResult.ProcessEntry.Name]);
                dgvOutput.Columns[columnIndex].Width = 25;
            }
            dgvOutput.Columns[0].Width = 25;
            dgvOutput.Visible = true;
        }

        private ProcessSchedulerConfig? ReadSchedulerConfig()
        {
            ProcessSchedulerConfig config = new ProcessSchedulerConfig();
            try
            {
                config.Policy = (PolicyEnum)policySelect.SelectedIndex;
                config.OverheadTimeToAccept = Convert.ToInt32(this.tipUpDown.Value);
                config.OverheadTimeToComplete = Convert.ToInt32(this.tfpUpDown.Value);
                config.OverheadTimeToExchange = Convert.ToInt32(this.tcpUpDown.Value);
                config.Quantum = Convert.ToInt32(this.quantumUpDown.Value);
                return config;
            }
            catch (Exception ex)
            {
                this.ShowError(ex.Message);
                return null;
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            using (var fdlg = new OpenFileDialog())
            {
                fdlg.Title = "Seleccion de archivo";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "Archivo separado por comas (*.csv)|*.csv|Archivo de texto (*.txt)|*.txt";
                fdlg.FilterIndex = 0;
                fdlg.RestoreDirectory = true;
                DialogResult result = fdlg.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fdlg.FileName))
                {
                    this.filenameLabel.Text = fdlg.FileName;
                    this.currentPath = fdlg.FileName;
                    this.startButton.Enabled = true;
                }
                else
                {
                    this.filenameLabel.Text = "Seleccionar Archivo";
                    this.currentPath = string.Empty;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Reset de estado.
            this.dgvOutput.DataSource = null;
            this.startButton.Enabled = false;
            
            var config = this.ReadSchedulerConfig();
            if (config != null && !string.IsNullOrEmpty(this.currentPath))
            {
                var entries = this.appService.TryLoadFiles(this.currentPath);
                this.StartScheduler(entries, config);
                this.startButton.Enabled = true;
            }

        }
    }
}