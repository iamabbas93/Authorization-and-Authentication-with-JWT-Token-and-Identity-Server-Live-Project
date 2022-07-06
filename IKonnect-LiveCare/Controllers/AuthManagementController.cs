using BusinessLogic.Interface;
using IdentityModel.OidcClient;
using IKonnect_LiveCare.Configuration;
using IKonnect_LiveCare.Dtos.Requests;
using IKonnect_LiveCare.Dtos.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Core;
using OAuth2ClientHandler;
using OAuth2ClientHandler.Authorizer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IKonnect_LiveCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private RestClient _client;
        private readonly ISettings _settings;
        private readonly IConfiguration _configuration;
        private readonly EmailConfig _emailConfig;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthManagementController(UserManager<IdentityUser> userManager,IOptionsMonitor<JwtConfig> optionsMonitor , IOptions<EmailConfig> emailConfig, IConfiguration configuration,ISettings settings, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _configuration = configuration;
            _emailConfig = emailConfig.Value;
            _settings = settings;
            _signInManager = signInManager;
        }

      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm]UserRegistrationDto registrationDto)
        {

            //  var results=  await _settings.SendEmail(_emailConfig.Host, _emailConfig.Port, _emailConfig.Mail, _emailConfig.Password, _emailConfig.Mail, registrationDto.Email, "VerifyEmail", "<a>Verify Email</a>");
            //  var resultss= EmailToProviderApproveCPS(_emailConfig.Host, _emailConfig.Port, _emailConfig.Mail, _emailConfig.Password, _emailConfig.Mail, registrationDto.Email, "VerifyEmail", "<a>Verify Email</a>");
                
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(registrationDto.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                    {
                        "Email Already in Use."
                    },
                        Success = false
                    });

                }

                var newUser = new IdentityUser() { Email = registrationDto.Email, UserName = registrationDto.UserName };
                var isCreated = await _userManager.CreateAsync(newUser, registrationDto.Password);

                if (isCreated.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                    var link = Url.Action("VerifyEmail","Account", new { userId = newUser.Id, code }, Request.Scheme, Request.Host.ToString());

                    var resultss =await EmailToProviderApproveCPS(_emailConfig.Host, _emailConfig.Port, _emailConfig.Mail, _emailConfig.Password, _emailConfig.Mail, registrationDto.Email, "VerifyEmail", "<a href=" + link + ">Verify Email</a>");

                    // var result=  await _settings.SendEmail(_emailConfig.Host, _emailConfig.Port, _emailConfig.Mail, _emailConfig.Password, _emailConfig.Mail, registrationDto.Email, "VerifyEmail", "<a href="+link+">Verify Email</a>");
                    // await _emailService.SendAsync("test@test.com", "email verify", $"<a href=\"{link}\">Verify Email</a>", true);

                    if (resultss == true)
                    {
                        return RedirectToAction("EmailVerification");
                    }
                    else
                    {
                        return BadRequest();
                    }
                 

                    //var jwtToken= GenerateJwtToken(newUser);
                    // return Ok(new RegistrationResponse()
                    // {
                    //     Success = true,
                    //     Token = jwtToken

                    // });
                }
                else
                {

                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList()
                    ,
                        Success = false
                    });

                }

            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
            {
                "Invalid Payload"
            },
                Success=false
            });

        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
               
                
               if(IsValid(user.Email))
                {
                    var userMa = await _userManager.FindByEmailAsync(user.Email);
                    var emailconfirmed = await _signInManager.CanSignInAsync(userMa);

                    if (emailconfirmed == true)
                    {
                        var existingUser = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);


                        if (existingUser.Succeeded == false)
                        {
                            return BadRequest(new RegistrationResponse()
                            {
                                Errors = new List<string>() {
                                "Invalid login request"
                            },
                                Success = false
                            });
                        }
                        else
                        {
                           await _signInManager.CreateUserPrincipalAsync(userMa);
                            var jwtToken = GenerateJwtToken(userMa);

                            return Ok(new RegistrationResponse()
                            {
                                Success = true,
                                Token = jwtToken
                            });
                        }


                    }
                    else
                    {
                        return BadRequest(new RegistrationResponse()
                        {
                            Errors = new List<string>() {
                                "Email Not confirmed"
                            },
                            Success = false
                        });
                    }


                }
                else
                {
                    var userMa = await _userManager.FindByNameAsync(user.Email);
                    var emailconfirmed = await _signInManager.CanSignInAsync(userMa);

                    if (emailconfirmed == true)
                    {
                        var existingUser = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);


                        if (existingUser.Succeeded == false)
                        {
                            return BadRequest(new RegistrationResponse()
                            {
                                Errors = new List<string>() {
                                "Invalid login request"
                            },
                                Success = false
                            });
                        }
                        else
                        {
                            await _signInManager.CreateUserPrincipalAsync(userMa);
                            var jwtToken = GenerateJwtToken(userMa);

                            return Ok(new RegistrationResponse()
                            {
                                Success = true,
                                Token = jwtToken
                            });
                        }


                    }
                    else
                    {
                        return BadRequest(new RegistrationResponse()
                        {
                            Errors = new List<string>() {
                                "Email Not confirmed"
                            },
                            Success = false
                        });
                    }

                }
             



            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        //[HttpPost]
        //[Route("")]
        //public RefreshToken GenerateRefreshToken(string ipAddress)
        //{
        //    // generate token that is valid for 7 days
        //    using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        //    var randomBytes = new byte[64];
        //    rngCryptoServiceProvider.GetBytes(randomBytes);
        //    var refreshToken = new RefreshToken
        //    {
        //        Token = Convert.ToBase64String(randomBytes),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        Created = DateTime.UtcNow,
        //        CreatedByIp = ipAddress
        //    };

        //    return refreshToken;
        //}

        [NonAction]
        private void setTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        [NonAction]
        private string ipAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }


        [NonAction]
        private bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }



        [NonAction]
        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(new []
                {
                        new Claim("Id",user.Id),
                        new Claim(JwtRegisteredClaimNames.Email,user.Email),
                        new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                }),
                Expires=DateTime.UtcNow.AddSeconds(25),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;

        }

        [NonAction]

        public async  Task<bool> EmailToProviderApproveCPS(string host, int port, string username, string password, string from, string to, string subject, string html)
        {

            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(to)); //Email Send To  // replace with valid value 

                message.From = new MailAddress(from); //Email Send From // replace with valid value
                message.Subject = subject;
                message.Body = html;





                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = username,  //website email // replace with valid value
                        Password = password //email password // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    //return RedirectToAction("Index", "Practices");

                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            
          
        }


        [HttpPost]
        [Route("AuthroizeDrChrono")]
        public async Task<string> testAuuth()
        {

            var options = new OAuthHttpHandlerOptions
            {
                AuthorizerOptions = new AuthorizerOptions
                {
                    AuthorizeEndpointUrl = new Uri("https://drchrono.com/o/authorize"),
                    TokenEndpointUrl = new Uri("https://drchrono.com/o/token"),
                    ClientId = "U7zD7xlPcIZ4XXRF619oLNh8uLRBReUb2g2qkSox",
                    ClientSecret = "RUELYiti0J89H9qRkNOy9QCwGToe3aBHXvkmdhTySrYZwZz4ZD2LxY5qozZT78Vta0HW3FP1Fy9P9zFS5NF2w428QKQYltD4h9VWCeslsd0IYel2tpWE3GN1Ol8bbrxt",
                    GrantType = GrantType.ResourceOwnerPasswordCredentials,
                 
                    Username = "iamabbas93",
                    Password = "Iamabbas@0786",
                    CredentialTransportMethod = CredentialTransportMethod.FormAuthenticationCredentials

                }
            };

            using (var client = new HttpClient(new OAuthHttpHandler(options)))
            {
                try
                {
                    client.BaseAddress = new Uri("https://drchrono.com");
                    var response = await client.GetAsync("/api/patients");

                }
                catch (Exception ex)
                {

                    throw;
                }
               
               
            }


            var baseURL = _configuration["DrChronoBaseUrl"];
            var redirectURI = _configuration["redirectURI"];
            var clientID = _configuration["clientID"];
            var clientSecret = _configuration["clientSecret"];


          
         


         




            return "Code";


        }


        [HttpPost]
        [Route("DeleteTest")]
        public void delete([FromBody]int id)
        {

        }



    }
}
