namespace ApiWebLichSu.Model
{
    public class History
    {
        public string Id { get; set; }
        public int ID_HISTORY { get; set; }
        public string CONTENT { get; set; }
        public int ?ID_CATOGERY { get; set; }
        public string TITLE { get; set; }
        public Catogery CATOGERY { get; set; }
      
    }
}
