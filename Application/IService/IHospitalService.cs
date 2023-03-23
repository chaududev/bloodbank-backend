using Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
