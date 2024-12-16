using AppServerGal.Models;
using AppServerGal.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServerGal.Controllers
{
    [Route("api")]
    [ApiController]
    public class AppAPIController : ControllerBase
    {
        //a variable to hold a reference to the db context!
        private GameDbContext context;
        //a variable that hold a reference to web hosting interface (that provide information like the folder on which the server runs etc...)
        private IWebHostEnvironment webHostEnvironment;
        //Use dependency injection to get the db context and web host into the constructor
        public AppAPIController(GameDbContext context, IWebHostEnvironment env)
        {
            this.context = context;

            this.webHostEnvironment = env;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] DTO.UserLoginDTO userLoginDTO)
        {
            try
            {
                HttpContext.Session.Clear();//התנתקות מכל נסיון התחברות אחר

                //מצא משתמש במסד הנתונים עם שם משתמש תואם 
                Models.User? modelUser = context.GetUser(userLoginDTO.Username);


                //בודק אם המשתמש קיים והאם הסיסמה שלו נכונה ואם לא מחזיר את שגיאת 401
                if(modelUser == null || modelUser.UserPassword != userLoginDTO.UserPassword)
                {
                    return Unauthorized();
                }

                //כניסה מוצלחת, מעדכן את הכניסה בסשן
                HttpContext.Session.SetString("loggedinUser", modelUser.Username);

                DTO.UserDTO sessionUser = new DTO.UserDTO(modelUser);
                return Ok(sessionUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] DTO.UserDTO userDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Get model user class from DB with matching email. 
                Models.User modelsUser = new User()
                {
                    Username = userDto.Username,
                    Email = userDto.Email,
                    UserPassword = userDto.UserPassword,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName
                };

                context.Users.Add(modelsUser);
                context.SaveChanges();

                //User was added!
                DTO.UserDTO dtoUser = new DTO.UserDTO(modelsUser);
                return Ok(dtoUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}
