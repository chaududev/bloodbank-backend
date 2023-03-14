using AutoMapper;
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