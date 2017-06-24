using Xamarin.Forms;

namespace ExpandableListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Product;
            var vm = BindingContext as MainViewModel;
            vm?.ShowOrHidePoducts(product);
        }
    }
}