using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pratice.Models
{
    [Table("BackupCountries")]
    public partial class BackupCountry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Capital { get; set; }

        public int Population { get; set; }

        public decimal Economy { get; set; }

        public string Currency { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime BackupDateTime { get; set; } // Add a field to store the timestamp of the backup
    }
}

