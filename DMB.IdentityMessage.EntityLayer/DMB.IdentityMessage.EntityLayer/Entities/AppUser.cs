using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.EntityLayer.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? City { get; set; }
        public string? İmageUrl { get; set; }
        public List<Mail> SenderMail {  get; set; }
        public  List<Mail> ReceiverMail {  get; set; }
    }
}
