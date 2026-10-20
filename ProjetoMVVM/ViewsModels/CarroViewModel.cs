using ProjetoMVVM.Services;
using ProjetoMVVM.Models;
using System.Windows.Input;
using ProjetoMVVM.Views;

namespace ProjetoMVVM.ViewsModels
{
    //Importar as camadas Views, Models e Services;
    //using Nome_Projeto.Models;
    //using Nome_Projeto.Views;
    //using Nome_Projeto.Services;

    //Classe responsavel por gerenciar 
    //o cadastro do objeto Carro

    //Realizar a herança com a classe BaseViewModel
    public class CarroViewModel : BaseViewModel
    {
        //Instanciar a classe de serviço
        CarroService carroService = new CarroService();

        //Agora devemos criar as propriedades para acesso da tela
        //com a classe Carro gerealmente criamos um espelho
        //da classe de objeto desejado
        //esse formato de propriedade se chama encapsulamento

        //Cria a variavel privada para armazenar os dados
        private string _marca;
        //Criar a propriedade de manipulação
        public string Marca
        {
            get { return _marca; } //Retornar dado gravado
            set
            {
                _marca = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        private string _modelo;

        public string Modelo
        {
            get { return _modelo; } //Retornar dado gravado
            set
            {
                _modelo = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        private string _cor;

        public string Cor
        {
            get { return _cor; } //Retornar dado gravado
            set
            {
                _cor = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        //Implementar a rotina de cadastro]
        //O Command precisa ser publico para ser acessado pelo front
        public ICommand CadastrarCommand { get; set; }
        //O método não precisa ser publico
        //pois apenas o command será acessado
        void Cadastrar()
        {
            //Instanciar a classe do Objeto
            Carro carro = new Carro();
            //popular o objeto com as informações em tela
            carro.Marca = Marca;
            carro.Modelo = Modelo;
            carro.Cor = Cor;

            //Salvar o registro na singleton
            carroService.AdicionarSingleton(carro);

            //Exibir a tela de vizualização
            AbrirView(new CarroVisualizarView());
        }

        //Implementar a Rotina de Consulta
        //O Command precisa ser publico para ser acessado pelo front
        public ICommand ConsultarCommand { get; set; }
        //O método não precisa ser publico
        //pois apenas o command será acessado
        void Consultar()
        {
            //Popular o objeto carro com o registro
            //salvo na singleton
            Carro carro = carroService.ConsultarSingleton();

            //Mapear o objeto com as propriedades da tela
            Marca = carro.Marca;
            Modelo = carro.Modelo;
            Cor = carro.Cor;
        }

        //Vincular os commands
        public CarroViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            ConsultarCommand = new Command(Consultar);
        }
    }
}
