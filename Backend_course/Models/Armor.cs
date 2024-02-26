namespace Backend_course.Models
{
    public class Armor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Resist { get; set; }
        public List<Character>? Characters { get; set; }

    }   
}
