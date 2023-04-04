
using Domain.Enum;
using Domain.Model.BloodRegister;

namespace Application.IService
{
    public interface IRegisterService
    {
        (IEnumerable<Register> data, int total) GetList(string? key, int? pageSize, int? page);
        (IEnumerable<Register> data, int total) GetListByUser(string username, int? pageSize, int? page);
       Register GetById(int id);
        void Add(string note, Status status, int bloodId, string userId, DateTime timeSign, int qR, int hospitalId, int ml);
        void Update(int id, string note, Status status, int bloodId, DateTime timeSign, int hospitalId,int ml);
        void Delete(int id);
    }
}
