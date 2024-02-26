using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_course.Dtos.Armor;
using Backend_course.Dtos.Skill;
using Backend_course.Dtos.Weapon;

namespace Backend_course
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Armor, GetArmorDto>();
        }
    }
}