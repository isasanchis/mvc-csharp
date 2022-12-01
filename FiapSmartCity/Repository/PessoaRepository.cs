using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;
using System.Data;
using System.Data.SqlClient;

namespace FiapSmartCity.Repository
{
    public class PessoaRepository
    {
        public IList<Pessoa> Listar()
        {
            IList<Pessoa> lista = new List<Pessoa>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT ID, NOME, ENDERECO FROM PESSOA";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    Pessoa pessoa = new Pessoa();
                    pessoa.Id = Convert.ToInt32(dataReader["ID"]);
                    pessoa.Nome = dataReader["NOME"].ToString();
                    pessoa.Endereco = dataReader["ENDERECO"].ToString();

                    // Adiciona o modelo da lista
                    lista.Add(pessoa);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return lista;
        }

        public Pessoa Consultar(int id)
        {

            Pessoa pessoa = new Pessoa();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT ID, NOME, ENDERECO FROM PESSOA WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    pessoa.Id = Convert.ToInt32(dataReader["ID"]);
                    pessoa.Nome = dataReader["NOME"].ToString();
                    pessoa.Endereco = dataReader["ENDERECO"].ToString();
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return pessoa;
        }

        public void Inserir(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PESSOA ( NOME, ENDERECO ) VALUES ( @nome, @endereco ) ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters["@nome"].Value = pessoa.Nome;
                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters["@endereco"].Value = pessoa.Endereco;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PESSOA SET NOME = @nome , ENDERECO = @endereco WHERE ID = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@nome"].Value = pessoa.Nome;
                command.Parameters["@endereco"].Value = pessoa.Endereco;
                command.Parameters["@id"].Value = pessoa.Id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PESSOA WHERE ID = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
