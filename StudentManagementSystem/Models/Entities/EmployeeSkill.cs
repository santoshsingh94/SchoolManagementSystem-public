using SchoolManagementSystem.Models.Entities;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeSkill
    {
        public int EmployeeSkillId { get; set; }
        public string SkillName { get; set; }
        public int EmployeeResumeId { get; set; }
        public int UserId { get; set; }

        public EmployeeResume EmployeeResume { get; set; }
        public User User { get; set; }
    }
}