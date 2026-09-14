using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TesteMVVM.ViewModels
{
    //Está classe será a base do nosso observador
    //e notificação
    //Seguindo a propria documentação do MVVM
    //ou seja o codigo apresentado é o original da documentação

    //Vamos transforma está classe em abstrata
    //ou seja ela nunca podera ser instanciada
    //ela só podera ser usada atraves de herança

    //Importar a biblioteca de componente
    //using System.ComponentModel;

    //Realizar a herança com a interface NotifyPropertChanged
    //Iterface é um contrato entre classe
    //é obrigado a implementar o método e funções publicas
    //da interface
    public abstract class BaseNotifyViewModel : INotifyPropertyChanged
    {
        //Observador
        //O evento publica da interface responsavel por 
        //observar as alterações de informação
        public event PropertyChangedEventHandler? PropertyChanged;

        //Antes de implamentar a notificação é preciso importar
        //a bliblietec de chamada de membro (nome do atributo)
        //using System.Runtime.CompilerServices;
        //Da biblieteca vamos usar o recusro CallermenberName
        //responsavel por identificar automaticamente o
        //nome do campo q esta sendo alterado

        //Criar a função de notificação
        public void OnPropertyChanged(
           [CallerMemberName] string propertyName = "")
        {
            //Se o campo for alterado iremos disparar
            //a notificação
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

    }
}
