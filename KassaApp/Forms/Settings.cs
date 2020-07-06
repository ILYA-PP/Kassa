using KassaApp.Models;
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
    public partial class Settings : Form
    {
        private FiscalRegistrar fr;
        public Settings()
        {
            InitializeComponent();
            fr = new FiscalRegistrar();
            fr.Connect();
        }

        private void testDriverPropertiesB_Click(object sender, EventArgs e)
        {
            if (fr.CheckConnect() == 0)
                fr.OpenProperties();
        }
    }
}
