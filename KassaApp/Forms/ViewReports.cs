using Dapper;
using KassaApp.Models;
using KassaApp.Models.Connection;
using System;
using System.Collections.Generic;
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
            Log.Logger.Info("Открытие окна Просмотра отчётов...");
            InitializeComponent();
            typeCB.SelectedIndex = 0;
            ViewResult();//вывод всех отчётов
        }

        /// <summary>
        /// Метод выводит результат поиска в таблицу формы.
        /// Если результат поиска равен null выводятся все отчёты.
        /// </summary>
        /// <param name="reports">Массив, содержащий найденные отчёты.</param>
        private void ViewResult(IEnumerable<Report> reports = null)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                Log.Logger.Info($"Вывод списка отчётов");
                reportsDGV.Rows.Clear();
                //если в метод не переданы данные для вывода
                //то выводится информация о всех отчётах
                if (reports == null)
                    foreach (Report p in db.Query<Report>(SQLHelper.Select<Report>()))
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
            using (var db = ConnectionFactory.GetConnection())
            {
                Log.Logger.Info($"Получение списка отчётов по дате и типу");
                //получение отчётов дата добавления которых
                //равна выбранной дате
                var reports = db.Query<Report>(SQLHelper.Select<Report>($"WHERE DATEADD(dd, 0, DATEDIFF(dd, 0, Date)) = '{dateSearchDTP.Value:yyyy-MM-dd}' AND Name LIKE '%{typeCB.SelectedItem}%'"));
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
            reportTB.Text = "";
            //вывод данных отчёта в текстовое поле
            if (reportsDGV.SelectedRows.Count > 0)
                reportTB.Text = reportsDGV.SelectedRows[0].Cells["dataCol"].Value.ToString();
            if (reportsDGV.CurrentRow != null)
                reportsDGV.CurrentRow.Selected = true;
        }
        /// <summary>
        /// Метод отвечает за поиск отчётов по имени.
        /// </summary>
        /// <param name="name">Название отчёта</param>
        private void NameFilter(string name)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                Log.Logger.Info($"Получение списка отчётов, название которых содержит \"{name}\"");
                //получение отчётов название которых
                //содержит введённый в поисковую строку текст
                var reports = db.Query<Report>(SQLHelper.Select<Report>($"WHERE Name LIKE '%{name}%'"));
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
        /// <summary>
        /// Метод обрабатывает событие закрытия формы.
        /// Отвечает за запись информации о закрытии окна в лог.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void ViewReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Закрытие окна Просмотра отчётов...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            typeCB.SelectedIndex = 0;
            dateSearchDTP.Value = DateTime.Now;

            ViewResult();
        }
    }
}
