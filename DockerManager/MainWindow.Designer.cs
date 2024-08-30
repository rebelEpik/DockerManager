namespace DockerManager
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            dockerToolStripMenuItem = new ToolStripMenuItem();
            stopAllToolStripMenuItem = new ToolStripMenuItem();
            restartAllToolStripMenuItem = new ToolStripMenuItem();
            imagesToolStripMenuItem = new ToolStripMenuItem();
            createNewToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            dockerRefreshTimer = new System.Windows.Forms.Timer(components);
            displayPanel = new Panel();
            preferencesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, dockerToolStripMenuItem, imagesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { preferencesToolStripMenuItem, toolStripSeparator1, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(180, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // dockerToolStripMenuItem
            // 
            dockerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stopAllToolStripMenuItem, restartAllToolStripMenuItem });
            dockerToolStripMenuItem.Name = "dockerToolStripMenuItem";
            dockerToolStripMenuItem.Size = new Size(56, 20);
            dockerToolStripMenuItem.Text = "Docker";
            // 
            // stopAllToolStripMenuItem
            // 
            stopAllToolStripMenuItem.Name = "stopAllToolStripMenuItem";
            stopAllToolStripMenuItem.Size = new Size(127, 22);
            stopAllToolStripMenuItem.Text = "Stop All";
            // 
            // restartAllToolStripMenuItem
            // 
            restartAllToolStripMenuItem.Name = "restartAllToolStripMenuItem";
            restartAllToolStripMenuItem.Size = new Size(127, 22);
            restartAllToolStripMenuItem.Text = "Restart All";
            restartAllToolStripMenuItem.Click += RestartAllToolStripMenuItem_Click;
            // 
            // imagesToolStripMenuItem
            // 
            imagesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewToolStripMenuItem });
            imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            imagesToolStripMenuItem.Size = new Size(57, 20);
            imagesToolStripMenuItem.Text = "Images";
            // 
            // createNewToolStripMenuItem
            // 
            createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            createNewToolStripMenuItem.Size = new Size(142, 22);
            createNewToolStripMenuItem.Text = "Create new...";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // dockerRefreshTimer
            // 
            dockerRefreshTimer.Enabled = true;
            dockerRefreshTimer.Interval = 60000;
            dockerRefreshTimer.Tick += DockerRefreshTimer_Tick;
            // 
            // displayPanel
            // 
            displayPanel.Dock = DockStyle.Fill;
            displayPanel.Location = new Point(0, 24);
            displayPanel.Name = "displayPanel";
            displayPanel.Size = new Size(800, 404);
            displayPanel.TabIndex = 2;
            // 
            // preferencesToolStripMenuItem
            // 
            preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            preferencesToolStripMenuItem.Size = new Size(180, 22);
            preferencesToolStripMenuItem.Text = "Preferences";
            preferencesToolStripMenuItem.Click += PreferencesToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(displayPanel);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Docker Manager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem dockerToolStripMenuItem;
        private ToolStripMenuItem stopAllToolStripMenuItem;
        private ToolStripMenuItem restartAllToolStripMenuItem;
        private ToolStripMenuItem imagesToolStripMenuItem;
        private ToolStripMenuItem createNewToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer dockerRefreshTimer;
        private Panel displayPanel;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}
