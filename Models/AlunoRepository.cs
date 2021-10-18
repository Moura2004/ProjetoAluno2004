 using System;
 using System.Collections.Generic;
 using MySqlConnector;

  namespace ProjetoAluno2021.Models
  {
      public class AlunoRepository{

         private const string DadosConexao = "Database=aluno_2021;Data source=localhost;User id=root;";
      
         public void TestarConexao(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando!");
            Conexao.Close();
         }
         
          // operacoes da manipulacao no banco de dados da classe 'Aluno'
         //CRUD -> inserir(C) Aluno no banco, listar(R), alterar(U),excluir(D)
           
          public Aluno buscarPorid(int id){
           
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
             Conexao.Open(); //abrir conexao
              
               //definir query ="select * from Aluno where id=100"
               String Query = "select * from Aluno where id=@id";
               MySqlCommand Comando = new MySqlCommand(Query,Conexao);
               Comando.Parameters.AddWithValue("@id",id);//controle para sql-injection
                
                MySqlDataReader Reader = Comando.ExecuteReader();
                
                 Aluno userEncontrado = new Aluno();
                 if(Reader.Read()){
                  userEncontrado.id = Reader.GetInt32("id");
 
                  if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                  userEncontrado.Nome=Reader.GetString("Nome");

                  if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                  userEncontrado.Login=Reader.GetString("Login");
                  
                  if(!Reader.IsDBNull(Reader.GetOrdinal("Cpf")))
                  userEncontrado.Cpf=Reader.GetString("Cpf");

                  if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                  userEncontrado.Senha=Reader.GetString("Senha");
                  
                  
                  userEncontrado.DataNascimento=Reader.GetDateTime("DataNascimento");
                 }
                
                
                
                    
                   
                      
                    
                     

               //retornar Lista de Alunos
               
                Conexao.Close();//fechar conexao
                return userEncontrado;
  
          
          
          
          
          
          
          
          
          }



          public List<Aluno> listar(){
          
           MySqlConnection Conexao = new MySqlConnection(DadosConexao);
             Conexao.Open(); //abrir conexao
              
               //definir query ="select * from Aluno"
               String Query = "select * from Aluno";
               MySqlCommand Comando = new MySqlCommand(Query,Conexao);
               
                MySqlDataReader Reader = Comando.ExecuteReader();
                
                 List<Aluno> Lista = new List<Aluno>();
                 while(Reader.Read()){
                    
                    Aluno userEncontrado = new Aluno();
                   userEncontrado.id = Reader.GetInt32("id");
                   
                   
                    if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                   userEncontrado.Nome = Reader.GetString("Nome");
                   
                   if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                   userEncontrado.Login = Reader.GetString("Login");
                  
                   if(!Reader.IsDBNull(Reader.GetOrdinal("Cpf")))
                   userEncontrado.Cpf = Reader.GetString("Cpf");
                   
                   if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                   userEncontrado.Senha = Reader.GetString("Senha");
                   
                   if(!Reader.IsDBNull(Reader.GetOrdinal("DataNascimento")))
                   userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
                     Lista. Add(userEncontrado);

                    }
                     

               //retornar Lista de Alunos
               
                Conexao.Close();//fechar conexao
                return Lista;

          }




          public void inserir(Aluno user) {

          MySqlConnection Conexao = new MySqlConnection(DadosConexao);
             Conexao.Open(); //abrir conexao
              
                //definir query "insert int tabela (campo1,campo2) values (info1,info2)";
               String Query="insert into Aluno (Nome,Login,Cpf,Senha,DataNascimento) values (@Nome,@Login,@Cpf,@Senha,@DataNascimento)";

            //comando e os controles para sql-injection
             MySqlCommand Comando = new MySqlCommand(Query,Conexao);
             
             Comando.Parameters.AddWithValue("@Nome",user.Nome);//controle para sql-injection
             Comando.Parameters.AddWithValue("@Login",user.Login);//controle para sql-injection
             Comando.Parameters.AddWithValue("@Cpf",user.Cpf);//controle para sql-injection
             Comando.Parameters.AddWithValue("@Senha",user.Senha);//controle para sql-injection
             Comando.Parameters.AddWithValue("@DataNascimento",user.DataNascimento);//controle para sql-injection
             
              Comando.ExecuteNonQuery(); //executar no banco de dados

             Conexao.Close();//fechar conexao


          
          
          
          
          }


            public void atualizar(Aluno user){
                 
             MySqlConnection Conexao = new MySqlConnection(DadosConexao);
             Conexao.Open(); //abrir conexao
              
                //definir query "update Table SET campo1=info1, campo2=info where id=@id=10";
               String Query="Update Aluno SET Nome=@Nome, Login=@Login,Cpf=@Cpf, Senha=@Senha,DataNascimento=@DataNascimento where id=@id";

            //comando e os controles para sql-injection
             MySqlCommand Comando = new MySqlCommand(Query,Conexao);
             Comando.Parameters.AddWithValue("@id",user.id);//controle para sql-injection
             Comando.Parameters.AddWithValue("@Nome",user.Nome);//controle para sql-injection
             Comando.Parameters.AddWithValue("@Login",user.Login);//controle para sql-injection
             Comando.Parameters.AddWithValue("@Cpf",user.Cpf);//controle para sql-injection
             Comando.Parameters.AddWithValue("@Senha",user.Senha);//controle para sql-injection
             Comando.Parameters.AddWithValue("@DataNascimento",user.DataNascimento);//controle para sql-injection
             
              Comando.ExecuteNonQuery(); //executar no banco de dados

             Conexao.Close();//fechar conexao


            }

          public void remover(Aluno user){

              MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abrir conexao

             //definir a query(sq)
            String Query="delete from Aluno where id=@id";

           

              //definir comando  
             MySqlCommand Comando = new MySqlCommand(Query,Conexao);
             Comando.Parameters.AddWithValue("@id",user.id);//controle para sql-injection
                
                
            
                Comando.ExecuteNonQuery(); //executar no banco de dados

             Conexao.Close();     //fechar no banco de dados

          }
         
      }



  }