namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Detail_ID { get; set; }

        public int Order_ID { get; set; }

        public int ProductID { get; set; }

        public int Amount { get; set; }

        public string Name { get; set; }

        [Required]
        [StringLength(70)]
        public string Image { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
