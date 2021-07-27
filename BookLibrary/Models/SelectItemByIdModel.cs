namespace BookLibrary.Models
{
    public class SelectItemByIdModel : ISelectItem<int>, IViewModel
    {
        public int Value { get; set; }
        public string Description { get; set; }       
    }
}
