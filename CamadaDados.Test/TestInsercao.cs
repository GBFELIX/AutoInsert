
namespace CamadaDados.Test
{
    public class TestInsercao
    {
        [Fact]
        public async Task TestInserirDadosAsync()
        {
            string connStr = "server=localhost;port=3306;database=ZSDB;user=root;password=125436;";
            Inserir inserir = new Inserir(connStr);
            await inserir.InserirDadosAsync();
        }
    }
}