using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContatosApp.Data.Entities;
using Dapper;
using static System.Net.Mime.MediaTypeNames;

namespace ContatosApp.Data.Repositories
{
    public class ContatoRepository
    {
        //atributo

        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = SContatosApp; Integrated Security=True;";

        public void Insert(Contato contato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"INSERT INTO CONTATO (ID, NOME, EMAIL, TELEFONE, DATAHORACADASTRO)
                                    VALUES(@ID, @NOME, @EMAIL, @TELEFONE, @DATAHORACADASTRO)",
                                    new
                                    {
                                        @ID = contato.Id,
                                        @NOME = contato.Nome,
                                        @EMAIL = contato.Email,
                                        @TELEFONE = contato.Telefone,
                                        @DATAHORACADASTRO = contato.DataHoraCadastro,
                                    });
            }
        }

        public List<Contato> ListarTudo()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Contato>(@"SELECT ID, NOME, EMAIL, TELEFONE,
                                                 DATAHORACADASTRO, ATIVO FROM CONTATO WHERE ATIVO = 1").ToList();


            }
        }
        public Contato? GetById(Guid Id)
        {
 using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Contato>(@"SELECT ID, NOME, EMAIL, TELEFONE,
                                                 DATAHORACADASTRO, ATIVO FROM CONTATO WHERE ATIVO = 1 AND ID = @Id", new
                {
                   @ID = Id
                }).FirstOrDefault();
            }
        }
        public void Uptade(Contato c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"UPDATE CONTATO SET NOME =@NOME, EMAIL =@EMAIL, TELEFONE =@TELEFONE, 
                                     WHERE ID=@Id", new
                {
                    @NOME = c.Nome,
                    @EMAIL = c.Email,
                    @TELEFONE = c.Telefone,
                    @ID = c.Id
                });
            }
        }
        public void Delete(Contato contato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //DELETE FROM CONTATO WHERE ID=@ID
                connection.Execute(@"UPDATE CONTATO SET ATIVO = 0 WHERE ID=@Id", new
                {
                   
                    @ID = contato.Id
                });
            


            }
        }


    }
}