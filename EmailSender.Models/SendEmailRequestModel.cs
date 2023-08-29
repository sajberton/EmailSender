namespace EmailSender.Models
{
    public class SendEmailRequestModel
    {
        public int ClientId { get; set; }

        public int TemplateId { get; set; }

        public string ToEmail { get; set; }
    }
}