using Domain.Model.BloodRegister;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Users
{
    public class Hospital 
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public User User { get; private set; }
        public virtual List<Register> Confirm { get; private set; }

        public Hospital(string name, string id)
        {
            Update(name);
            Id = User.Id.Trim();
            Confirm = new List<Register>();
        }
        public void Update(string name)
        {
            Name = name.Trim();

        }
    }
}
