using System;

namespace SchoolManagementSystem.Models.Identity
{
    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}