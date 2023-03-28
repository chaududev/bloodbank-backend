using Domain.Model.BloodRegister;

namespace Application.IService
{
    public interface IBloodGroupService
    {
        (IEnumerable<BloodGroup> data, int total) GetList(string? key, int? pageSize, int? page);
        BloodGroup GetById(int id);
        void Add(string name, string description);
        void Update(int id, string name, string description);
        void Delete(int id);
    }
}
