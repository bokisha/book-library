namespace BookLibrary.Api.Models
{
    public interface ISelectItem<T>
    {
        T Value { get; set; }
        string Description { get; set; }
    }
}
