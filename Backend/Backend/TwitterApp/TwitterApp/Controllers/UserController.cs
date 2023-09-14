using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterApp.Dto.UserD;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;
using TwitterApp.Service;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUserByUsername/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {

            var user = _userService.GetUserByUsername(username);


            if (user == null)
            {
                return BadRequest("Nema korisnika sa datim korisničkim imenom.");
            }
            return Ok(user);
        }


        [HttpPost("Dodavanje novog korisnika")]
        public IActionResult CreateUser(UserDtoAdd user)
        {
            try
            {
                var NewUser = _userService.CreateUser(user);
                if (NewUser == null)
                {
                    return BadRequest("Korisnik nije validan");
                }


                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Došlo je do greške prilikom kreiranja korisnika.");
            }
        }
        [HttpPut("Update korisnika")]

        public async Task<IActionResult> UpdateUser(UserDtoPut updateUser)
        {
            try
            {

                if (_userService.UpdateUser(updateUser))
                {
                    return Ok("Korisnik je uspešno ažuriran.");

                }
                return NotFound("Korisnik nije pronađen.");

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpDelete("DeleteUser/{username}")]
        public IActionResult DeleteUser(string username)
        {
            try
            {
                var user = _userService.GetUserByUsername(username);
                if (user == null)
                {
                    return NotFound("Korisnik nije pronađen.");
                }
                _userService.DeleteUser(username);
                return Ok("Korisnik je uspešno obrisan.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Došlo je do greške prilikom brisanja korisnika.");
            }
        }
    }
}
