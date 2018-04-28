using Task1KodiSoft.Models;

namespace Task1KodiSoft.ViewModels
{
    public class FoodItemViewModel
    {
        public OrderItem OrderItem { get; set; }
        public int TotalCount { get; set; }
        public double TotalAmountSum { get; set; }
    }
}