using Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace Services;
public class MenuService
{
    public readonly TelegramBotService _telegramBotService;
    public MenuService(TelegramBotService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }
    public void SendMenu(User user, string message)
    {
        var Buttons = new List<string>() { "📖Quran Pdf",
            "🎧Litsen to Quran recitation",
            "📖The Lives of the Sahabah" };
        user.SetStep(EUserStep.Menu);
        _telegramBotService.SendMessage(user.ChatId, "Please choose the menu⬇️",
        _telegramBotService.GetKeyboardButtons(Buttons));
    }

    public void TextFilter(User user, string message)
    {
        switch (message)
        {
            case "📖Quran Pdf": SendQuranPdf(user); break;
            case "🎧Litsen to Quran recitation": SendRecitersMenu(user); break;
            case "📖The Lives of the Sahabah": SendSahabahsLife(user); break;
        }
    }
    public void SendQuranPdf(User user)
    {
        var filePath = "https://propakistani.pk/wp-content/uploads/2008/09/quraan-majeed.pdf";
        _telegramBotService.SendDocuments(user.ChatId, filePath, "The Holy Qur'an pdf version");
    }
    public void SendSahabahsLife(User user)
    {
        user.SetStep(EUserStep.SahabahsLife);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1️⃣ Abu Bakr As-Siddiq",
                callbackData:"1.Abu Bakr As-Siddiq"),
                InlineKeyboardButton.WithCallbackData(text:"2️⃣ Umar ibn Al-Khattab",
                callbackData:"2.Umar ibn Al-Khattab"),

            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"3️⃣ Uthman ibn Affan",
                callbackData:"3.Uthman ibn Affan"),
                InlineKeyboardButton.WithCallbackData(text:"4️⃣ Ali ibn Abi Talib",
                callbackData:"4.Ali ibn Abi Talib"),
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData(text:"5️⃣ The Lives of the Sahabah book",
                callbackData:"5.The Lives of the Sahabah book"),
            },
        });

        _telegramBotService.SendMessage(user.ChatId, "Please choose the Sahabah⬇️", inlineKeyboard);
    }
    //Sahabah1 
    public void SahabahsLifeInfo1(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1️⃣ Video",
                callbackData:"1.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2️⃣ Book",
                callbackData:"1.Book"),
            },
        });
        _telegramBotService.SendMessage(user.Id, "Choose from menu ⬇️", inlineKeyboard);
    }
    //sahabah2
    public void SahabahsLifeInfo2(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1️⃣ Video",
                callbackData:"2.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2️⃣ Book",
                callbackData:"2.Book"),
            },
        });
        _telegramBotService.SendMessage(user.Id, "Choose from menu ⬇️", inlineKeyboard);
    }

    //shabah3
    public void SahabahsLifeInfo3(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1️⃣ Video",
                callbackData:"3.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2️⃣ Book",
                callbackData:"3.Book"),
            },
        });
        _telegramBotService.SendMessage(user.Id, "Choose from menu ⬇️", inlineKeyboard);
    }

    //sahabah4
    public void SahabahsLifeInfo4(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1️⃣ Video",
                callbackData:"4.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2️⃣ Book",
                callbackData:"4.Book"),
            },
        });
        _telegramBotService.SendMessage(user.Id, "Choose from menu ⬇️", inlineKeyboard);
    }

    public void SahabahLifeInfo5(Telegram.Bot.Types.User user)
    {
        var filePath = "https://www.missionislam.com/knowledge/books/compprophet.pdf";
        _telegramBotService.SendDocuments(user.Id, filePath, "📖The lives of the sahabah");
    }

    //reciters
    public void SendRecitersMenu(User user)
    {
        user.SetStep(EUserStep.GetRecitersRecording);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
        // first row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1️⃣ Idrees Abkar", callbackData: "Idrees Abkar"),
            InlineKeyboardButton.WithCallbackData(text: "2️⃣ Mahmoud Khalil Al-Hussary",
            callbackData: "Mahmoud Khalil Al-Hussary"),
        },
        // second row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "3️⃣ Maher Al Muaqli", callbackData: "Maher Al Muaqli"),
            InlineKeyboardButton.WithCallbackData(text: "4️⃣ Mishary Al Afasy", callbackData: "Mishary Al Afasy"),
        },
        //third row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "5️⃣ Muhammad Siddiq Al Minshawi",
            callbackData: "Muhammad Siddiq Al Minshawi"),
        },
        });
        _telegramBotService.SendMessage(user.ChatId, "Please choose the reicter👳🏻‍♂️", inlineKeyboard);
    }


}

