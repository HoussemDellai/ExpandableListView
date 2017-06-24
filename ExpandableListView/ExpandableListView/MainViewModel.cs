using System.Collections.ObjectModel;

namespace ExpandableListView
{
    public class MainViewModel
    {
        private Product _oldProduct;
        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Name = "Surface Book",
                    IsVisible = false,
                },
                new Product
                {
                    Name = "Mac Book Pro",
                    IsVisible = false,
                },
                new Product
                {
                    Name = "Surface Laptop",
                    IsVisible = false,
                },
                new Product
                {
                    Name = "X1 Carbon",
                    IsVisible = false,
                },
            };
        }

        public void ShowOrHidePoducts(Product product)
        {
            if (_oldProduct == product)
            {
                // click twice on the same item will hide it
                product.IsVisible = !product.IsVisible;
                UpdateProductView(product);
            }
            else
            {
                if (_oldProduct != null)
                {
                    // hide previous selected item
                    _oldProduct.IsVisible = false;
                    UpdateProductView(_oldProduct);
                }
                // show selected item
                product.IsVisible = true;
                UpdateProductView(product);
            }

            _oldProduct = product;
        }

        private void UpdateProductView(Product product)
        {
            var index = Products.IndexOf(product);
            Products.Remove(product);
            Products.Insert(index, product);
        }
    }
}
