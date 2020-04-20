using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAppraisalApi.Models
{
    public class Users
    {

        [Key]
        public int UserId { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string Adress { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string EmployeeNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(600)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string UserName { get; set; }


        public DateTime LoginTime { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public string Cellphone { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string EmployeeIDNO { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime LastLoginTime { get; set; }


        public IEnumerable<Inspection> Inspections { get; set; }

        public IEnumerable<LoanAppraisalDetails> loanAppraisalDetails { get; set; }

    }
}
