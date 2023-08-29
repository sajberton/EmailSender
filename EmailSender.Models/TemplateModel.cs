using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Models
{
    public class TemplateModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string HTML { get; set; }
        public string Subject { get; set; }
    }
}
