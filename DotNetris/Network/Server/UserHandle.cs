using System.Collections.Concurrent;
using DotNetris.Network.Server.Database.Models;

namespace DotNetris.Network.Server;

public class UserHandle: IDisposable
{

    public UserHandle(User? user, ConcurrentDictionary<int, byte> bag)
    {
        this.bag = bag;
        User = user;
    }
    
    private User? _user;

    public User? User
    {
        get => _user;
        set
        {
            UpdateBag(value);
            _user = value;
        }
    }

    private ConcurrentDictionary<int, byte> bag;


    private void UpdateBag(User? newUser)
    {
        if (newUser == null)
        {
            if (User != null)
            {
                bag.TryRemove(User.Id, out byte _); // remove the user from the bag
            }
        }
        else
        {
            if (User != null)
            {
                bag.TryRemove(User.Id, out byte _); // remove the user from the bag
            }

            bag.TryAdd(newUser.Id, 1);
        }
    }
    
    public void Dispose()
    {
        UpdateBag(null);
    }
}