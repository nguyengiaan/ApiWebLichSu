namespace ApiWebLichSu.Model
{
    public class History
    {
        public int ID_HISTORY { get; set; }
        public string CONTENT { get; set; }
        public int ID_USER { get; set; }
        public DateTime DATESUBMIT { get; set; }
        public int ID_CATOGERY { get; set; }
        public string TITLE { get; set; }
        public Users USERS { get; set; }
        public Catogery CATOGERY { get; set; }
      
    }
}
