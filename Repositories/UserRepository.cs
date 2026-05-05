using NotificationApp.Models;
namespace NotificationApp.Repository;

internal partial class UserRepository : AbstractRepository<int,User>
{
    static int userId = 0;
    public override User Create(User user)
    {
        user.userId = ++userId;
        items.Add(userId,user);
        return user;
    }
}