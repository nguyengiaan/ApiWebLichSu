using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWebLichSu.Model
{
    public class Users
    {

        [Key]
        public int ID_USER {  get; set; }
        public string NAME_USER { get; set; }
        public string USERNAME {  get; set; }
        public string PASSWORD_USER { get; set; }
        public List<Permission> Permissions { get; set; }
        public List<History> Historys { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Quest> quests { get; set; }
    }
}
