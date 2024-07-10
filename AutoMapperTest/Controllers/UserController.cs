using AutoMapper;
using AutoMapperTest.Dtos;
using AutoMapperTest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AutoMapperTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;


        private List<User> userList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Status = (int)UserStatus.Active
                },
                new User
                {
                    Id = 2,
                    Name = "Jane",
                    LastName = "Smith",
                    PhoneNumber = "0987654321",
                    Status = (int)UserStatus.Inactive
                },
                new User
                {
                    Id = 3,
                    Name = "Mike",
                    LastName = "Johnson",
                    PhoneNumber = "1111111111",
                    Status = (int)UserStatus.Active
                },
                new User
                {
                    Id = 4,
                    Name = "Emily",
                    LastName = "Williams",
                    PhoneNumber = "2222222222",
                    Status = (int)UserStatus.Suspended
                },
                new User
                {
                    Id = 5,
                    Name = "David",
                    LastName = "Brown",
                    PhoneNumber = "3333333333",
                    Status = (int)UserStatus.Active
                }
            };

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var userDto = _mapper.Map<List<UserDto>>(userList);
            return Ok(userDto);
        }
    }
}
