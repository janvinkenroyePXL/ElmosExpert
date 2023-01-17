using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IWriteService<T1, T2, T3> 
        where T1 : IDto
        where T2 : ICreateRequest
        where T3 : IUpdateRequest
    {
        Task<T1?> UpdateAsync(T3 updateRequest, object key);
        Task<bool> DeleteAsync(object key);
        Task<T1?> CreateAsync(T2 createRequest);
    }
}
