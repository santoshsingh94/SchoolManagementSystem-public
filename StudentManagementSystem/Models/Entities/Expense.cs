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
        [Required(ErrorMessage ="Select Expense Type!")]
        public int ExpenseTypeId { get; set; }
        [Required(ErrorMessage = "Select Expense Date!")]
        [DataType(DataType.Date)]
        public DateTime ExpensesDate { get; set; }
        [Required(ErrorMessage = "Please Enter Amount")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Please Enter Expense Reason")]
        public string Reason { get; set; }
        public int UserId { get; set; }


        public User User { get; set; }
        public ExpenseType ExpenseType { get; set; }
        
    }
}
