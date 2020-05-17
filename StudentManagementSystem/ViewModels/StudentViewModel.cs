using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using SchoolManagementSystem.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    public class StudentViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Select Session")]
        public int SessionId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Select Programe")]
        public int? ProgrameId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Select Current Class")]
        public int ClassTblId { get; set; }
        public string ApplicationUserId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Student Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Father Name")]
        public string FatherName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter DOB")]

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Gender")]
        public string GenderId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Contact No")]
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int NationalityId { get; set; }
        public int ReligionId { get; set; }
        public int CategoryId { get; set; }
        public string GuardianName { get; set; }
        public string GuardianOccupation { get; set; }
        public string GuardianPhone { get; set; }

        public string Cast { get; set; }
        public string Address { get; set; }
        public string AadharNo { get; set; }
        public IFormFile Photo { get; set; }
        [DataType(DataType.Date)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Admission Date")]
        public DateTime AdmissionDate { get; set; }

        //[Required(ErrorMessage = "Please Enter Previous School")]
        public string PreviousSchool { get; set; }
        //[Required(ErrorMessage = "Please Enter Percentage")]
        public float PreviousPercentage { get; set; }
        public Programe Programe { get; set; }
        public Session Session { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ClassTbl ClassTbl { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public Category Category { get; set; }
        public Religion Religion { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<ExamMark> ExamMarks { get; set; }
        public ICollection<SubmissionFee> SubmissionFees { get; set; }
        public ICollection<StudentPromote> StudentPromotes { get; set; }
        public ICollection<SchoolLeaving> SchoolLeavings { get; set; }

    }
}
