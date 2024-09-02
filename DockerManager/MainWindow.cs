using System.Diagnostics;
using System.ComponentModel;

namespace DockerManager
{
    public partial class MainWindow : Form
    {
        private BindingSource dockerBindingSource;
        private SortableBindingList<DockerInfo> dockerStats;
        private DataGridView dockerDataGrid = new DataGridView();
        private TabControl dockerTabs = new TabControl();

        public MainWindow()
        {
            InitializeComponent();
            dockerTabs.Dock = DockStyle.Fill;

            TabPage overviewTab = new TabPage("Overview");
            dockerDataGrid.Dock = DockStyle.Fill;
            overviewTab.Controls.Add(dockerDataGrid);
            dockerTabs.TabPages.Add(overviewTab);
            displayPanel.Controls.Add(dockerTabs);




            InitializeDockerDataGrid();
            BindDockerStats();
            
        }

        private void InitializeDockerDataGrid()
        {
            dockerBindingSource = new BindingSource();
            dockerStats = new SortableBindingList<DockerInfo>();

            // Bind the SortableBindingList to the BindingSource
            dockerBindingSource.DataSource = dockerStats;

            // Bind the BindingSource to the DataGridView
            dockerDataGrid.DataSource = dockerBindingSource;

            // Subscribe to the ListChanged event
            dockerStats.ListChanged += DockerStats_ListChanged;
        }

        private async Task BindDockerStats()
        {
            // Call the GetDockerStatsAsync method to get the Docker stats
            var newDockerStats = await GetDockerStatsAsync();

            // Update the SortableBindingList with new items
            foreach (var newDockerInfo in newDockerStats)
            {
                var existingDockerInfo = dockerStats.FirstOrDefault(dockerInfo => dockerInfo.ContainerID == newDockerInfo.ContainerID);

                if (existingDockerInfo != null)
                {
                    // Check if any fields do not match
                    if (existingDockerInfo.ContainerName != newDockerInfo.ContainerName ||
                        existingDockerInfo.CPUUsage != newDockerInfo.CPUUsage ||
                        existingDockerInfo.MemUsage != newDockerInfo.MemUsage ||
                        existingDockerInfo.NetIO != newDockerInfo.NetIO ||
                        existingDockerInfo.BlockIO != newDockerInfo.BlockIO ||
                        existingDockerInfo.PID != newDockerInfo.PID)
                    {
                        // Remove the old entry
                        dockerStats.Remove(existingDockerInfo);
                        // Add the new entry
                        dockerStats.Add(newDockerInfo);
                    }
                }
                else
                {
                    // Add the new entry if it doesn't exist
                    dockerStats.Add(newDockerInfo);
                }
            }

            foreach (TabPage tabPage in dockerTabs.TabPages)
            {
                if(tabPage.Text != "Overview")
                {
                    // Create a HashSet to store existing tab names
                    HashSet<string> existingTabs = new HashSet<string>();
                    foreach (TabPage page in dockerTabs.TabPages)
                    {
                        existingTabs.Add(page.Text);
                    }

                    // Iterate through dockerStats and add new tabs for entries not in existingTabs
                    foreach (var dockerInfo in dockerStats)
                    {
                        if (!existingTabs.Contains(dockerInfo.ContainerName))
                        {
                            TabPage newTab = new TabPage(dockerInfo.ContainerName);
                            dockerTabs.TabPages.Add(newTab);
                            existingTabs.Add(dockerInfo.ContainerName); // Add to existing tabs to avoid duplicates
                        }
                    }
                }
            }

            // Sort the SortableBindingList by ContainerName
            dockerStats.Sort("ContainerName", ListSortDirection.Ascending);
        }

        private void DockerStats_ListChanged(object sender, ListChangedEventArgs e)
        {
            // Handle the ListChanged event to update the DataGridView
            dockerBindingSource.ResetBindings(false);
        }

        private static async Task<SortableBindingList<DockerInfo>> GetDockerStatsAsync() => await Task.Run(() =>
        {
            var stats = new SortableBindingList<DockerInfo>();

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = "stats --no-stream --format \"{{.ID}}: {{.Name}} {{.CPUPerc}} {{.MemUsage}} {{.NetIO}} {{.BlockIO}} {{.PIDs}}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        var parts = line.Split(":");
                        if (parts.Length == 2)
                        {
                            string containerID = parts[0].Trim();
                            var statParts = parts[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            DockerInfo dockerInfo = new(
                                statParts[0], // Container Name
                                containerID,  // Container ID
                                statParts[1], // CPU Percentage
                                statParts[2] + " " + statParts[3] + " " + statParts[4], // Memory Usage
                                statParts[5] + " " + statParts[6] + " " + statParts[7], // Net I/O
                                statParts[8] + " " + statParts[9] + " " + statParts[10], // Block I/O
                                statParts[11] // PIDs
                            );

                            stats.Add(dockerInfo);
                        }
                    }
                }
            }

            return stats;
        });







        private async void DockerRefreshTimer_Tick(object sender, EventArgs e)
        {
            // Refresh the Docker stats
            await BindDockerStats();
        }





        #region MenuStripEventHandlers
        //Opens Preferences Window
        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences pf = new Preferences();
            pf.Show();
        }

        //Closes program
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Runs restart commands on all docker images
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
        #endregion
    }
}
