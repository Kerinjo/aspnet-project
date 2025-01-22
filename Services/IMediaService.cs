using biblioteka.Models;

namespace biblioteka.Services
{
    public interface IMediaService
    {
        int Add(MediaViewModel item);
        void Delete(int id);
        void Update(MediaViewModel item);
        List<MediaViewModel> FindAll();
        MediaViewModel? FindById(int id);
    }
}
