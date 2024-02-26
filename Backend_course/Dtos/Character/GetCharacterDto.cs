using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_course.Dtos.Armor;
using Backend_course.Dtos.Skill;
using Backend_course.Dtos.Weapon;

namespace Backend_course.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Hubor";
        public int Vit { get; set; } = 100;
        public int Int { get; set; } = 10;
        public int Str { get; set; } = 50;
        public int Dex { get; set; } = 25;
        public RpgClass Class { get; set; } = RpgClass.Fighter;
        public GetWeaponDto? Weapon { get; set; }
        public List<GetSkillDto>? Skills { get; set; }
        public List<GetArmorDto>? Armors { get; set; }
    }
}