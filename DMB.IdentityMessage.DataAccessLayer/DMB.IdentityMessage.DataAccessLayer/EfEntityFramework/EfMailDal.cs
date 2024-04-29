using DMB.IdentityMessage.DataAccessLayer.Abstract;
using DMB.IdentityMessage.DataAccessLayer.Context;
using DMB.IdentityMessage.DataAccessLayer.Repository;
using DMB.IdentityMessage.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.DataAccessLayer.EfEntityFramework
{
    public class EfMailDal : GenericRepository<Mail>, IMailDal
    {
        DMBContext context = new DMBContext();

        public void DraftDeletebyİd(int id)
        {
            var deleteDraft = context.Mails.FirstOrDefault(x => x.MailId == id&& x.IsDraft);
            if (deleteDraft != null)
            {
                context.Mails.Remove(deleteDraft);
                context.SaveChanges();
            }
        }

        public Mail GetDraftMailbyİd(int? id)
        {
            var draft = context.Mails.FirstOrDefault(x => x.MailId == id && x.IsDraft);
            return draft;
        }

        public List<Mail> GetSendandReceiverMailnameListAllbyDraftSenderId(int id)
        {
            var values = context.Mails.Include(x => x.Receiver).Where(y => y.SenderId == id && y.IsDraft && !y.IsTrash && !y.IsJunk).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Mail> GetSendandReceiverMailnameListAllbyReadId(int id)
        {
            var values = context.Mails.Include(x => x.Receiver).Where(y => y.ReceiverId == id && !y.IsDraft && !y.IsTrash && !y.IsJunk &&!y.IsRead).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Mail> GetSendandReceiverMailnameListAllbyReceiverId(int id)
        {
            var values = context.Mails.Include(x => x.Receiver).Where(y=>y.ReceiverId==id && !y.IsDraft && !y.IsTrash && !y.IsJunk).Include(y=>y.Sender).ToList();
            return values;
        }

        public List<Mail> GetSendandReceiverMailnameListAllbySenderId(int id)
        {
            var values = context.Mails.Include(x => x.Receiver).Where(y => y.SenderId == id && !y.IsDraft && !y.IsTrash && !y.IsJunk).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Mail> GetSendandReceiverMailnameListAllbySpamId(int id)
        {
            var values = context.Mails.Include(x => x.Receiver).Where(x =>x.ReceiverId==id && x.IsJunk && !x.IsTrash && !x.IsDraft).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Mail> GetSendandReceiverMailnameListAllbyTrashId(int id)
        {
            var values = context.Mails.Include(x => x.Receiver).Where(y => y.SenderId == id || y.ReceiverId == id).Where(x =>x.IsTrash==true).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Mail> GetSendandReceiverMailnameListAllbyİmportId(int id)
        {
            var values = context.Mails.Include(x => x.Receiver).Where(y=>(y.SenderId==id || y.ReceiverId == id) &&  !y.IsDraft && !y.IsTrash && y.IsImportant).Include(y => y.Sender).ToList();
            return values;
        }

        public Mail GetByIdMailId(int id)
        {
            var values = context.Mails.Include(X => X.Sender).Where(x => x.MailId == id).Include(x => x.Receiver).FirstOrDefault();
            return values;
        }
    }
}
