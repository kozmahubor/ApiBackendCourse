using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_course.Dtos.Weapon;

namespace Backend_course.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWepon);  
    }
}