using System.ComponentModel;
using System.Collections.ObjectModel;
using HDZ360.Models;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace HDZ360.ViewModels
{
    public class ImoveisViewModel : INotifyPropertyChanged
    {
        private bool Busy;

        public bool IsBusy
        {
            get { return Busy; }
            set
            {
                Busy = value;
                OnPropertyChange();
                GetImoveisCommand.ChangeCanExecute();
            }
        }

        public Command GetImoveisCommand { get; set; }

        public ObservableCollection<Imovel> Imoveis { get; set; }

        public ImoveisViewModel()
        {
            Imoveis = new ObservableCollection<Imovel>();
            GetImoveisCommand = new Command(
                async () => await GetImoveis(),
                      () => !IsBusy);
        }

        private async Task GetImoveis()
        {
            if (!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var repositorio = new Repositorio();
                    var itens = await repositorio.GetImoveis();

                    Imoveis.Clear();
                    foreach (var imovel in itens)
                    {
                        Imoveis.Add(imovel);
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro!", error.Message, "Ok");
                    error = ex;
                }
                finally
                {
                    IsBusy = false;
                }
            }

            return;
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public event PropertyChangedEventHandler PropertyChanged;
    }
}