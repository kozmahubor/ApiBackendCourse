using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_course.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Hubor";
        public int Vit { get; set; } = 100;
        public int Int { get; set; } = 10;
        public int Str { get; set; } = 50;
        public int Dex { get; set; } = 25;
        public RpgClass Class { get; set; } = RpgClass.Fighter;
        public User? User { get; set; }
        public Weapon? Weapon { get; set; }
        public List<Skill>? Skills { get; set; }
    }
}