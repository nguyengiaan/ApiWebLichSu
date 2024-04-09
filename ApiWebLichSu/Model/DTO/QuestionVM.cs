namespace ApiWebLichSu.Model.DTO
{
    public class QuestionVM
    {
        public int id_questcollection { get; set; }
        public string Id_user { get; set; }
        public string Question { get; set; }
        public List<string> QuestionList { get; set;}
        public string answer { get; set; }
    }
}
