using Data.Entities;
using biblioteka.Models;
using Shared.Enums;

namespace biblioteka.Mappers
{
    public class MediaMapper
    {
        public static MediaViewModel FromEntity(MediaEntity entity)
        {
            return new MediaViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Status = entity.Status,
                Category = entity.Category,
            };
        }

        public static MediaEntity ToEntity(MediaViewModel model)
        {
            return new MediaEntity()
            {
                Id = model.Id.HasValue ? model.Id.Value : 0,
                Title = model.Title,
                Author = model.Author,
                Status = model.Status,
                Category = model.Category
            };
        }
    }
}
