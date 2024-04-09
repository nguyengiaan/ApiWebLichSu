namespace ApiWebLichSu.Model
{
    public class Permission
    {
        public int PER_ID { get; set; }
        public int ID_USER { get; set; }
        public string CONTENT_PERMISSION { get; set; }
        public Users Users { get; set; }

    }
}
