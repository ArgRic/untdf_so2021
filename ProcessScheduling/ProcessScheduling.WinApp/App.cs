
namespace ProcessScheduling.WinApp
{
    using ProcessScheduling.WinApp.Model;
    using ProcessScheduling.WinApp.Scheduler;
    using ProcessScheduling.WinApp.Scheduler.Policies;
    using System;

    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            policySelect.DataSource = Enum.GetNames(typeof(PolicyEnum));
        }

        private void StartScheduler(ProcessSchedulerConfig config)
        {
            var entries = new List<ProcessEntry>();
            var scheduler = new ProcessScheduler(this.PolicyFactory(config.Policy), entries, config);
            var result = scheduler.Work();
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

        private void loadFileButton_Click(object sender, EventArgs e)
        {
  
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