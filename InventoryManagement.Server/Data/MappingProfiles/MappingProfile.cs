using AutoMapper;
using InventoryManagement.Server.Data.Models;
using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Models;

namespace InventoryManagement.Server.Data.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Sale, SaleDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ReverseMap()
                .ForMember(dest => dest.Product, opt => opt.Ignore());
            CreateMap<Investors, InvestorsDTO>()
               .ReverseMap()
               .ForMember(dest => dest.Investments, opt => opt.Ignore());
            CreateMap<Purchase, PurchaseDTO>()
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.Name))
                .ReverseMap()
                .ForMember(dest => dest.Product, opt => opt.Ignore());
            CreateMap<Expences, ExpencesDTO>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ExpenceTypeId))
                .ReverseMap()
                .ForMember(dest => dest.ExpenceTypeId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.ExpenceTypes, opt => opt.Ignore());
        }
    }
}
