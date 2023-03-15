using Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Users;

namespace Domain.Model.BloodRegister
{
    public enum Status
    {
        None,
        Register,
        Accept,
        Processing,
        Finished,
        Cancel
    }
    public class Register : BaseModel
    {
        public string Note { get; private set; }
        public Status Status { get; private set; }
        [ForeignKey("BloodGroup")]
        public int BloodId { get; private set; }
        public virtual BloodGroup BloodGroup { get; private set; }
        [MaxLength(450)]
        public string UserId { get; private set; }
        [ForeignKey("UserId")]
        public virtual User User { get; private set; }
        //xacnhan
        public DateTime TimeSign { get; private set; }
        [ForeignKey("Image")]
        public int QR { get; private set; }
        public virtual Image Image { get; private set; }
        public int HospitalId { get; private set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; private set; }

        public Register(string note, Status status, int bloodId, string userId, DateTime timeSign, int qR, int hospitalId)
        {
            Add();
            Update(note, status, bloodId, userId, timeSign, qR, hospitalId);
        }
        public void Update(string note, Status status, int bloodId, string userId, DateTime timeSign, int qR, int hospitalId)
        {
            Update();
            Note = note.Trim();
            Status = status;
            BloodId = bloodId;
            UserId = userId;
            TimeSign = timeSign;
            QR = qR;
            HospitalId = hospitalId;
        }
    }
}
