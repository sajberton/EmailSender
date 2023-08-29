namespace EmailSender.Models
{
    public class MailSettingsModel
    {
        public int? ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
