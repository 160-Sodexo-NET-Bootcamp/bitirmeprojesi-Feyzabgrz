using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PCP.Entities.Concrete.Identity;
using PCP.Entities.Dtos;
using PCP.Services.FluentValidator;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogProjectAPI.Controller
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IValidatorFactory _validatorFactory;

        public UserController(SignInManager<User> signInManager,
            UserManager<User> userManager, IValidatorFactory validatorFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _validatorFactory = validatorFactory;

        }

        [HttpPost]
        [Route("UserCreate")]
        public async Task<ActionResult> UserCreate([FromBody] UserDto model)
        {
            var ValidateMessage = _validatorFactory.GetDefaultValidator<UserDto>().Validate(model).Errors.FirstOrDefault();
            if (ValidateMessage != null)
            {
                 return BadRequest(ValidateMessage.ErrorMessage);
            }


            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.UserName.Trim(),
                    Email = model.EmailAddress.Trim()
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password.Trim());
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        if (error.Code == "DuplicateEmail")
                            return BadRequest("Email adresi daha önce kullanıldı!");
                        if (error.Code == "DuplicateUserName")
                            return BadRequest("Bu kullanıcı adı daha önce kullanıldı!");
                    }
                }
                //_userManager.AddToRoleAsync(user, "User").Wait();

                //todo:mail hoşgeldin
                return Ok("Kullanıcı oluşturma işlemi başarılı!");
            }
            return BadRequest("Bilgilerinizi kontrol ediniz!");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] UserDto model)
        {

            var ValidateMessage = _validatorFactory.GetDefaultValidator<UserDto>().Validate(model).Errors.FirstOrDefault();
            if (ValidateMessage != null)
            {
                return BadRequest(ValidateMessage.ErrorMessage);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.UserName.Trim());
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password.Trim()))
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKey"));

                    var token = new JwtSecurityToken(
                        issuer: "http://google.com",
                        audience: "http://google.com",
                        expires: DateTime.UtcNow.AddHours(1),
                        claims: claims,
                        signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else
                {
                    return BadRequest("Giriş yapılamadı.Lütfen bilgilerinizi kontrol ediniz!");
                }
            }
            else
            {
                return BadRequest("Lütfen bilgilerinizi kontrol ediniz!");
            }
        }

    }
}
