using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.SaleListing
{
    public interface ISaleListingRepository
    {
        Task<List<SaleListingModel>> GetSaleListingsAsync(SaleListingDto dto);
    }
}
