using ApiWebLichSu.Model;
using Microsoft.AspNetCore.Identity;

namespace ApiWebLichSu.Data
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public  List<Comment> Comments { get; set; }

        public List<History> History { get; set; }
        
        public ApplicationUser()  
        {
            Comments = new List<Comment>(); 

            History = new List<History>();

                

        }    
    }
}
