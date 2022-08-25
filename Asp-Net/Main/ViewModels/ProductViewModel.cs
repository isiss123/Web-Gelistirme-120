using Main.Models;

namespace Main.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
        public ProductViewModel()
        {}
        public ProductViewModel(List<Product> _products, Category _category)
        {
            this.Products = _products;
            this.Category = _category;
        }
    }
}