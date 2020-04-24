using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class StudentPromote
    {
        public int StudentPromoteId { get; set; }
        [Required(ErrorMessage = "Please Select Student")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Select Section")]
        public int SectionId { get; set; }
        [Required(ErrorMessage = "Please Select Class")]
        public int ClassTblId { get; set; }
        [Required(ErrorMessage = "Please Select Programe")]
        public int ProgrameSessionId { get; set; }
        [Required(ErrorMessage = "Please Select Promote Date")]
        [DataType(DataType.Date)]
        public DateTime PromoteDate { get; set; }
        [Required(ErrorMessage = "Please Enter Annual Fee")]
        public int AnnualFee { get; set; }
        [Display(Name ="Promote Status")]
        public bool IsActive { get; set; }
        [Display(Name ="Annual Fee Status")]
        public bool IsSubmit { get; set; }

        public ClassTbl ClassTbl { get; set; }
        public ProgrameSession ProgrameSession { get; set; }
        public Student Student { get; set; }
        public Section Section { get; set; }
       

    }
}
