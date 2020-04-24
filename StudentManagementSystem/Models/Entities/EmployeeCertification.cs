using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeCertification
    {
        public int EmployeeCertificationId { get; set; }
        public string CertificateName { get; set; }
        public string CertificationAuthority { get; set; }
        public string LevelCertification { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromYear { get; set; }
        public int EmployeeResumeId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public EmployeeResume EmployeeResume { get; set; }
    }
}
