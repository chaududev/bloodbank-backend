using Domain.Base;
using Domain.Model.BloodRegister;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model.Users
{
    public class Hospital : BaseModel
    {
        [MaxLength(50)]
        public string Name { get; private set; }
        [MaxLength(250)]
        public string Address { get; private set; }
        [MaxLength(50)]
        public string Lat { get; private set; }
        [MaxLength(50)]
        public string Long { get; private set; }
        [JsonIgnore]
        public virtual List<User> Users { get; private set; }
        [JsonIgnore]
        public virtual List<Register> Confirm { get; private set; }

        public Hospital(string name, string address, string lat, string @long)
        {
            Add();
            Update(name, address, lat, @long);
            Confirm = new List<Register>();
            Users = new List<User>();
        }

        public void Update(string name,string address,string lat,string @long)
        {
            Update();
            Name = name.Trim();
            Address=address.Trim();
            Lat = lat.Trim();
            Long = @long.Trim();
        }
    }
}
