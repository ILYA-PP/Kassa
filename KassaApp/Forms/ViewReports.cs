using KassaApp.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    /// <summary>
    /// Класс содержит логику работы формы просмотра отчётов.
    /// </summary>
    public partial class ViewReports : Form
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и первичное заполнение таблицы отчётов.
        /// </summary>
        public ViewReports()
        {
            InitializeComponent();
            typeCB.SelectedIndex = 0;
            ViewResult(null);//вывод всех отчётов
        }

        /// <summary>
        /// Метод выводит результат поиска в таблицу формы.
        /// Если результат поиска равен null выводятся все отчёты.
        /// </summary>
        /// <param name="reports">Массив, содержащий найденные отчёты.</param>
        private void ViewResult(IQueryable<Report> reports)
        {
            using (var db = new KassaDBContext())
            {
                reportsDGV.Rows.Clear();
                //если в метод не переданы данные для вывода
                //то выводится информация о всех отчётах
                if (reports == null)
                    foreach (Report p in db.Report)
                        reportsDGV.Rows.Add(p.Name, p.ReportData, p.Date);
                else
                    foreach (Report p in reports)
                        reportsDGV.Rows.Add(p.Name, p.ReportData, p.Date);
            }
        }
        /// <summary>
        /// Метод обрабатывает выбор даты в dateTimePicker.
        /// Формирует массив значений, сохранённых в выбранную дату.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void dateSearchDTP_ValueChanged(object sender, EventArgs e)
        {
            using (var db = new KassaDBContext())
            {
                //получение отчётов дата добавления которых
                //равна выбранной дате
                var reports = db.Report.Where(r => r.Date.Year == dateSearchDTP.Value.Year &&
                                               r.Date.Month == dateSearchDTP.Value.Month &&
                                               r.Date.Day == dateSearchDTP.Value.Day && 
                                               r.Name.Contains(typeCB.SelectedItem.ToString()));
                ViewResult(reports);
            }
        }
        /// <summary>
        /// Метод обрабатывает событие изменения выбора в dataGridView.
        /// Выделяет строку в которой было выбрано поле и выводит данные в поле отчёта.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void reportsDGV_SelectionChanged(object sender, EventArgs e)
        {
            //вывод данных отчёта в текстовое поле
            if (reportsDGV.SelectedRows.Count > 0)
                reportTB.Text = Encoding.Default.GetString((byte[])reportsDGV.SelectedRows[0].Cells["dataCol"].Value);
            if (reportsDGV.CurrentRow != null)
                reportsDGV.CurrentRow.Selected = true;
        }
        /// <summary>
        /// Метод отвечает за поиск отчётов по имени.
        /// </summary>
        /// <param name="name">Название отчёта</param>
        private void NameFilter(string name)
        {
            using (var db = new KassaDBContext())
            {
                //получение отчётов название которых
                //содержит введённый в поисковую строку текст
                var reports = db.Report.Where(p => p.Name.Contains(name));
                ViewResult(reports);
            }
        }
        /// <summary>
        /// Метод обрабатывает событие изменения выбора в comboBox.
        /// Выводит отчёты, соответствующие выбранному типу.
        /// Выводит все отчёты, если выбрано пустое значение.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void typeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeCB.SelectedItem != null)
                NameFilter(typeCB.SelectedItem.ToString());
        }
    }
}
