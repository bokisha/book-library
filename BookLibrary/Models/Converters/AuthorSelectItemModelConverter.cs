using BookLibrary.Core.Entities;

namespace BookLibrary.Models.Converters
{
    public class AuthorSelectItemModelConverter : IEntityModelConverter<Author, SelectItemByIdModel>
    {
        public SelectItemByIdModel ConvertToModel(Author entity)
        {
            return new SelectItemByIdModel
            {
                Value = entity.Id,
                Description = entity.GetFullName()
            };
        }
    }
}
