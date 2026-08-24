namespace ValidationLogin
{
    //Usaremos uma classe estatica
    //pois ela não precisa ser instanciada
    //podemos chamar os métodos diretamente
    //toda classe estatica
    //obrigatoriamente seus métodos e funções
    //tambem precisam ser estaticos
    public static class Animation
    {
        //Criar um método genericao
        //que ira receber um componenete como parametro
        //e iremos aplicar uma animação de tremor
        //Podemos aplicar essa animção em qualquer
        //componenete visual
        static public async void Tremer(VisualElement elemento)
        {
            //Validar caso o componente esteja nulo
            if (elemento == null)
                return; //aborta a execução

            //Definir um tempo padrão de animação
            uint tempo = 50;

            //Listar os deslocamento
            //Colocar na ordem que deseja a animação
            var deslocamentos = 
                new[] {-15, 15, -10, 10, -5, 5 };

            //Loop que ira ler cada deslocamento
            //e aplicar a animação
            foreach(var movimento in deslocamentos )
            {
                //Primeiro é movimento em pixel horizontal
                //Segundo é movimento em pixel vertical
                //Terceiro tempo da animação
                await elemento.TranslateTo(movimento, 0, tempo);
            }
            //Por ultimo reseta o movimento em x
            elemento.TranslationX = 0;
        }
    }
}
