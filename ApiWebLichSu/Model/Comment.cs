using ApiWebLichSu.Data;

namespace ApiWebLichSu.Model
{
    public class Comment
    {
        public int COMNENT_ID { get; set; }
        public int ID_USER { get; set; }
        public string CONTENT_COMMENT { get; set; } 

        public string Id { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}
