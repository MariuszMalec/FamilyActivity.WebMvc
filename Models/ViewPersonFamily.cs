using FamilyActivity.WebMvc.Enums;

namespace FamilyActivity.WebMvc.Models
{
    public class ViewPersonFamily
    {
        public int Id { get; set; }
        public PersonFamily PersonName { get; set; }
        public string? PersonPicture { get; set; }
    }
}
