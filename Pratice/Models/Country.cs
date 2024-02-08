

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pratice.Models
{
    public partial class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Country Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Capital is required")]
        public string Capital { get; set; }

        [Required(ErrorMessage = "Population is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Population must be a positive number")]
        public int Population { get; set; }

        [Required(ErrorMessage = "Economy is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Economy must be a positive number")]
        public decimal Economy { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; }

        public bool IsDeleted { get; set; }
    }
}
