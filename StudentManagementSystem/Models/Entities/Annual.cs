using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Annual
    {
        [Required]
        public int AnnualId { get; set; }
        public string ApllicationUserId { get; set; }
        [Required (ErrorMessage ="Please Select Programe")]
        public int ProgrameId { get; set; }
        [Required(ErrorMessage = "Please Enter Annual Fee Title")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Plese Enter Annual Fee")]
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
        public double Fees { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name ="Status")]
        public bool IsActive { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Programe Programe { get; set; }
    }
}
