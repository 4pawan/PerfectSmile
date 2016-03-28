using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectSmile.EF
{
    [Table("PatientHistory")]
    public partial class PatientHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long PatientId { get; set; }

        [StringLength(2147483647)]
        public string TreatmentDone { get; set; }

        public decimal PaymentDone { get; set; }

        public decimal Balance { get; set; }

        public DateTime? NextAppointment { get; set; }

        [StringLength(2147483647)]
        public string AdditionalComment { get; set; }

        [StringLength(2147483647)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
