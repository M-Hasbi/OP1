using OP1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP1.DataBaseLogicLayer
{
   public class DLL
    {
        //In this sector you can find Sql connection
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        int ReturnValues;
        public DLL()
        {
            //huseyin 
            connection = new SqlConnection(@"Data Source=OLAF\SQLEXPRESS; Initial Catalog =PhoneBook; User ID=OLAF\CEM");

        }
        public void OptionsConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
            }
        }
        public int SystemControl(Users U1)
        {
            try
            {
                command = new SqlCommand("select count(*) from Users where UserName = @UserName and Password=@Password", connection);
                command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = U1.UserName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = U1.Password;
                OptionsConnection();
                ReturnValues = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                OptionsConnection();
            }
            return ReturnValues;
        }
        public int AddRegistry(Directory D1)
        {
            try
            {
                command = new SqlCommand("insert into Directory(ID,Name,Surname,PhoneNumberI,PhoneNumberII,PhoneNumberIII,Email,WebAdress,Address,Description) " +
                    "Values (@ID, @Name, @Surname, @PhoneNumberI, @PhoneNumberII, @PhoneNumberIII, @Email, @WebAddress, @Address, @Description)", connection );
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = D1.ID;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = D1.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = D1.Surname;
                command.Parameters.Add("@PhoneNumberI", SqlDbType.NVarChar).Value = D1.PhoneNumberI;
                command.Parameters.Add("@PhoneNumberII", SqlDbType.NVarChar).Value = D1.PhoneNumberII;
                command.Parameters.Add("@PhoneNumberIII", SqlDbType.NVarChar).Value = D1.PhoneNumberIII;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = D1.Email;
                command.Parameters.Add("@WebAddress", SqlDbType.NVarChar).Value = D1.WebAddress;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = D1.Address;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = D1.Description;
                OptionsConnection();
                ReturnValues = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               
            }
            finally
            {
                OptionsConnection();
            }
            return ReturnValues;
        }
        public int EditRegistry(Directory D1)
        {
            try
            {
                command = new SqlCommand(@"Update Directory Name=@Name,
Surname=@Surname,
PhoneNumberI=@PhoneNumberI,
PhoneNumberII=@PhoneNumberII,
PhoneNumberIII=@PhoneNumberIII,
Email=@Email,
WebAddress=@WebAddress,
Address=@Address,
Description=@Description
where ID=@ID", connection);
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = D1.ID;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = D1.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = D1.Surname;
                command.Parameters.Add("@PhoneNumberI", SqlDbType.NVarChar).Value = D1.PhoneNumberI;
                command.Parameters.Add("@PhoneNumberII", SqlDbType.NVarChar).Value = D1.PhoneNumberII;
                command.Parameters.Add("@PhoneNumberIII", SqlDbType.NVarChar).Value = D1.PhoneNumberIII;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = D1.Email;
                command.Parameters.Add("@WebAddress", SqlDbType.NVarChar).Value = D1.WebAddress;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = D1.Address;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = D1.Description;
                OptionsConnection();
                ReturnValues = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                OptionsConnection();
            }
            return ReturnValues;
        }
        public int DeleteRegistry(Guid ID)
        {
            try
            {
                command = new SqlCommand("Delete Directory" +
                    "where ID=@ID", connection);
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value =ID; 
             
                OptionsConnection();
                ReturnValues = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


            }
            finally 
            {
                OptionsConnection();
            }
            return ReturnValues;
        }
        public SqlDataReader RegistryList()
        {
            command = new SqlCommand("select * from Directory", connection);
            OptionsConnection();
            return command.ExecuteReader();
        }
        public SqlDataReader RegistryListID(Guid ID)
        {
            command = new SqlCommand("select * from Directory where ID=@ID", connection);
            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
            OptionsConnection();
            return command.ExecuteReader();
        }
    }
}
