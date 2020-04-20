using System.ComponentModel.DataAnnotations;

namespace LoanAppraisalApi.Models
{
    public class Inspection
    {
        [Key]
        public int ID { get; set; }
        public string BusinessRegNo { get; set; }

        public string Image { get; set; }

        public string Image_ { get; set; }

        public string LoaneeAccountNo { get; set; }

        public double? GPSLAT
        {
            get;
            set;
        }

        public double? GPSLONG
        {
            get;
            set;
        }

        public int UserId { get; set; }


        public virtual Users Users { get; set; }
    }
}
