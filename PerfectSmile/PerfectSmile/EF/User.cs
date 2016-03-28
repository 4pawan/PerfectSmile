using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectSmile.EF
{
    [Table("User")]
    public partial class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Password { get; set; }
    }
}
