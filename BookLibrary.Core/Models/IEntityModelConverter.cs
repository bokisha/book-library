using BookLibrary.Core.Entities;

namespace BookLibrary.Core.Models
{
    public interface IEntityModelConverter<TEntity, TModel>
        where TEntity: IEntity
        where TModel: IViewModel
    {
        TModel ConvertToModel(TEntity entity);
    }
}
