using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaDados.Teste
{
    public class testador
    {
        [Fact]
        public async Task TestInserirDadosAsync()
        {
            string connStr = "server=localhost;port=3306;database=ZSDB;user=root;password=125436;";
            Inserir inserir = new Inserir(connStr);
            await inserir.InserirDadosAsync();

            Assert.True(true, "Dados inseridos com sucesso."); 
        } 
    }
}
