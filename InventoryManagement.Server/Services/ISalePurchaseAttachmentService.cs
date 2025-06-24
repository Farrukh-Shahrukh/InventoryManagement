using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface ISalePurchaseAttachmentService
    {
        public List<SalePurchaseAttachmentDTO> GetAllSalePurchaseAttachment();
        public SalePurchaseAttachmentDTO GetSalePurchaseAttachmentById(int id);
        public SalePurchaseAttachmentDTO CreateSalePurchaseAttachment(SalePurchaseAttachmentDTO SalePurchaseAttachmentDto);
        public SalePurchaseAttachmentDTO UpdateSalePurchaseAttachment(int id, SalePurchaseAttachmentDTO SalePurchaseAttachmentDto);
        public void DeleteSalePurchaseAttachment(int id);
    }
}
