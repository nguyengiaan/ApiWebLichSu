namespace ApiWebLichSu.Model
{
    public class QuestCollection
    {
        public int id_questcollection {  get; set; }
        public string title_collection { get; set; }
        public string image_quest {  get; set; }
        public string Id { get; set; }
        public List<Quest> Quests { get; set;}
        public QuestCollection() 
        {
            Quests= new List<Quest>();
        }
    }
}
