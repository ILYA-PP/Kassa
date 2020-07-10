using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace KassaApp.Models
{
    [Table("Report")]
    public partial class Report
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public Byte ReportData { get; set; }
        public DateTime Date { get; set; }
    }
}
