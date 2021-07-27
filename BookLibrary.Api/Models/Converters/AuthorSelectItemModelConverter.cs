using BookLibrary.Core.Entities;

namespace BookLibrary.Api.Models.Converters
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
