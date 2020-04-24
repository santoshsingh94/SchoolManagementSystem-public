using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class SubmissionFee
    {
        public int SubmissionFeeId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Plese Select Class")]
        public int ClassTblId { get; set; }
        [Required(ErrorMessage = "Plese Select Student")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Plese Enter Tution Fee")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Plese Select Programe")]
        public int ProgrameId { get; set; }
        [Required(ErrorMessage = "Plese Select Submission Date")]

        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }
        [Required(ErrorMessage = "Plese Enter Fee Month")]
        public string FeeMonth { get; set; }
        public string Description { get; set; }

        public Programe Programe { get; set; }
        public Student Student { get; set; }
        public ClassTbl ClassTbl { get; set; }
        public User User { get; set; }
    }
}
