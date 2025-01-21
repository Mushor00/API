namespace API.Services
{
    public interface IBooksService
    {
        Task<List<Books>> GetBooks(int ID);
        Task AddBooks(Books book);
        Task DeleteBooks(Books book);
    }
}
