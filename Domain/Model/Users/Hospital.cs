using Domain.Model.Base;
using Domain.Model.BloodRegister;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Users
{
    public class Hospital : BaseModel
    {
        [MaxLength(50)]
        public string Name { get; private set; }
        [MaxLength(100)]
        public string Address { get; private set; }

        public virtual List<User> Users { get; private set; }
        public virtual List<Register> Confirm { get; private set; }

        public Hospital(string name,string address)
        {
            Add();
            Update(name,address);
            Confirm = new List<Register>();
            Users=new List<User>();
        }
        public void Update(string name,string address)
        {
            Update();
            Name = name.Trim();
            Address=address.Trim();
        }
    }
}
