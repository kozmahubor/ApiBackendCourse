using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend_course.Data;
using Backend_course.Dtos.Weapon;

namespace Backend_course.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        public IHttpContextAccessor _httpContextAccessor { get; }
        public IMapper _mapper { get; }
        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWepon)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWepon.UserId && 
                        c.User!.Id == int.Parse(_httpContextAccessor.HttpContext!.User
                            .FindFirstValue(ClaimTypes.NameIdentifier)!));

                if(character is null)
                {
                    response.Success = false;
                    response.Message = "Character was not found";
                    return response;
                }

                var weapon = new Weapon
                {
                    Name = newWepon.Name,
                    Damage = newWepon.Damage,
                    Character = character   
                };
                if (character.Weapon != null)
                {
                    _context.Weapons.Remove(character.Weapon!);
                    character.Weapon = null;
                }
                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}