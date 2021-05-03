namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Usename is not valid!!")]
        [StringLength(40)]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is not valid!!")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is not valid!!")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        public int Permission { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
