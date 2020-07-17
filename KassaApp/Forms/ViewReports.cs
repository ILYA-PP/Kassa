using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class ViewReports : Form
    {
        public ViewReports()
        {
            InitializeComponent();
            ViewResult(null);
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            KassaDBContext db = new KassaDBContext();
            var reports = db.Report.Where(p => p.Name.Contains(searchTB.Text));
            ViewResult(reports);
        }
        private void ViewResult(IQueryable<Report> rep)
        {
            KassaDBContext db = new KassaDBContext();
            reportsDGV.Rows.Clear();
            if (rep == null)
                foreach (Report p in db.Report)
                    reportsDGV.Rows.Add(p.Name, p.ReportData, p.Date);
            else
                foreach (Report p in rep)
                    reportsDGV.Rows.Add(p.Name, p.ReportData, p.Date);
        }

        private void dateSearchDTP_ValueChanged(object sender, EventArgs e)
        {
            KassaDBContext db = new KassaDBContext();
            var reports = db.Report.Where(r => r.Date.Year == dateSearchDTP.Value.Year && 
                                               r.Date.Month == dateSearchDTP.Value.Month &&
                                               r.Date.Day == dateSearchDTP.Value.Day );
            ViewResult(reports);
        }

        private void reportsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (reportsDGV.SelectedRows.Count > 0)
                reportTB.Text = Encoding.Default.GetString((byte[])reportsDGV.SelectedRows[0].Cells["dataCol"].Value);
        }
    }
}
