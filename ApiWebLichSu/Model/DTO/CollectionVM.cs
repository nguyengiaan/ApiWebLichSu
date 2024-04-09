using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWebLichSu.Model
{
    public class CollectionVM
    {
        public string id { get; set; }
        public string title_collection { get; set; }
        public string? image_quest { get; set; }
        [NotMapped]
        public  IFormFile file { get; set; }
    }
}
