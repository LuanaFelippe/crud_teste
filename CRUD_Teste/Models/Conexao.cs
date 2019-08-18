using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CRUD_Teste.Models
{
    public class Conexao
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;


        protected void AbrirConexao()
        {
            try
            {
                Con = new SqlConnection("Data Source=LUANA_NOTE\\SQLEXPRESS;Initial Catalog=db_Cliente;Integrated Security=True");
                Con.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void FecharConexao()
        {
            Con.Close();
        }

        public void Inserir(Usuario u)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("Insert into Usuario(Nome,CPF,Telefone) values(@v1, @v2, @v3)", Con);

                Cmd.Parameters.AddWithValue("@v1", u.Nome);
                Cmd.Parameters.AddWithValue("@v2", u.CPF);
                Cmd.Parameters.AddWithValue("@v3", u.Telefone);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar o usuário" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Atualizar(Usuario u)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("Update Usuario set nome=@v1, cpf=@v2, telefone=@v3 where id=@v4", Con);

                Cmd.Parameters.AddWithValue("@v4", u.id);
                Cmd.Parameters.AddWithValue("@v1", u.Nome);
                Cmd.Parameters.AddWithValue("@v2", u.CPF);
                Cmd.Parameters.AddWithValue("@v4", u.Telefone);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar usuário" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(Usuario u)
        {
            try
            {
                AbrirConexao();

                Cmd = new SqlCommand("delete from Usuario where id=@v1", Con);

                Cmd.Parameters.AddWithValue("@v1", u.id);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o registro do usuário" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }


        }

        public Usuario Consultar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("Select * From Usuario", Con);

                Usuario u = null;   

                if(Dr.Read())
                {
                    u = new Usuario();

                    u.id = Convert.ToInt64(Dr["id"]);
                    u.Nome = Convert.ToString(Dr["nome"]);
                    u.CPF = Convert.ToString(Dr["cpf"]);
                    u.Telefone = Convert.ToString(Dr["telefone"]);
                }

                return u;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao retornar a consulta dos registros dos usuários" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}