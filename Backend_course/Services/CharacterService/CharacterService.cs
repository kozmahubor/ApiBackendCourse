global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend_course.Data;

namespace Backend_course.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public IHttpContextAccessor _httpContextAccessor { get; }
        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        private string  GetUserRole() => _httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.Role)!;

        //create
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(updatedCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            // character.Id = dbCharacters.Max(c => c.Id) + 1;
            
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = 
                await _context.Characters
                .Where(c => c.User!.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacterDto>(c))
                .ToListAsync();
            return serviceResponse;
        }
        //listAll
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = 
                GetUserRole().Equals("Admin") ? 
                    await _context.Characters.ToListAsync() : 
                    await _context.Characters
                        .Include(c => c.Weapon)
                        .Include(c => c.Skills)
                        .Where(c => c.User!.Id == GetUserId()).ToListAsync();

            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceResponse;
        }
        //list
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>( );
            var dbCharacter = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills)
            .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);

            return serviceResponse;

            
            /* if(character is not null)
                
                return character;
                throw new Exception("Character not found!"); */
            
            // return characters.FirstOrDefault(c => c.Id == id)!;
        }
        //update
        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try {
            
            var dbCharacter = 
                    await _context.Characters
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
            if (dbCharacter is null || dbCharacter.User!.Id != GetUserId())
                throw new Exception($"Character with Id '{updatedCharacter.Id}' not found"); 

            _mapper.Map(updatedCharacter, dbCharacter);                
            /* character.Name = updatedCharacter.Name;
            character.Vit = updatedCharacter.Vit;
            character.Int = updatedCharacter.Int;
            character.Str = updatedCharacter.Str;
            character.Dex = updatedCharacter.Dex;
            character.Class = updatedCharacter.Class; */

            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        //delete
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try {
            
            var character = await _context.Characters
            .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            if (character is null)
                throw new Exception($"Character with Id '{id}' not found"); 

            _context.Characters.Remove(character);        

            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                   await _context.Characters
                   .Where(c => c.User!.Id == GetUserId())
                   .Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        //delteAll
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            try {
            
            if (dbCharacters is null)
                throw new Exception("Character was not found"); 

            foreach (var character in dbCharacters)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }            


            serviceResponse.Data = 
                    await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
            
        }
    
        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId &&
                        c.User!.Id == GetUserId());

                if(character is null)
                {
                    response.Success = false;
                    response.Message = "Character was not found!";
                    return response;
                }

                var skill = await _context.Skills
                    .FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);

                if(skill is null)
                {
                    response.Success = false;
                    response.Message = "Skill was not found!";
                    return response;
                }
                else if(character.Skills!.Contains(skill))
                {
                    response.Success = false;
                    response.Message = "This character already has this skill!";
                    return response;
                }

                character.Skills!.Add(skill);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}