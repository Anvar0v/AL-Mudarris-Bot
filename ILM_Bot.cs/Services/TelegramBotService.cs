using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Services;
public class TelegramBotService
{
    private readonly string Token = "5578148355:AAEviIL3USFOXUaGGa0ESAAywHR6Fnt564s";
    private TelegramBotClient Bot;

    public TelegramBotService()
    {
        Bot = new TelegramBotClient(Token);
    }

    public void GetUpdate(Func<ITelegramBotClient, Update, CancellationToken, Task> update)
    {
        Bot.StartReceiving(
            updateHandler: update,
            errorHandler: (_, ex, _) =>
            {
                Console.WriteLine(ex);
                return Task.CompletedTask;
            },
            new ReceiverOptions()
            {
                ThrowPendingUpdates = true,
            });
    }

    public void SendMessage(long chatId, string message, IReplyMarkup reply = null)
    {
        Bot.SendTextMessageAsync(chatId, message, replyMarkup: reply);
    }
    public void SendAudio(long chatId, string path,string caption = null)
    {
        Bot.SendAudioAsync(chatId, path,caption:caption);
    }

    public void SendDocuments(long chatId, string path , string caption = "")
    {
        Bot.SendDocumentAsync(chatId, path, caption:caption);
    }

    public ReplyKeyboardMarkup GetKeyboardButtons(List<string> buttons)
    {
        KeyboardButton[][] buttonsText = new KeyboardButton[buttons.Count][];
        for (int i = 0; i < buttons.Count; i++)
        {
            buttonsText[i] = new KeyboardButton[] { new KeyboardButton(buttons[i]) };
        }
        return new ReplyKeyboardMarkup(buttonsText) { ResizeKeyboard = true};
    }

    public void SendPhoto(long chatId,string path,string caption= null)
    {
        Bot.SendPhotoAsync(chatId, path,caption:caption);
    }
}