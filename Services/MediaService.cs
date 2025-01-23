using Data;
using Data.Entities;
using biblioteka.Models;
using biblioteka.Mappers;

namespace biblioteka.Services
{
    public class MediaService : IMediaService
    {
        private LibraryContext _context;

        public MediaService(LibraryContext context)
        {
            _context = context;
        }

        public int Add(MediaViewModel contact)
        {
            var e = _context.Media.Add(MediaMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            MediaEntity? find = _context.Media.Find(id);
            if (find != null)
            {
                _context.Media.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<MediaViewModel> FindAll()
        {
            return _context.Media.Select(e => MediaMapper.FromEntity(e)).ToList(); ;
        }

        public MediaViewModel? FindById(int id)
        {
            return MediaMapper.FromEntity(_context.Media.Find(id));
        }

        public void Update(MediaViewModel contact)
        {
            _context.Media.Update(MediaMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}

