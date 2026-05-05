namespace NotificationApp.Interfaces;

internal interface IRepository<K,T> where T : class
{
    public T Create(T item);
    public T? Get(K key);
    public T? Update(K key,T item);
    public T? Delete(K key);
}