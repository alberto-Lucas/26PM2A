namespace TesteMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Adicionar a chamada da nova tela principal
            MainPage = new NavigationPage(new Views.PrincipalView());
        }
    }
}