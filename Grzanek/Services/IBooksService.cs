namespace API.Services
{
    public interface IBooksService
    {
        Task<List<Books>> GetBooks();
        Task AddBooks(Books book);
        Task DeleteBooks(Books book);
    }
}
