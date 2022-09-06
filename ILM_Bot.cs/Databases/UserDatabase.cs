using Models;
namespace Databases;
public class UserDatabase
{
    public List<User> Users = new List<User>();
    public UserDatabase(List<User> users)
    {
        Users = users;
    }

    public User AddUser(long chatId, string name)
    {
        if (Users.Any(user => user.ChatId == chatId))
        {
            return Users.First(user => user.ChatId == chatId);
        }
        var newUser = new User(chatId,name);
        Users.Add(newUser);
        return newUser;
    }
}