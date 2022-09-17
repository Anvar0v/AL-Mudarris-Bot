using Services;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botService = new TelegramBotService();
var userService = new UsersService(botService);
var menuService = new MenuService(botService);
var queryHandler = new QueryDataHandler(botService,menuService);
botService.GetUpdate((_, update, _) => Task.Run(() => GetUpdate(update)));
Console.ReadKey();

void GetUpdate(Update update)
{
    Telegram.Bot.Types.User From;
    string messageFromUser;
    if (update.Type == UpdateType.Message)
    {
        From = update.Message.From;
        messageFromUser = update.Message.Text;
    }
    else if (update.Type == UpdateType.CallbackQuery)
    {
        From = update.CallbackQuery.From;
        messageFromUser = update.CallbackQuery.Data;
        queryHandler.HandleCallBackData(From, messageFromUser);
        queryHandler.HandleSahabahsOptionsQuery1(From, messageFromUser);
        queryHandler.HandleSahabahsOptionsQuery2(From, messageFromUser);
        queryHandler.HandleSahabahsOptionsQuery3(From, messageFromUser);
        queryHandler.HandleSahabahsOptionsQuery4(From, messageFromUser);
        queryHandler.HandeQueryOfReciters(From, messageFromUser);
        Console.WriteLine(messageFromUser);
    }
    else return;

    var user = userService.AddUser(From);
    StepFilter(user, messageFromUser);//to know where the user is
    
}

void StepFilter(Models.User user, string message)
{
    switch (user.Step)
    {
        case EUserStep.NewUser: menuService.SendMenu(user, message); break;
        case EUserStep.Menu: menuService.TextFilter(user, message); break;
        case EUserStep.SahabahsLife: menuService.TextFilter(user, message); break;
        case EUserStep.GetRecitersRecording: break;
    }
}


