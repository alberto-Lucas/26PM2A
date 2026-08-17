using System.Threading.Tasks;

namespace AppAnimacao
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGirarDir_Clicked(object sender, EventArgs e)
        {
            //Iremos aplicar a animação de giro da imagem
            //seguindo o sentido horario
            //Para realizar a animação
            //precisamos definir o quanto girar (graus)
            //e por quanto tempo ira gira até o destino
            //OBS: o tempo é definido em milisegundos
            //ou seja 1 segundo é 1000 miliegundos
            //Importante
            //é recomendo resetar a posição da imagem
            //antes de iniciar uma rotação

            imgTeste.Rotation = 0; //Posiação atual do componente
            imgTeste.RotateTo(360, 2000);
        }

        private void btnGirarEsq_Clicked(object sender, EventArgs e)
        {
            imgTeste.Rotation = 0;
            imgTeste.RotateTo(-360, 500);
        }

        private void btnGirarVer_Clicked(object sender, EventArgs e)
        {
            //Utilizando o plano carteziado
            //será realizado um traço vertical na imagem
            //para ser o eixo de giro
            //X = horizontal
            //Y = vertical

            imgTeste.RotationY = 0;
            imgTeste.RotateYTo(360, 1000);
        }

        private void btnGirarHor_Clicked(object sender, EventArgs e)
        {
            imgTeste.RotationX = 0;
            imgTeste.RotateXTo(360, 3000);
        }

        private void btnZoomMais_Clicked(object sender, EventArgs e)
        {
            //A animação de Zoom(Escala) aplica
            //o efeito sobre o tamanho original da imagem
            //ou seja gerando um efeito de reset
            //para gerar um efeito de zoom
            //continuo, preciso aplicar sempre sobre o 
            //tamanho atual da imagem
            //Utilizar o tamanho atual e adicionar a multiplicação
            //Se a imagem tiver 100 de tamanha e multiplicar por meio
            //ela tera 50 de tamanho porém estou somando o tamanho
            //atual com a multiplicação
            //então teremos 150 de tamanho
            imgTeste.ScaleTo(imgTeste.Scale + 0.5, 250);
        }

        private void btnZoomMenos_Clicked(object sender, EventArgs e)
        {
            imgTeste.ScaleTo(imgTeste.Scale - 0.5, 250);
        }

        private async void btnTremer_Clicked(object sender, EventArgs e)
        {
            //Para o efeito de tremida
            //iremos movimentar para a direita e para esquerda
            //utilizando a mesmo tamanho de movimento
            //a cada ciclo o dimunuindo até a posição original

            //Para isso iremos utilizar o método Translate
            //pois o mesmo realiza o movimento com base na
            //posição original assim não é preciso realizar
            //o calculo de deslocamento ou reset de posição

            //Utiliza 3 parametros
            //Primeiro é a quantidade de
            //deslocamento em pixel no eixo x
            //Segundo é a quantidade de
            //deslocamento em pixel no eixo y
            //Terceiro é o tempo

            //Usaremos await para aguardar a execução de cada movimento
            //se não todas seriam executadas ao mesmo tempo

            await imgTeste.TranslateTo( 15, 0, 50);
            await imgTeste.TranslateTo(-15, 0, 50);
            await imgTeste.TranslateTo( 10, 0, 50);
            await imgTeste.TranslateTo(-10, 0, 50);
            await imgTeste.TranslateTo(  5, 0, 50);
            await imgTeste.TranslateTo( -5, 0, 50);
            imgTeste.TranslationX = 0;
        }

        private async void btnOpacidade_Clicked(object sender, EventArgs e)
        {
            //O efeito de opacidade possui apenas
            //2 valores 
            //1 - Totalmente solido
            //0 - Totalmente transparente

            //Definimos a opacidade inicial
            //aplicamos o efeito com o tempo desejado
            //para opacidade final

            imgTeste.Opacity = 1;
            await imgTeste.FadeTo(0, 1000);

            imgTeste.Opacity = 0;
            await imgTeste.FadeTo(1, 1000);
        }

        private async void btnCombo_Clicked(object sender, EventArgs e)
        {
            //No combo iremos girar no sentido horario
            //e aplicar zoom e remover o zoom 
            //durante o giro
            //para isso será preciso sincronizar as 
            //animações

            imgTeste.Rotation = 0;

            //aguardar a excecutação das trades em paralelo
            await Task.WhenAny<bool>
            (
                imgTeste.RotateTo(360, 2000),
                imgTeste.ScaleTo(2, 1000)
            );
            await imgTeste.ScaleTo(1, 1000);

            //A primeira animação ira definir o tempo total
            //ou seja 2 segundos
            //então preciso dividir esses 2 segundos quantidade
            //das outras animações
            //neste caso 1 segundo para cada animação
            //a ultima animação está fora da sincronia
        }
    }
}
