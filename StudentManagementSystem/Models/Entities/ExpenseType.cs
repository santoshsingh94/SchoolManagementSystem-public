using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class ExpenseType
    {
        public int ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
