namespace TesteMVVM.ViewModels
{
    //Realizando a heração com a classe base de notificação
    public class PrincipalViewModel : BaseNotifyViewModel
    {
        //Criar as propriedades que a camada view
        //podera acessar
        //assim criamos primeiro o banck depois o front end

        //Criemos os atributos encapsulados com as propriedades
        public string Nome { get; set; }

        private string _retorno;
        public string Retorno
        {
            get { return _retorno; }
            set 
            { 
                _retorno = value;
                //Vincular o observador
                OnPropertyChanged();
            }
        }

        //Como temos o vinculo direto com a views
        //não os eventos dos botões
        //Desta forma iremos criar os nosso comandos
        //que serão vinculado as botões

        //Comando de execução do botão
        //Iremos recuperar o conteudo do campos Nome
        //e atualizar a informação de retorno com o conteudo
        //da propriedade Retorno
        public Command RetornoCommand
        {
            get
            {
                return new Command(() =>
               {
                   //Realizar a concatena dos valores
                   //aqui será de fatos a execução da função
                   Retorno = "Olá, " + Nome;
               });
            }
        }
    }
}
