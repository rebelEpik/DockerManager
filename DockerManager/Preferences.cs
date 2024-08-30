using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerManager
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
            preferencesTabControl.DrawItem += new DrawItemEventHandler(PreferencesTabControl_DrawItem);
            preferencesTabControl.SizeMode = TabSizeMode.Fixed;
            preferencesTabControl.ItemSize = new Size(75, preferencesTabControl.ItemSize.Height);
        }

        private void PreferencesCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreferencesSaveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PreferencesTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush textBrush;
            TabPage generalTabPage = preferencesTabControl.TabPages[e.Index];
            Rectangle tabBounds = preferencesTabControl.GetTabRect(e.Index);

            if(e.State == DrawItemState.Selected)
            {
                textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font tabFont = new Font("Arial", 10.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Center;
            stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(generalTabPage.Text, tabFont, textBrush, tabBounds, stringFlags);
        }
    }
}
