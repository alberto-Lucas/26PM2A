using ProjetoMVVM.Models;

namespace ProjetoMVVM.Services
{
    public class CarroService
    {
        CarroSingleton dbSingleton = CarroSingleton.Instancia;

        public void AdicionarSingleton(Carro value)
        {
            dbSingleton.Carro = value;
        }

        public Carro ConsultarSingleton()
        {
            return dbSingleton.Carro;
        }
    }
}
