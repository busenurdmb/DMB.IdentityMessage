using DMB.IdentityMessage.EntityLayer.Entities;

namespace DMB.IdentityMessage.PresentationLayer.Models.Mail
{
    public class ListMailModel
    {
        public int MailId { get; set; }
        public int SenderId { get; set; } // Gönderici AppUser'ın Id'sini temsil eder
        public int ReceiverId { get; set; } // Alıcı AppUser'ın Id'sini temsil eder
        public string ReceiverEmail{ get; set; } // Alıcı AppUser'ın Id'sini temsil eder
        public string SenderEmail { get; set; } // Alıcı AppUser'ın Id'sini temsil eder
        public string MailSubject { get; set; }

       
        public string MailContent { get; set; }
        public DateTime MailDate { get; set; }
        public TimeSpan MailTime { get; set; }
        public bool IsRead { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDraft { get; set; }
        public bool IsJunk { get; set; }
        public bool IsTrash { get; set; }

        public AppUser Sender { get; set; } // Gönderici AppUser nesnesi
        public AppUser Receiver { get; set; } // Alıcı AppUser nesnesi
    }
}
