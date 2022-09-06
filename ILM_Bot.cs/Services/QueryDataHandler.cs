using Services;

public class QueryDataHandler
{
    TelegramBotService botService;
    MenuService menuService;
    public QueryDataHandler(TelegramBotService botService, MenuService menuService)
    {
        this.botService = botService;
        this.menuService = menuService;
    }
    public void HandleCallBackData(Telegram.Bot.Types.User user, string query)
    {
        switch (query)
        {
            case "1.Abu Bakr As-Siddiq": menuService.SahabahsLifeInfo1(user); break;
            case "2.Umar ibn Al-Khattab": menuService.SahabahsLifeInfo2(user); break;
            case "3.Uthman ibn Affan": menuService.SahabahsLifeInfo3(user); break;
            case "4.Ali ibn Abi Talib": menuService.SahabahsLifeInfo4(user); break;
            case "5.The Lives of the Sahabah book": menuService.SahabahLifeInfo5(user); break;
        }

    }

    //sahabah1 options
    public void HandleSahabahsOptionsQuery1(Telegram.Bot.Types.User user, string message)
    {
        if (message == "1.Video")
        {
            var path_of_Photo = "https://garden4adam.files.wordpress.com/2020/12/hazrat-abu-bakr-siddique-radi-allahu-anhu1.jpg";
            var videoLessonLink = "https://youtu.be/HwBryUFF5yg";
            botService.SendPhoto(user.Id, path_of_Photo, caption: $"The Link to the video lesson⬇️\n{videoLessonLink}");
        }
        else if (message == "1.Book")
        {
            var filePath = "https://www.alislam.org/library/books/Hazrat-Abu-Bakr-Siddiq.pdf";
            botService.SendDocuments(user.Id, filePath, "The life of the Abu Bakr As-Siddik r.a");
        }
    }

    //sahabah2 options
    public void HandleSahabahsOptionsQuery2(Telegram.Bot.Types.User user, string message)
    {
        if (message == "2.Video")
        {
            var videoLessonLink = "https://www.youtube.com/watch?v=plXVAzTNnpo";
            botService.SendMessage(user.Id, videoLessonLink);
        }
        else if (message == "2.Book")
        {
            var filePath = "https://ia801308.us.archive.org/27/items/UmarIbnAlkhattab-IslamicEnglishBook-" +
                "/UmarIbnAlkhattab-IslamicEnglishBook-Alhamdulillah-library.blogspot.in.pdf";
            botService.SendDocuments(user.Id, filePath, "The life of the U'mar r.a");
        }
    }

    //sahabah3 options
    public void HandleSahabahsOptionsQuery3(Telegram.Bot.Types.User user, string message)
    {
        if (message == "3.Video")
        {
            var videoLessonLink = "https://youtu.be/yIRfhzN7VnM";
            botService.SendMessage(user.Id, videoLessonLink);
        }
        else if (message == "3.Book")
        {
            var filePath = "http://islamicbulletin.org/en/ebooks/companions/othman_ibn_affan_the_third_caliph.pdf";
            botService.SendDocuments(user.Id, filePath, "The life of the Usman ibn Affan r.a");
        }
    }

    //sahabah4 options
    public void HandleSahabahsOptionsQuery4(Telegram.Bot.Types.User user, string message)
    {
        if (message == "4.Video")
        {
            var videoLessonLink = "https://youtu.be/fn3hfVNCBMI";
            botService.SendMessage(user.Id, videoLessonLink);
        }
        else if (message == "4.Book")
        {
            var filePath = "https://ia902804.us.archive.org/5/items/learnislampdfe" +
                "nglishbookaliibnabitalibvolume1/learn%20islam%20pdf%20english%20book%20_" +
                "_%20ali-ibn-abi-talib-volume-1.pdf";
            botService.SendDocuments(user.Id, filePath, "The life of the Ali ibn Abu Talib r.a");
        }
    }

    public void HandeQueryOfReciters(Telegram.Bot.Types.User user, string message)
    {
        switch (message)
        {
            case "Idrees Abkar":
                var filePath = "https://server6.mp3quran.net/abkr/001.mp3";
                botService.SendAudio(user.Id, filePath, "1️⃣ Al-Fatihah");
                break;
            case "Mahmoud Khalil Al-Hussary":
                var filePath2 = "https://server13.mp3quran.net/husr/001.mp3";
                botService.SendAudio(user.Id, filePath2, "1️⃣ Al-Fatihah");
                break;
            case "Maher Al Muaqli":
                var filePath3 = "https://server12.mp3quran.net/maher/001.mp3";
                botService.SendAudio(user.Id,filePath3, "1️⃣ Al-Fatihah"); 
                break;
            case "Mishary Al Afasy":
                var filePath4 = "https://server8.mp3quran.net/afs/001.mp3";
                botService.SendAudio(user.Id, filePath4, "1️⃣ Al-Fatihah");
                break;
            case "Muhammad Siddiq Al Minshawi":
                var filePath5 = "https://server10.mp3quran.net/minsh/001.mp3";
                botService.SendAudio(user.Id, filePath5, "1️⃣ Al-Fatihah");
                break;
        }
    }

}