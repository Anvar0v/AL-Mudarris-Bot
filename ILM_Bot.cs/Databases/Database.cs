namespace Databases;
public class Database
{
    private const string UsersJsonPath = "Data/users.json";
    private static UserDatabase _userDatabase;
    public static UserDatabase Usersdb
    {
        get
        {
            if (_userDatabase == null)
            {
                _userDatabase = new UserDatabase(ReadUserJson());
            }
            return _userDatabase;
        }
    }
    public static List<Models.User> ReadUserJson()
    {
        if (File.Exists(UsersJsonPath)) return new List<Models.User>();
        var jsonString = File.ReadAllText(UsersJsonPath);
        try
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.User>>(jsonString);
        }
        catch
        {
            Console.WriteLine("Cannot convert...");
            return new List<Models.User>();
        }
    }
    public void SaveUser()
    {
        var jsonSerialize = Newtonsoft.Json.JsonConvert.SerializeObject(Usersdb.Users);
        File.WriteAllText(UsersJsonPath, jsonSerialize);
    }
}