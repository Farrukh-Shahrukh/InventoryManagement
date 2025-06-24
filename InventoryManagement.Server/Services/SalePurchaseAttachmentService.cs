using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Data.Models;

namespace investmentsManagement.Server.Services
{
    public class SalePurchaseAttachmentService : ISalePurchaseAttachmentService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SalePurchaseAttachmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SalePurchaseAttachmentDTO> GetAllSalePurchaseAttachment()
        {
            var SalePurchaseAttachment = _context.SalePurchaseAttachment.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<SalePurchaseAttachmentDTO>>(SalePurchaseAttachment);
        }
        public SalePurchaseAttachmentDTO GetSalePurchaseAttachmentById(int id)
        {
            var SalePurchaseAttachment = _context.SalePurchaseAttachment.Find(id);
            if (SalePurchaseAttachment == null)
            {
                return null;
            }
            return _mapper.Map<SalePurchaseAttachmentDTO>(SalePurchaseAttachment);
        }
        public SalePurchaseAttachmentDTO CreateSalePurchaseAttachment(SalePurchaseAttachmentDTO SalePurchaseAttachmentDto)
        {
            var Project = _mapper.Map<SalePurchaseAttachment>(SalePurchaseAttachmentDto);
            _context.SalePurchaseAttachment.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<SalePurchaseAttachmentDTO>(Project);
        }

        public SalePurchaseAttachmentDTO UpdateSalePurchaseAttachment(int id, SalePurchaseAttachmentDTO SalePurchaseAttachmentDto)
        {
            var SalePurchaseAttachment = _context.SalePurchaseAttachment.FirstOrDefault(p => p.Id == id);
            if (SalePurchaseAttachment == null)
            {
                throw new Exception("SalePurchaseAttachment not found");
            }

            _mapper.Map(SalePurchaseAttachmentDto, SalePurchaseAttachment);
            _context.SaveChanges();
            return _mapper.Map<SalePurchaseAttachmentDTO>(SalePurchaseAttachment);
        }

        public void DeleteSalePurchaseAttachment(int id)
        {
            var SalePurchaseAttachment = _context.SalePurchaseAttachment.FirstOrDefault(p => p.Id == id);
            if (SalePurchaseAttachment == null)
            {
                throw new Exception("SalePurchaseAttachment not found");
            }
            SalePurchaseAttachment.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
