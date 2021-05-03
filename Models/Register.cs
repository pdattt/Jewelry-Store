using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Register
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Username không được để trống!!")]
        [StringLength(40)]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu không được để trống!!")]
        [StringLength(16)]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có chiều dài tối thiểu là 6 ký tự và tối đa 16 ký tự.")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bạn cần xác nhận mật khẩu!!")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng khớp!!")]
        [StringLength(16)]
        public string ConfirmPass { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống!!")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống!!")]
        [StringLength(10)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Số điện thoại không hợp lệ!!")]
        public string Phone { get; set; }

        public int Permission { get; set; }

        [Required(ErrorMessage = "Email không được để trống!!")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ!!")]
      
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

    }
}