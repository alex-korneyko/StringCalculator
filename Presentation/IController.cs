namespace Presentation
{
    public interface IController<T>
    {
        T GetData(string message);

        void ShowData(T data);
    }
}