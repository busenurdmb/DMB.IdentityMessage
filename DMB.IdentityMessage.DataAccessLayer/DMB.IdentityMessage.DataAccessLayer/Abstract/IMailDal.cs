using DMB.IdentityMessage.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.DataAccessLayer.Abstract
{
    public interface IMailDal:IGenericDal<Mail>
    {
        List<Mail> GetSendandReceiverMailnameListAllbyReceiverId(int id);
        
        List<Mail> GetSendandReceiverMailnameListAllbySenderId(int id);
        List<Mail> GetSendandReceiverMailnameListAllbyDraftSenderId(int id);
        List<Mail> GetSendandReceiverMailnameListAllbyİmportId(int id);
        List<Mail> GetSendandReceiverMailnameListAllbyTrashId(int id);
        List<Mail> GetSendandReceiverMailnameListAllbySpamId(int id);
        List<Mail> GetSendandReceiverMailnameListAllbyReadId(int id);
        public Mail GetByIdMailId(int id);
        Mail GetDraftMailbyİd(int? id);
        void DraftDeletebyİd(int id);
       

    }
}
