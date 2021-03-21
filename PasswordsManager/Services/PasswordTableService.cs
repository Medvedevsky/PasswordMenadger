using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PasswordsManager.Models;
using System.Windows.Forms;

namespace PasswordsManager.Services
{
    public class PasswordTableService
    {

        private SqlConnection _connection;

        public PasswordTableService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
         

        public List<UserData> GetAll()
        {
            string sql = "SELECT * FROM [password_table]";

            List<UserData> dataList = new List<UserData>();

            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(sql, _connection);

                using (var dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        UserData userData = new UserData
                        {
                            Id = dataReader.GetInt32(0),
                            Login = dataReader.GetString(1),
                            Password = dataReader.GetString(2)
                        };

                        dataList.Add(userData);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _connection.Close();
            }

            return dataList;
        }


        public void Add(UserData data)
        {
            string sql = "INSERT INTO [password_table] ([login], [password]) VALUES ( @Login, @Password)";

            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(sql, _connection);

                command.Parameters.AddWithValue("@Login", data.Login);
                command.Parameters.AddWithValue("@Password", data.Password);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void ChangeData(int id, UserData data)
        {
            string sql = "UPDATE [password_table] SET [login] = @Login, [password] = @Password WHERE [id] = @Id";
            
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(sql, _connection);

                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@Login", data.Login);
                command.Parameters.AddWithValue("@Password", data.Password);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE [password_table] WHERE [id] = @Id";
            
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(sql, _connection);

                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
