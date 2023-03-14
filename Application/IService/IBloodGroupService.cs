using Domain.Model.BloodRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
