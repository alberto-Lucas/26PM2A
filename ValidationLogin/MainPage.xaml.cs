namespace ValidationLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            //Vincular os campos de email e senha
            //com suas respectivas label de validação
            //Nesse momento que vamos juntar
            //dois componentes diferente em um só
            ValidationComponent email =
                new ValidationComponent(txtEmail, lblValidationEmail);

            ValidationComponent senha =
                new ValidationComponent(txtSenha, lblValidationSenha);

            //Chamar validações
            //Se o retorno for falso abortamos a execução
            bool bEmail = ValidarEmail(email);
            bool bSenha = ValidarSenha(senha);

            if(!bEmail || !bSenha)
                return;

            //Só vai chegar aqui se estiver tudo certo
            DisplayAlert("Informação", "Login com sucesso", "OK");
        }

        //Função para validar o Email
        private bool ValidarEmail(ValidationComponent Email)
        {
            //iniciar definindo o resultado como falso
            bool resultado = false;

            //Realizar validações
            if (Email.IsEmpty())
                Email.SetValidation("Informe o email.", true);
            else if (!Email.GetText().Contains('@'))
                Email.SetValidation("Informe um email válido.", true);
            else if (Email.GetText() != "admin@")
                Email.SetValidation("Email incorreto.", true);
            else
            {
                resultado = true;
                Email.HideValidation();
            }

            return resultado;
        }

        //Função para validar a senha
        private bool ValidarSenha(ValidationComponent Senha)
        {
            bool resultado = false;

            if (Senha.IsEmpty())
                Senha.SetValidation("Informe a senha.", true);
            else if (Senha.GetText().Length < 5)
                Senha.SetValidation("Informe a senha com no " +
                                    "mínimo 5 caracteres.", true);
            else if (Senha.GetText() != "admin")
                Senha.SetValidation("Senha incorreta.", true);
            else
            {
                resultado = true;
                Senha.HideValidation();
            }

            return resultado;
        }
    }
}
