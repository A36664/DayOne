namespace BookStore.Service
{
    public interface IMainHandler
    {

        object Handle(object sender, string type, string ev);
    }
}
