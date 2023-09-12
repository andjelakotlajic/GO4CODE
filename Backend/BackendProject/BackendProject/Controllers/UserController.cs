
using AutoMapper;
using BackendProject.Dto.UserD;
using BackendProject.Migrations;
using BackendProject.Model;
using BackendProject.Repository;
using BackendProject.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using User = BackendProject.Model.User;

namespace BackendProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private  IUser _userRepository;

        public UserController(IUser UserRepository, IMapper mapper)
        {
            _userRepository = UserRepository;
            _mapper = mapper;
        }

        [HttpGet("getUserByUsername/{username}")]
        public IActionResult GetUserByUsername(string username)
        {

            User user = _userRepository.GetUserByUsername(username);


            if (user == null)
            {
                return BadRequest("Nema korisnika sa datim korisničkim imenom.");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }


        [HttpPost("Dodavanje novog korisnika")]
        public IActionResult CreateUser(UserDtoAdd user)
        {
            try
            {
                var _user = _mapper.Map<User>(user);
                if (_user == null)
                {
                    return BadRequest("Korisnik nije validan");
                }
                _userRepository.CreateUser(_user);

                return Ok("Korisnik je uspešno kreiran.");
            }catch (Exception ex)
            {
                return StatusCode(500, "Došlo je do greške prilikom kreiranja korisnika.");
            }
        }
        [HttpPut("Update korisnika")]

            public IActionResult UpdateUser(UserDtoPut updateUser)
            {
                try
                {
                    var existingUser = _userRepository.GetUserByUsername(updateUser.UserName);
               

                    if (existingUser == null)
                    {
                        return NotFound("Korisnik nije pronađen.");
                }

                var user = _mapper.Map<User>(updateUser);
                _userRepository.UpdateUser(user);
                return Ok("Korisnik je uspešno ažuriran.");
                }
               
                catch (Exception ex)
                {
                    return StatusCode(500, "Došlo je do greške prilikom ažuriranja korisnika.");
                }
            }


        [HttpDelete("DeleteUser/{username}")]
        public IActionResult DeleteUser(string username)
        {
            try
            {
                var user = _userRepository.GetUserByUsername(username);
                if (user == null)
                {
                    return NotFound("Korisnik nije pronađen.");
                }

                _userRepository.DeleteUser(username);
                return Ok("Korisnik je uspešno obrisan.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Došlo je do greške prilikom brisanja korisnika.");
            }
        }

    }

   
   
}
