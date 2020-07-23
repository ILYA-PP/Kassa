﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace KassaApp.Models
{
    //класс представляющий таблицу БД Report
    //хранит все печатаемые чеки
    [Table("Report")]
    public partial class Report
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [MaxLength(7000)]
        public byte[] ReportData { get; set; }
        public DateTime Date { get; set; }
    }
}
