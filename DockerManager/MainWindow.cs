using System.Diagnostics;

namespace DockerManager
{
    public partial class MainWindow : Form
    {
        private TabControl dockerContainerTabs;
        private List<string> containerNames;
        private List<DockerInfo> dockerStats;


        public MainWindow()
        {
            InitializeComponent();
            UpdateGUI();
        }



        private static async Task<List<DockerInfo>> GetDockerStatsAsync() => await Task.Run(() =>
        {
            // Initialize a list to store DockerInfo objects
            var stats = new List<DockerInfo>();

            // Set up the process start information for the docker stats command
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = "stats --no-stream --format \"{{.ID}}: {{.Name}} {{.CPUPerc}} {{.MemUsage}} {{.NetIO}} {{.BlockIO}} {{.PIDs}}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the process to execute the docker stats command
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();

                // Read the output from the docker stats command line by line
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        // Split the line into container ID and stats parts
                        var parts = line.Split(":");
                        if (parts.Length == 2)
                        {
                            string containerID = parts[0].Trim();
                            var statParts = parts[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            // Create a DockerInfo object with the parsed stats
                            DockerInfo dockerInfo = new(
                                statParts[0], // Container Name
                                containerID,  // Container ID
                                statParts[1], // CPU Percentage
                                statParts[2] + " " + statParts[3] + " " + statParts[4], // Memory Usage
                                statParts[5] + " " + statParts[6] + " " + statParts[7], // Net I/O
                                statParts[8] + " " + statParts[9] + " " + statParts[10], // Block I/O
                                statParts[11] // PIDs
                            );

                            // Add the DockerInfo object to the stats list
                            stats.Add(dockerInfo);
                        }
                    }
                }
            }

            // Return the list of DockerInfo objects
            return stats;
        });

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void RestartAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (DockerInfo dInfo in dockerStats)
                {
                    toolStripStatusLabel1.Text = "Restarting containerID: " + dInfo.ContainerID + " Container name: " + dInfo.ContainerName;
                    ProcessStartInfo processStartInfo = new()
                    {
                        FileName = "docker",
                        Arguments = $"restart {dInfo.ContainerID}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using Process process = new() { StartInfo = processStartInfo };
                    process.Start();
                    process.WaitForExit();
                }
            });
        }


        private async void DockerRefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        private async void UpdateGUI()
        {
            if (displayPanel.Controls.Count != 0) { displayPanel.Controls.Clear(); }
            dockerStats?.Clear();

            dockerContainerTabs = new TabControl
            {
                Dock = DockStyle.Fill
            };
            displayPanel.Controls.Add(dockerContainerTabs);


            containerNames = [];

            dockerStats = await GetDockerStatsAsync();


            // Create the Overview tab
            var overviewTab = new TabPage("Overview");
            var overviewTable = new TableLayoutPanel
            {
                ColumnCount = 7,
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            overviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            overviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            overviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            overviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            overviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            overviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            overviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));

            // Add headers to the table
            overviewTable.Controls.Add(new Label { Text = "Container Name", AutoSize = true }, 0, 0);
            overviewTable.Controls.Add(new Label { Text = "Container ID", AutoSize = true }, 0, 0);
            overviewTable.Controls.Add(new Label { Text = "CPU %", AutoSize = true }, 1, 0);
            overviewTable.Controls.Add(new Label { Text = "Memory Usage", AutoSize = true }, 2, 0);
            overviewTable.Controls.Add(new Label { Text = "Net I/O", AutoSize = true }, 3, 0);
            overviewTable.Controls.Add(new Label { Text = "Block I/O", AutoSize = true }, 4, 0);
            overviewTable.Controls.Add(new Label { Text = "PIDs", AutoSize = true }, 5, 0);

            Panel underlinePanel = new()
            {
                Height = 2, // Set the height of the underline
                Dock = DockStyle.Bottom,
                BackColor = Color.Black // Set the color of the underline
            };
            overviewTable.Controls.Add(underlinePanel, 0, 1);
            overviewTable.SetColumnSpan(underlinePanel, 7);

            int row = 2;
            foreach (DockerInfo dInfo in dockerStats)
            {
                containerNames.Add(dInfo.ContainerName); // Add container name to the list

                overviewTable.Controls.Add(new Label { Text = dInfo.ContainerName, AutoSize = true }, 0, row);
                overviewTable.Controls.Add(new Label { Text = dInfo.ContainerID, AutoSize = true }, 0, row);
                overviewTable.Controls.Add(new Label { Text = dInfo.CPUUsage, AutoSize = true }, 1, row);
                overviewTable.Controls.Add(new Label { Text = dInfo.MemUsage, AutoSize = true }, 2, row);
                overviewTable.Controls.Add(new Label { Text = dInfo.NetIO, AutoSize = true }, 3, row);
                overviewTable.Controls.Add(new Label { Text = dInfo.BlockIO, AutoSize = true }, 4, row);
                overviewTable.Controls.Add(new Label { Text = dInfo.PID, AutoSize = true }, 5, row);
                row++;
            }

            overviewTab.Controls.Add(overviewTable);
            dockerContainerTabs.TabPages.Add(overviewTab);

            // Add individual container tabs
            foreach (DockerInfo dInfo in dockerStats)
            {
                TabPage tabPage = new(dInfo.ContainerName);
                var textBox = new TextBox
                {
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    Text = dInfo.ContainerID
                };
                tabPage.Controls.Add(textBox);
                dockerContainerTabs.TabPages.Add(tabPage);
            }

        }

        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences pf = new Preferences();
            pf.Show();
        }
    }
}
