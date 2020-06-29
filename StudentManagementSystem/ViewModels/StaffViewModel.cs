using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.ViewModels
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
        public string ApplicationUserId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public int DesignationId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string ContactNo { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public double BasicSalary { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string Address { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string Qualification { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public IFormFile photo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string Gender { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*required!")]
        public string HomePhone { get; set; }
        public bool DoYouHaveAnyDisability { get; set; }
        public string DisabilityDetails { get; set; }
        public bool TakingAnyMedication { get; set; }
        public string MedicationDetails { get; set; }
        public bool AnyCriminalOffence { get; set; }
        public string CriminalOffenceDetails { get; set; }
        public DateTime RegistrationDate { get; set; }

        //[NotMapped]
        //public HttpPostedFileBase PhotoFile { get; set; }
        public ICollection<StaffAttendance> StaffAttendances { get; set; }
        public ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }
        public ICollection<EmployeeLeaving> EmployeeLeavings { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Designation Designation { get; set; }
    }
}
