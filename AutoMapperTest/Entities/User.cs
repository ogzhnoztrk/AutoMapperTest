namespace AutoMapperTest.Entities
{
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


}
