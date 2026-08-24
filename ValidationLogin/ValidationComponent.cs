namespace ValidationLogin
{
    //Usar uma classe tradicionar
    //pois iremos armazenar e manipular
    //informações na memoria RAM
    public class ValidationComponent
    {
        //Definir as propriedade referente
        //ao nosso "PAR" de compoenentes
        //Ou seja iremos juntar o
        //campo de texto e a label de informação
        //e trabalhar como se fosse uma unica coisa
        private Entry EntryText {  get; set; }
        private Label LabelInformation { get; set; }

        //Criar o construtor para realização do vinculo
        public ValidationComponent(
            Entry txtCampo, Label lblValidation)
        {
            //Ou seja, sempre que eu vou instanciar
            //esta classe sou obrigado a informar
            //o campo text e a label que seram vinculadas
            EntryText = txtCampo;
            LabelInformation = lblValidation;
        }

        //Função para retornar o conteudo do campo texto
        public string GetText()
        {
            return EntryText.Text;
        }

        //Método para definir a mensagem de validação
        public void SetValidation(string MsgValidation)
        {
            //Atualizo o texto da label
            //e a exibo na tela
            LabelInformation.Text = MsgValidation;
            LabelInformation.IsVisible = true;
        }
        
        //Criar uma segunda versão do método acima
        //para aplicar animações
        public void SetValidation(
            string MsgValidation, bool IsTremer)
        {
            //Aplicar enimação de tremor
            //no campos de texto para chamar
            //atenção do usuário
            if (IsTremer)
                Animation.Tremer(EntryText);
            //Chamar o método anterior para definir a mensagem
            SetValidation(MsgValidation);
        }

        //Método para ocular a label de informação
        public void HideValidation()
        {
            LabelInformation.IsVisible = false;
        }

        //Método que retorno se o campo está vazio
        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(EntryText.Text);
        }
    }
}
