using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Data.Entities
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Text { get; set; }
        public string HTML { get; set; }
        [MaxLength(100)]
        public string Subject { get; set; }
    }
}
