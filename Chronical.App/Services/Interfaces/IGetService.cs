namespace Chronical.App.Services.Interfaces
{
    public interface IGetService
    {
        Task GetAllCommentsForBook(int bookId);
        Task GetAllCommentsForCharacter(int characterId);
    }
}
