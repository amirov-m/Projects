using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicalPlayer
{
    public partial class MusicalPlayerForm : Form
    {
        public MusicalPlayerForm()
        {
            InitializeComponent();
            AddWidgets();
        }

        private void AddWidgets()
        {
            var chooseFileButton = new Button();
            chooseFileButton.Text = "Choose WAV file";
            chooseFileButton.AutoSizeMode = AutoSizeMode.GrowOnly;

            this.Controls.Add(chooseFileButton);
        }
    }
}
