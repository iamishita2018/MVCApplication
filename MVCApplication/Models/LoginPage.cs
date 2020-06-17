using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Models
{
    public class LoginPage
    {
        [Required(ErrorMessage = "The User name should not be blank.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password can never be blank.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}