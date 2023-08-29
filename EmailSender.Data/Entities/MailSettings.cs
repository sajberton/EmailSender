using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Data.Entities
{
    public class EmailSettings
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Host")]
        public string Host { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Port")]
        public int Port { get; set; }
    }
}
