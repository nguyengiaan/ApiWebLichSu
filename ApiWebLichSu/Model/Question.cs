namespace ApiWebLichSu.Model
{
    public class Question
    {
        public int Id_Question { get; set; }
        public string Question_quest { get; set; }
        public int Id_quest { get; set; }
        public int id_Answer { get; set; }
        public Quest Quest { get; set; }
    }
}
