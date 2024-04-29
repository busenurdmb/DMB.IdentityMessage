using AutoMapper;
using DMB.IdentityMessage.BusinessLayer.Abstract;
using DMB.IdentityMessage.BusinessLayer.Dto;
using DMB.IdentityMessage.DataAccessLayer.Abstract;
using DMB.IdentityMessage.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.BusinessLayer.Concrete
{
    public class MailManager:IMailService
    {
        private readonly IMailDal _MailDal;
        private readonly IMapper _mapper;
        public MailManager(IMailDal MailDal, IMapper mapper)
        {
            _MailDal = MailDal;
            _mapper = mapper;
        }

        public void DraftDeletebyİd(int id)
        {
            _MailDal.DraftDeletebyİd(id);
        }

        public ListMailDto GetDraftMailbyİd(int? id)
        {
            var mail = _MailDal.GetDraftMailbyİd(id);
            return _mapper.Map<ListMailDto>(mail);
        }

        public List<ListMailDto> GetSendandReceiverMailnameListAllbyDraftSenderId(int id)
        {
            var mail = _MailDal.GetSendandReceiverMailnameListAllbyDraftSenderId(id);
            return _mapper.Map<List<ListMailDto>>(mail);

        }

        public List<ListMailDto> GetSendandReceiverMailnameListAllbyReadId(int id)
        {
            var mail = _MailDal.GetSendandReceiverMailnameListAllbyReadId(id);
            return _mapper.Map<List<ListMailDto>>(mail);
        }

        public List<ListMailDto> GetSendandReceiverMailnameListAllbyReceiverId(int id)
        {
           var mail= _MailDal.GetSendandReceiverMailnameListAllbyReceiverId(id);
            return _mapper.Map<List<ListMailDto>>(mail);
        }

        public List<ListMailDto> GetSendandReceiverMailnameListAllbySenderId(int id)
        {
            var mail = _MailDal.GetSendandReceiverMailnameListAllbySenderId(id);
            return _mapper.Map<List<ListMailDto>>(mail);
        }

        public List<ListMailDto> GetSendandReceiverMailnameListAllbySpamId(int id)
        {
            var mail = _MailDal.GetSendandReceiverMailnameListAllbySpamId(id);
            return _mapper.Map<List<ListMailDto>>(mail);
        }

        public List<ListMailDto> GetSendandReceiverMailnameListAllbyTrashId(int id)
        {
            var mail = _MailDal.GetSendandReceiverMailnameListAllbyTrashId(id);
            return _mapper.Map<List<ListMailDto>>(mail);
        }

        public List<ListMailDto> GetSendandReceiverMailnameListAllbyİmportId(int id)
        {
            var mail = _MailDal.GetSendandReceiverMailnameListAllbyİmportId(id);
            return _mapper.Map<List<ListMailDto>>(mail);
        }

        public void TDelete(int id)
        {
            _MailDal.Delete(id);
        }

        public Mail TGetById(int id)
        {
            return _MailDal.GetById(id);
        }

        public ListMailDto TGetByIddto(int id)
        {
            var mail = _MailDal.GetByIdMailId(id);
            return _mapper.Map<ListMailDto>(mail);
        }

        public List<Mail> TGetListAll()
        {
            return _MailDal.GetListAll();
        }

        public void TInsert(Mail entity)
        {

            _MailDal.Insert(entity);

        }

        public void TUpdate(Mail entity)
        {
            _MailDal.Update(entity);
        }
    }
}
