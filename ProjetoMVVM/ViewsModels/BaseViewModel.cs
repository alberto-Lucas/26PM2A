using System.Windows.Input;

namespace ProjetoMVVM.ViewsModels
{
    //Classe com rotinas genericas e compartilhadas entre telas
    //Iremos herdar da classe de notificação
    public class BaseViewModel : BaseNotifyViewModel
    {
        //Iremos implementar a rotina de Voltar para tela anterior
        //Importar a biblioteca
        //using System.Windows.Input;
        public ICommand VoltarCommand { get; set; }
        public async void Voltar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        //Implementar a rotina de abertura de tela
        //A rotina de AbrirTela não possui command
        //pois não pode ser executada diretamente do front
        //ela será chamada diretamente pelo back-end
        //devido o parametro(tela q será aberta)
        public async void AbrirView(ContentPage view)
        {
            await Application.Current.MainPage.Navigation.PushAsync(view);
        }

        //Vincular o método ao command
        public BaseViewModel()
        {
            VoltarCommand = new Command(Voltar);
        }
    }
}
