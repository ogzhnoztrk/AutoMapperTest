
# AutoMap Nedir

- Elimizdeki nesneleri diğer nesnelere maplemek için kullanılır. 
- örn: Elimizdeki bir User nesnesini UserDto ya her seferinde maplemek yerine AutoMapper ile bu durumları daha kolay bir şekilde yönetebiliriz.
- bir kere tanımlanır ve duruma göre belirli kurallar uygulanır
- Tekrar tekrar gelen veriyi el ile diğer nesnelere çevirmeye gerek  kalmaz




### 1- Paket Kurulumu  
- gerekli olan paketi packagemanager ile kurdum
    - pm > Install-Package AutoMapper

### 2- Sınıfları Oluşturdum

- User
```c#
 public class User
 {
     public int Id { get; set; }
     public string Name { get; set; }
     public string LastName { get; set; }
     public string PhoneNumber { get; set; }
     public int Status { get; set; }

 }
 enum UserStatus
 {
     Active = 0,
     Inactive = 1,
     Deleted = 2,
     Blocked = 3,
     Suspended = 4,
 }
```
- UserDto
```c#
    public class UserDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
    }
```

- UserProfile
```c#
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dto => dto.FullName, option => option.MapFrom(dest => dest.Name + " " + dest.LastName))
            .ForMember(dto => dto.Status, option => option.MapFrom(dest => ((UserStatus)dest.Status).ToString()));
    }
}
```
### 3- Startup.cs içerisinde tanımladım
```c#
builder.Services.AddAutoMapper(typeof(UserProfile));
```

### 4- UserController içerisinde kullandım
```c#
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
        var user = userList.FirstOrDefault();
        var userDto = _mapper.Map<UserDto>(user);
        return Ok(userDto);
    }
    [HttpGet("All")]
    public IActionResult GetAll()
    {
        var userDto = _mapper.Map<List<UserDto>>(userList);
        return Ok(userDto);
    }
}
```
