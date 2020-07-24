using KassaApp.Models;
using System;
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
            ViewResult(null);//вывод всех отчётов
        }
        //обработка ввода текста в строку Поиска
        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            using (var db = new KassaDBContext())
            {
                //получение отчётов название которых
                //содержит введённый в поисковую строку текст
                var reports = db.Report.Where(p => p.Name.Contains(searchTB.Text));
                ViewResult(reports);
            }
        }
        //вывод данных о товарах на форму
        private void ViewResult(IQueryable<Report> rep)
        {
            using (var db = new KassaDBContext())
            {
                reportsDGV.Rows.Clear();
                //если в метод не переданы данные для вывода
                //то выводится информация о всех отчётах
                if (rep == null)
                    foreach (Report p in db.Report)
                        reportsDGV.Rows.Add(p.Name, p.ReportData, p.Date);
                else
                    foreach (Report p in rep)
                        reportsDGV.Rows.Add(p.Name, p.ReportData, p.Date);
            }
        }
        //обработка выбора даты для фильтрации
        private void dateSearchDTP_ValueChanged(object sender, EventArgs e)
        {
            using (var db = new KassaDBContext())
            {
                //получение отчётов дата добавления которых
                //равна выбранной дате
                var reports = db.Report.Where(r => r.Date.Year == dateSearchDTP.Value.Year &&
                                               r.Date.Month == dateSearchDTP.Value.Month &&
                                               r.Date.Day == dateSearchDTP.Value.Day);
                ViewResult(reports);
            }
        }
        //обработка выбора строки DataGridView
        private void reportsDGV_SelectionChanged(object sender, EventArgs e)
        {
            //вывод данных отчёта в текстовое поле
            if (reportsDGV.SelectedRows.Count > 0)
                reportTB.Text = Encoding.Default.GetString((byte[])reportsDGV.SelectedRows[0].Cells["dataCol"].Value);
        }
    }
}
