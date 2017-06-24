using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpandableListView.UnitTests
{
    [TestClass]
    public class MainViewModelTests
    {
        private ObservableCollection<Product> _products;

        [TestInitialize]
        public void InitializeProducts()
        {
            _products = new ObservableCollection<Product>
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
                }
            };
        }

        [TestMethod]
        public void ShouldShowProduct_IfNotShown()
        {
            // Arrange
            var vm = new MainViewModel
            {
                Products = _products
            };

            // Act
            vm.ShowOrHidePoducts(_products.First());

            // Assert
            Assert.IsTrue(vm.Products.First().IsVisible);
        }

        [TestMethod]
        public void ShouldHideProduct_IfShown()
        {
            // Arrange
            var vm = new MainViewModel
            {
                Products = _products
            };

            // Act
            vm.ShowOrHidePoducts(_products.First());
            vm.ShowOrHidePoducts(_products.First());

            // Assert
            Assert.IsTrue(vm.Products.First().IsVisible == false);
        }

        [TestMethod]
        public void ShouldShowLastProduct_AndHidePrevious()
        {
            // Arrange
            var vm = new MainViewModel
            {
                Products = _products
            };

            // Act
            vm.ShowOrHidePoducts(_products.First());
            vm.ShowOrHidePoducts(_products[1]);

            // Assert
            Assert.IsTrue(vm.Products.First().IsVisible == false);
            Assert.IsTrue(vm.Products[1].IsVisible == true);
        }

        [TestMethod]
        public void ShouldHideHiddenProduct_IfSelectedTwiceInARow()
        {
            // Arrange
            var vm = new MainViewModel
            {
                Products = _products
            };

            // Act
            vm.ShowOrHidePoducts(_products.First());
            vm.ShowOrHidePoducts(_products.First());

            // Assert
            Assert.IsTrue(vm.Products.First().IsVisible == false);
        }

        [TestMethod]
        public void ShouldShowShownProduct_IfSelectedTwiceInARow()
        {
            // Arrange
            var vm = new MainViewModel
            {
                Products = _products
            };

            // Act
            vm.ShowOrHidePoducts(_products.First());
            vm.ShowOrHidePoducts(_products.First());
            vm.ShowOrHidePoducts(_products.First());

            // Assert
            Assert.IsTrue(vm.Products.First().IsVisible == true);
        }
    }
}
