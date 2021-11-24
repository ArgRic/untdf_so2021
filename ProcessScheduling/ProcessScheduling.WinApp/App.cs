
namespace ProcessScheduling.WinApp
{
    using ProcessScheduling.WinApp.Model;
    using ProcessScheduling.WinApp.Scheduler;
    using ProcessScheduling.WinApp.Scheduler.Policies;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class App : Form
    {
        readonly AppService appService;

        public App(AppService appService)
        {
            this.appService = appService ?? throw new ArgumentNullException(nameof(appService));
            this.appService.InitializeEnviroment();

            // UI Init
            InitializeComponent();
            policySelect.DataSource = Enum.GetNames(typeof(PolicyEnum));
        }

        private void StartScheduler(ProcessSchedulerConfig config)
        {
            var entries = new List<ProcessEntry>();
            var scheduler = new ProcessScheduler(this.PolicyFactory(config.Policy), entries, config);
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
            foreach (var entryResult in result.EntryResults) 
            {
                dt.Columns.Add(entryResult.ProcessEntryName, typeof(string));
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
                    row[shot.ProcessEntryName] = shot.ToString();
                }
                row["Evento"] = schedulerEvent.Message;
                dt.Rows.Add(row);
            }

            dgvOutput.DataSource = dt;

            // Pintamos
            foreach(DataGridViewRow viewRow in dgvOutput.Rows)
            {
                foreach (var entryResult in result.EntryResults)
                {
                    // Acoplado al override ToString en ProcessSnapshot
                    Color color;
                    switch (viewRow.Cells[entryResult.ProcessEntryName].Value.ToString())
                    {
                        case "R": color = Color.Green; break;
                        case "W": color = Color.LightGray; break;
                        case "L": color = Color.PaleVioletRed; break;
                        case "C": color = Color.Gray; break;
                        default: color = Color.White; break;
                    }
                    viewRow.Cells[entryResult.ProcessEntryName].Style.BackColor = color;
                }
            }

            dgvOutput.Visible = true;
        }

        private IPolicy PolicyFactory(PolicyEnum policyEnum)
        {
            return policyEnum switch
            {
                PolicyEnum.ShortestProcessNext => new ShortestProcessNextPolicy(),
                PolicyEnum.FirstComeFirstServe => new FirstComeFirstServePolicy(),
                PolicyEnum.ExternalPriotity => new ExternalPriotityPolicy(),
                PolicyEnum.RoundRobin => new RoundRobinPolicy(),
                PolicyEnum.ShortestRemainingTime => new ShortestRemainingTimePolicy(),
                _ => new FirstComeFirstServePolicy(),
            };
        }

        private ProcessSchedulerConfig? ReadSchedulerConfig()
        {
            ProcessSchedulerConfig config = new ProcessSchedulerConfig();
            try
            {
                config.Policy = (PolicyEnum)policySelect.SelectedIndex;
                config.Tip = Convert.ToInt32(this.tipUpDown.Value);
                config.Tfp = Convert.ToInt32(this.tfpUpDown.Value);
                config.Tcp = Convert.ToInt32(this.tcpUpDown.Value);
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

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.startButton.Enabled = false;

            var config = this.ReadSchedulerConfig();
            if (config != null)
            {
                this.startButton.Enabled = true;
                this.StartScheduler(config);
            }

        }
    }
}