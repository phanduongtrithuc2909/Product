using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAYUFOOD.Models.Entity
{
    [Table("tb_Contact")]
    public class Contact : Common
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để trống")]
        [StringLength(150, ErrorMessage ="Không quá 150 kí tự")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(150, ErrorMessage = "Không quá 150 kí tự")]
        public string Email { get; set; }

        [StringLength(2000, ErrorMessage = "Không quá 2000 kí tự")]
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
