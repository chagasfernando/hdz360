using HDZ360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HDZ360.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImoveisPage : ContentPage
    {
        public ImoveisPage()
        {
            InitializeComponent();
            LvImoveis.ItemSelected += LvImoveis_ItemSelected;
        }

        private async void LvImoveis_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedImovel = e.SelectedItem as Imovel;

            if (selectedImovel != null)
            {
                await Navigation.PushAsync(new DetalhePage(selectedImovel));
                LvImoveis.SelectedItem = null;
            }
        }
    }
}
