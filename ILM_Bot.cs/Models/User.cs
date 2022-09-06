namespace Models;
public class User
{
    public string Name { get; set; }
    public long ChatId { get; set; }

    public EUserStep Step { get; set; }

    public User(long chatId, string name)
    {
        ChatId = chatId;
        Name = name;
        Step = 0;
    }

    public void SetStep(EUserStep step)
    {
        Step = step;
    }

}