namespace AppSplashScreen
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ImagemAnimada();
        }

        async void ImagemAnimada()
        {
            //Esperar de 2 segundos
            await Task.Delay(2000);

            //Animação de rotação
            imgWord.Rotation = 0;
            imgWord.RotateTo(360, 3000);
            imgWord.Rotation = 0;

            await Task.Delay(2000);

            //Easing.Linear suavizar a animação
            await imgWord.ScaleTo(1.5, 2000, Easing.Linear);
            await imgWord.ScaleTo(1, 1000, Easing.Linear);
            await imgWord.ScaleTo(0.5, 1500, Easing.Linear);
            await imgWord.ScaleTo(150, 1500, Easing.Linear);

            Application.Current.MainPage =
                new NavigationPage(new pgPrincipal());
        }
    }
}
