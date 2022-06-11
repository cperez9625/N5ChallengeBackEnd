namespace N5.Data.Interfaces
{
    public interface ICRUDData<T>
    {
        List<T> ItemList();
        T CreateItem(T item);
        T UpdateItem(T item);
        T GetById(int id);
    }
}
