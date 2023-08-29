using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Data.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        public virtual EmailSettings EmailSettings { get; set; }
    }
}
