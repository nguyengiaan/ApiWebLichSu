namespace ApiWebLichSu.Model
{
    public class Quest
    {
        public int Id_quest { get; set; }
        public string Question { get; set; }
        public string Id { get; set; }
        public AnswerQuest  Answer { get; set; }
        public int id_questcollection { get; set; }
        public List<Question> Questions { get; set;}
        public QuestCollection questCollection { get; set; }
    }
}
