﻿using System;
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

        private void регистрацияПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Main().Show();
        }

        private void настройкаПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }
    }
}
