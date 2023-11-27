namespace WebAppTry1.Models.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);

    }
}
