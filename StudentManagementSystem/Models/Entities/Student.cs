using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models.Entities
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required (ErrorMessage ="Please Select Session")]
        public int SessionId { get; set; }
        [Required(ErrorMessage = "Please Select Programe")] 
        public int ? ProgrameId { get; set; }
        [Required(ErrorMessage = "Please Select Current Class")]
        public int ClassTblId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Father Name")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Please Enter DOB")]

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Contact No")]
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Category { get; set; }
        public string GuardianName { get; set; }
        public string GuardianOccupation { get; set; }
        public string GuardianPhone { get; set; }

        public string Cast { get; set; }
        public string Address { get; set; }
        public string AadharNo { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Enter Admission Date")]
        public DateTime AdmissionDate { get; set; }

        [Required(ErrorMessage = "Please Enter Previous School")]
        public string PreviousSchool { get; set; }
        [Required(ErrorMessage = "Please Enter Percentage")]
        public float PreviousPercentage { get; set; }


        //[NotMapped]
        //public HttpPostedFileBase PhotoFile { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<ExamMark> ExamMarks { get; set; }
        public Programe Programe { get; set; }
        public Session Session { get; set; }
        public User User { get; set; }
        public ClassTbl ClassTbl { get; set; }
        public ICollection<SubmissionFee> SubmissionFees { get; set; }
        public ICollection<StudentPromote> StudentPromotes { get; set; }
        public ICollection<SchoolLeaving> SchoolLeavings { get; set; }

    }
}
