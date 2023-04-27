using AutoMapper;
using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Domain.Entities;


namespace EMarketAlex2.Core.Aplication.Mappings
{
    public class GeneralProfile : Profile
    {

        public GeneralProfile()
        {
            CreateMap<Anuncios, AnuncioViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.Ignore())
                       .ForMember(dest => dest.userName, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                  .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                   .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());

            CreateMap<Anuncios, SaveAnuncioViewModel>()
                    .ForMember(dest => dest.CategoriaList, opt => opt.Ignore())
                  .ForMember(dest => dest.CategoryName, opt => opt.Ignore())
                   .ForMember(dest => dest.File1, opt => opt.Ignore())
                    .ForMember(dest => dest.File2, opt => opt.Ignore())
                               .ForMember(dest => dest.File3, opt => opt.Ignore())
                  .ForMember(dest => dest.File4, opt => opt.Ignore())
                  .ForMember(dest => dest.File5, opt => opt.Ignore())
           
                       .ReverseMap()
                   .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
               .ForMember(dest => dest.user, opt => opt.Ignore())
                  .ForMember(dest => dest.categorias, opt => opt.Ignore());


            CreateMap<Categorias, CategoriasViewModel>()
    .ForMember(dest => dest.CantidadAnunciosCate, opt => opt.Ignore())
           .ForMember(dest => dest.CantidadUsuarioAnun, opt => opt.Ignore());

            CreateMap<Categorias, SaveCategoriaViewModel>()
    .ReverseMap()
        .ForMember(dest => dest.Anuncios, opt => opt.Ignore());


            CreateMap<Users, UserViewModel>()
.ReverseMap()
   .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
    .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());


            CreateMap<Users, SaveUserViewModel>()
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())

                .ForMember(dest => dest.File, opt => opt.Ignore())
.ReverseMap()
   .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
    .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());



        }
    }

}