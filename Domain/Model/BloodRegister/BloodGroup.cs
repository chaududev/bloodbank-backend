using Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.BloodRegister
{
    public class BloodGroup : BaseModel
    {
        [MaxLength(50)]
        public string Name { get; private set; }
        [MaxLength(100)]
        public string Description { get; private set; }
        public List<Register> Register { get; set; }

        public BloodGroup(string name, string description)
        {
            Add();
            Update(name,description);
            Register = new List<Register>();
        }
        public void Update(string name, string description)
        {
            Update();
            Name = name.Trim();
            Description = description.Trim();
        }
    }
}
