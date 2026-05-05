using NotificationApp.Interfaces;
namespace NotificationApp.Repository;

internal abstract class AbstractRepository<K,T> : IRepository<K,T> where T : class where K : notnull
{
    protected Dictionary<K,T> items = new();

    public abstract T Create(T item);

    public T? Get(K key)
    {
        if(items.ContainsKey(key))
        {
            return items[key];
        }
        return null;
    }

    public T? Update(K key,T item)
    {
        if(!items.ContainsKey(key))
        {
            return null;
        }
        items[key] = item;
        return item;
    }

    public T? Delete(K key)
    {
        if(items.ContainsKey(key))
        {
            var item = items[key];
            items.Remove(key);
            return item;
        }
        return null;
    }
} 