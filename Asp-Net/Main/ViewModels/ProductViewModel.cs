using Main.Models;

namespace Main.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public ProductViewModel()
        {}
       
    }
}