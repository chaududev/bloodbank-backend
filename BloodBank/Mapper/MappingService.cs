using AutoMapper;
using BloodBank.ViewModels.BloodGroups;
using BloodBank.ViewModels.Hospitals;
using BloodBank.ViewModels.Images;
using BloodBank.ViewModels.Users;
using Domain.Base;
using Domain.Model.BloodRegister;
using Domain.Model.Users;

namespace BloodBank.Mapper
{
    public class MappingService<TSource, TDestination> : Profile
    {
        private IMapper _mapper;

        public MappingService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
                cfg.CreateMap<Image, ImageViewModel>();
                cfg.CreateMap<BloodGroup, BloodGroupViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Hospital, HospitalViewModel>();
            });

            _mapper = config.CreateMapper();
        }

        public TDestination Map(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> Map(IEnumerable<TSource> source)
        {
            return _mapper.Map<IEnumerable<TDestination>>(source);
        }
        public List<TDestination> Map(List<TSource> source)
        {
            return _mapper.Map<List<TDestination>>(source);
        }
    }
}