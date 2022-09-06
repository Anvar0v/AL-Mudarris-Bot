using Databases;
using Models;
using Services;

public class UsersService
{
    public readonly TelegramBotService _telegramBotService;

    public UsersService(TelegramBotService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }

    public User AddUser(Telegram.Bot.Types.User user)
    {
        var name = string.IsNullOrEmpty(user.Username) ? user.FirstName : user.Username;
        return Database.Usersdb.AddUser(user.Id,name);
    }
}