using BookLibrary.Core.Entities;

namespace BookLibrary.Api.Models
{
    public interface IEntityModelConverter<TEntity, TModel>
        where TEntity: IEntity
        where TModel: IViewModel
    {
        TModel ConvertToModel(TEntity entity);
    }
}
