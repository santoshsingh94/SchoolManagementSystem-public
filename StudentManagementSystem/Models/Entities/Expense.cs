using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Select Expense Type!")]
        public int ExpenseTypeId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Select Expense Date!")]
        [DataType(DataType.Date)]
        public DateTime ExpensesDate { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Amount")]
        public double Amount { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Expense Reason")]
        public string Reason { get; set; }
        public string ApplicationUserId { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public ExpenseType ExpenseType { get; set; }
        
    }
}
