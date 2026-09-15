using TesteMVVM.ViewModels;

namespace TesteMVVM.Views;

public partial class PrincipalView : ContentPage
{
    //Primeira coisa a ser feita
    //é importar a nossa camada ViewModel
    //using NomeProjeto.ViewModels;
    public PrincipalView()
	{
		InitializeComponent();
        //Vincular o Binding com a ViewModel
        //Para ativar o observador e a notificação
        BindingContext = new PrincipalViewModel();
	}
}