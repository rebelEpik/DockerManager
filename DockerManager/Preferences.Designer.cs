namespace DockerManager
{
    partial class Preferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            preferencesBottomButtonPanel = new Panel();
            preferencesSaveButton = new Button();
            preferencesCancelButton = new Button();
            preferencesTabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            preferencesBottomButtonPanel.SuspendLayout();
            preferencesTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // preferencesBottomButtonPanel
            // 
            preferencesBottomButtonPanel.Controls.Add(preferencesSaveButton);
            preferencesBottomButtonPanel.Controls.Add(preferencesCancelButton);
            preferencesBottomButtonPanel.Dock = DockStyle.Bottom;
            preferencesBottomButtonPanel.Location = new Point(0, 442);
            preferencesBottomButtonPanel.Name = "preferencesBottomButtonPanel";
            preferencesBottomButtonPanel.Size = new Size(717, 36);
            preferencesBottomButtonPanel.TabIndex = 0;
            // 
            // preferencesSaveButton
            // 
            preferencesSaveButton.Location = new Point(527, 3);
            preferencesSaveButton.Name = "preferencesSaveButton";
            preferencesSaveButton.Size = new Size(86, 28);
            preferencesSaveButton.TabIndex = 1;
            preferencesSaveButton.Text = "Save";
            preferencesSaveButton.UseVisualStyleBackColor = true;
            preferencesSaveButton.Click += PreferencesSaveButton_Click;
            // 
            // preferencesCancelButton
            // 
            preferencesCancelButton.Location = new Point(619, 3);
            preferencesCancelButton.Name = "preferencesCancelButton";
            preferencesCancelButton.Size = new Size(86, 28);
            preferencesCancelButton.TabIndex = 0;
            preferencesCancelButton.Text = "Cancel";
            preferencesCancelButton.UseVisualStyleBackColor = true;
            preferencesCancelButton.Click += PreferencesCancelButton_Click;
            // 
            // preferencesTabControl
            // 
            preferencesTabControl.Alignment = TabAlignment.Left;
            preferencesTabControl.Controls.Add(tabPage1);
            preferencesTabControl.Controls.Add(tabPage2);
            preferencesTabControl.Dock = DockStyle.Fill;
            preferencesTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            preferencesTabControl.ItemSize = new Size(75, 97);
            preferencesTabControl.Location = new Point(0, 0);
            preferencesTabControl.Multiline = true;
            preferencesTabControl.Name = "preferencesTabControl";
            preferencesTabControl.SelectedIndex = 0;
            preferencesTabControl.Size = new Size(717, 442);
            preferencesTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(101, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(612, 434);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General Settings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(101, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(612, 434);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Preferences
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 478);
            Controls.Add(preferencesTabControl);
            Controls.Add(preferencesBottomButtonPanel);
            Name = "Preferences";
            Text = "Preferences";
            preferencesBottomButtonPanel.ResumeLayout(false);
            preferencesTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel preferencesBottomButtonPanel;
        private Button preferencesSaveButton;
        private Button preferencesCancelButton;
        private TabControl preferencesTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}