namespace MyTabs.API.Dto
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public UserReadDto()
        {
        }

        public UserReadDto(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}