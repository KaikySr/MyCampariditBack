public interface IRepository<T>
{
  Task Add(T obj);
  Task Delete(T obj);
  Task Update(T obj);
}