using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KassaApp.Models
{
    /// <summary>
    /// Класс преставляет таблицу Report базы данных
    /// и предоставляет функционал для работы с ним.
    /// </summary>
    [Table("Report")]
    public partial class Report
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string ReportData { get; set; }
        public DateTime Date { get; set; }
    }
}
