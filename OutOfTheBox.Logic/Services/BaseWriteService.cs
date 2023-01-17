using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public abstract class BaseWriteService<T1, T2, T3, T4> : IWriteService<T2, T3, T4> 
        where T1 : class, new()
        where T2 : IDto, new()
        where T3 : ICreateRequest, new()
        where T4 : IUpdateRequest, new()
    {
        private readonly IRepository<T1> _repository;
        private readonly IMapper _mapper;

        public BaseWriteService(IRepository<T1> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<T2?> CreateAsync(T3 createRequest)
        {
            T1 entity = _mapper.Map<T1>(createRequest);
            var returnedEntity = await _repository.InsertAsync(entity);
            return _mapper.Map<T2>(returnedEntity);
        }

        public virtual async Task<bool> DeleteAsync(object key)
        {
            var existingEntity = await _repository.GetByKeyAsync(key);
            if (existingEntity == null)
            {
                return false;
            }
            await _repository.DeleteAsync(existingEntity);
            return true;
        }

        public virtual async Task<T2?> UpdateAsync(T4 updateRequest, object key)
        {
            T1 entity = _mapper.Map<T1>(updateRequest);
            var returnedEntity = await _repository.UpdateAsync(entity, key);
            return _mapper.Map<T2>(returnedEntity);
        }
    }
}
