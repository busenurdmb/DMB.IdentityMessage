using DMB.IdentityMessage.BusinessLayer.Dto;
using DMB.IdentityMessage.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.BusinessLayer.Abstract
{
    public interface IMailService:IGenericService<Mail>
    {
        public List<ListMailDto> GetSendandReceiverMailnameListAllbyReceiverId(int id);
        public List<ListMailDto> GetSendandReceiverMailnameListAllbySenderId(int id);
        public List<ListMailDto> GetSendandReceiverMailnameListAllbyDraftSenderId(int id);
        public List<ListMailDto> GetSendandReceiverMailnameListAllbyİmportId(int id);
        public List<ListMailDto> GetSendandReceiverMailnameListAllbyTrashId(int id);
        public List<ListMailDto> GetSendandReceiverMailnameListAllbySpamId(int id);
        public List<ListMailDto> GetSendandReceiverMailnameListAllbyReadId(int id);
        ListMailDto TGetByIddto (int id);
        public ListMailDto GetDraftMailbyİd(int? id);
        public void DraftDeletebyİd(int id);

    }
}
