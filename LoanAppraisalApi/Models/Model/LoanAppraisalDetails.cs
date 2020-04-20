using System.ComponentModel.DataAnnotations;

namespace LoanAppraisalApi.Models
{
    public class LoanAppraisalDetails
    {
        [Key]
        public int ID { get; set; }

        public string LoaneeFirstName { get; set; }

        public string LoaneeeLastName { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string LoaneeAccount { get; set; }

        public string LoaneeIdNo { get; set; }

        public string BusinessRegNo { get; set; }

        public double LoanAmount { get; set; }

        public string ImageOne { get; set; }

        public string ImageTwo { get; set; }
        public double? CurrentGPSLAT
        {
            get;
            set;
        }

        public double? CurrentGPSLONG
        {
            get;
            set;
        }

        public int UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
