using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectSmile.EF
{
    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            PatientHistories = new HashSet<PatientHistory>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [StringLength(2147483647)]
        public string Phone { get; set; }

        [StringLength(2147483647)]
        public string Remark { get; set; }

        [StringLength(2147483647)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(2147483647)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientHistory> PatientHistories { get; set; }
    }
}
