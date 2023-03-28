using Domain.Model.Users;

namespace Application.IService
{
    public interface IHospitalService
    {
        (IEnumerable<Hospital> data, int total) GetList(string? key, int? pageSize, int? page);
        Hospital GetById(int id);
        void Add(string name, string address,string lat,string longdata);
        void Update(int id, string name, string address, string lat, string longdata);
        void Delete(int id);
    }
}
