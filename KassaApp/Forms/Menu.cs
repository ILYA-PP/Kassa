using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        //переход на главную форму
        private void регистрацияПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Main().Show();
        }
        //переход на форму настройки связи
        private void настройкаСвязиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }
    }
}
