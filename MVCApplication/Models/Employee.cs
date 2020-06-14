using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "The Employee Id should not be blank.")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Emp_id { get; set; }
        public IEnumerable<SelectListItem> EmpIdList { get; set; }
        [Required(ErrorMessage ="The name field cannot be blank.")]
        [MinLength(4, ErrorMessage = "The Employee Name must be atleast 4 characters")]
        [MaxLength(20, ErrorMessage = "The Employee Name cannot be more than 20 characters")]
        [DataType(DataType.Text)]
        //[RegularExpression("([a-zA-Z0-9&#32;.&amp;amp;&amp;#39;-]+)")]
        public string Emp_name { get; set; }
        [Required(ErrorMessage = "The Email is required.")]
        [EmailAddress(ErrorMessage = "Email is incorrect")]
        public string Emp_mailid { get; set; }
        [Required(ErrorMessage = "The Salary is required.")]
        [Range(30000, 70000)]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public int Emp_salary { get; set; }

       
    }
}