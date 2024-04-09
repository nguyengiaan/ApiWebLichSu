namespace ApiWebLichSu.Model
{
    public class Catogery
    {
        public int ID_CATOGERY { get; set; }
        public string NAME_CATOGERY { get; set; }

        public List<History> HISTORY { get; set; }
        public Catogery() 
        { 
            HISTORY = new List<History>();
        }
    }
}
