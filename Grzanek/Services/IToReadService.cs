namespace API.Services
{
    public interface IToReadService
    {
        Task<List<Books>> GetToRead(int ID);
    }
}
