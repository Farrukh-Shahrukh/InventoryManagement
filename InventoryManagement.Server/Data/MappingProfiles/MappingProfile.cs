using AutoMapper;
using investmentsManagement.Server.Data.Models;
using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Data.MappingProfiles
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

            CreateMap<Investments, InvestmentsDTO>()
              .ReverseMap()
              .ForMember(dest => dest.Investor, opt => opt.Ignore());

            CreateMap<Ladger, LadgerDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Investor, opt => opt.Ignore());

            CreateMap<Ladger, LadgerDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Investor, opt => opt.Ignore());

            CreateMap<Projects, ProjectsDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Expences, opt => opt.Ignore())
                .ForMember(dest => dest.Investment, opt => opt.Ignore());

            CreateMap<ExpenceTypes, ExpenceTypesDTO>()
               .ReverseMap()
               .ForMember(dest => dest.Expences, opt => opt.Ignore());


            CreateMap<Expences, ExpencesDTO>()
               .ReverseMap()
               .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.ExpenceTypes, opt => opt.Ignore());

            CreateMap<Purchase, PurchaseDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ReverseMap()
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}
