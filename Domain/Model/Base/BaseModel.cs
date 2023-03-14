
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Domain.Model.Base
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public void SetId(int id)
        {
            Id = id;
        }
        public void Add()
        {
            CreatedAt=DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public void Update()
        {
            UpdatedAt=DateTime.Now;
        }
    }
}
