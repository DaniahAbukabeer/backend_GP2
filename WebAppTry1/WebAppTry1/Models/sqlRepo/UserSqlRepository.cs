using WebAppTry1.Models.Interfaces;

namespace WebAppTry1.Models.sqlRepo
{
    public class UserSqlRepository : IUserRepository

    {
        private readonly ApplicationDbContext context;

        public UserSqlRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public User UpdateUser(User user)
        {
            var modifiedUser = context.Users.Attach(user);
            modifiedUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
        }
    }
}
