using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public abstract class BaseReadService<T1, T2> : IReadService<T1> 
        where T1 : IDto, new()
        where T2 : class, new()
    {
        private readonly IRepository<T2> _repository;
        private readonly IMapper _mapper;

        public BaseReadService(IRepository<T2> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<T1>> ReadAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => _mapper.Map<T1>(e));
        }

        public virtual async Task<T1?> ReadByKeyAsync(object key)
        {
            var entity = await _repository.GetByKeyAsync(key);
            return _mapper.Map<T1>(entity);
        }

        public virtual bool Exists(object key)
        {
            return _repository.Exists(key);
        }
    }
}
