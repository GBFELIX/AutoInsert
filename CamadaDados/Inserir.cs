using System;
using System.Threading.Tasks;
using MySqlConnector;

namespace CamadaDados
{
    public class Inserir
    {
        private readonly string _connectionString;

        public Inserir(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task InserirDadosAsync()
        {
            await using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            string sql = "INSERT INTO Pessoas (Nome, Funcao, Salario, DataNascimento) VALUES (@Nome, @Funcao, @Salario, @DataNascimento) ";
            await using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", "João");
            command.Parameters.AddWithValue("@Funcao", "pedreiro");
            command.Parameters.AddWithValue("@Salario", 3000.00);
            command.Parameters.AddWithValue("@DataNascimento", new DateTime(1990, 1, 1));

            await command.ExecuteNonQueryAsync();
        }
    }
}
