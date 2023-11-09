using FamilyActivity.WebMvc.Enums;

namespace FamilyActivity.WebMvc.Models
{
    public class ModelPersonFamily
    {
        public int Id { get; set; }
        public PersonFamily PersonName { get; set; }
        public string? PersonPicture { get; set; }
        public ModelPersonFamily(int id, PersonFamily personName, string? personPicture)
        {
            Id = id;
            PersonName = personName;
            PersonPicture = personPicture;
        }
    }
}
