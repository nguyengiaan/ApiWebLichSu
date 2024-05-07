using ApiWebLichSu.Data;

namespace ApiWebLichSu.Model
{
    public class Ranking
    {
        public int Id_Ranking { get; set; }
        public int score { get; set; }
        public string Id { get; set; }
        public ApplicationUser user { get; set; }
    }
}
