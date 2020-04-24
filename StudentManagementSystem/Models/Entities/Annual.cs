using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Annual
    {
        [Required]
        public int AnnualId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required (ErrorMessage ="Please Select Programe")]
        public int ProgrameId { get; set; }
        [Required(ErrorMessage = "Please Enter Annual Fee Title")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Plese Enter Annual Fee")]
        [DataType(DataType.Currency)]
        public double Fees { get; set; }
        [Display(Name ="Status")]
        public bool IsActive { get; set; }

        public User User { get; set; }
        public Programe Programe { get; set; }
    }
}
