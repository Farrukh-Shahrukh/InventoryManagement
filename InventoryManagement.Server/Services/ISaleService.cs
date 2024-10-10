using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface ISaleService
    {
        List<SaleDTO> GetAllSales();
        SaleDTO GetSaleById(int id);
        SaleDTO CreateSale(SaleDTO saleDto);
    }
}
