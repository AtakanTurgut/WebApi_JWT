using WebApi_JWT.Models;

namespace WebApi_JWT.Repositories
{
    public class ApiUserRepository
    {
        public static List<ApiUser> Users = new()
        {
            new ApiUser { Id = 1, UserName = "AtakanTurgut", Password = "123456", Role = "Admin" },
            new ApiUser { Id = 2, UserName = "FurkanUvenc", Password = "123456", Role = "Support" },
            new ApiUser { Id = 3, UserName = "YagmurSoydan", Password = "123456", Role = "User" },
        };

        public static ApiUser? GetUserByCredentials(string username, string password)
        {
            return Users.FirstOrDefault(u =>
                u.UserName?.ToLower() == username.ToLower() &&
                u.Password == password
            );
        }
    }
}
