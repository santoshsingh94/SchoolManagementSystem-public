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
    public class StudentEditViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public int SessionId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public int? ProgrameId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public int ClassTblId { get; set; }
        public string ApplicationUserId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string FatherName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string GenderId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string ContactNo { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email!")]
        public string Email { get; set; }
        public int NationalityId { get; set; }
        public int ReligionId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public int CategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string GuardianName { get; set; }
        public string GuardianOccupation { get; set; }
        public string GuardianPhone { get; set; }
        public string Cast { get; set; }
        public string Address { get; set; }
        public string AadharNo { get; set; }
        public IFormFile Photo { get; set; }
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }
        public string PreviousSchool { get; set; }
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
