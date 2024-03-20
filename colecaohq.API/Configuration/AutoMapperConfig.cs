using AutoMapper;
using colecaohq.API.ViewModels;
using colecaohq.Business.Models;

namespace colecaohq.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Editora, EditoraViewModel>().ReverseMap();
            CreateMap<EquipePerssonagem, EquipePerssonagemViewModel>().ReverseMap();
            CreateMap<TituloHQ, TituloHQView>();
            CreateMap<HqPerssonagem, TituloHQView>();

            CreateMap<TituloHQ, TituloHQView>()
                .ForMember(dest => dest.NomeEditora, opt => opt.MapFrom(src => src.Editora.NomeEditora));

            CreateMap<HqPerssonagem, EquipePerssonagemViewModel>()
                .ForMember(dest => dest.NomeEquipePerssonagem, opt => opt.MapFrom(src => src.EquipePerssonagem.NomeEquipePerssonagem));

            CreateMap<HqPerssonagem, TituloHQView>()
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.TituloHQ.Titulo));
        }
    }
}
