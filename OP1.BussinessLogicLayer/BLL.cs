using OP1.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP1.BussinessLogicLayer
{
    public class BLL
    {
        DataBaseLogicLayer.DLL dll;
        public BLL()
        {
            dll = new DataBaseLogicLayer.DLL();
        }
        public int SystemControl(string UserName, string Password)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                return dll.SystemControl(new Entities.Users()
                {
                    UserName = UserName,
                    Password = Password

                });
            }
            else
            {
                return -1; //this will provide us missing parameter error.
            }

        }

        public int AddRegistry(string Name, string Surname, string PhoneNumberI, string PhoneNumberII, string PhoneNumberIII,
            string Email, string WebAddress, string Address, string Description)
        {
            if (!string.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Surname) && !string.IsNullOrEmpty(PhoneNumberI))
            {
                return dll.AddRegistry(new Entities.Directory()
                {
                    ID = Guid.NewGuid(),
                    Name = Name,
                    Surname = Surname,
                    PhoneNumberI = PhoneNumberI,
                    PhoneNumberII = PhoneNumberII,
                    PhoneNumberIII = PhoneNumberIII,
                    Email = Email,
                    WebAddress = WebAddress,
                    Address = Address,
                    Description = Description

                });
            }
            else
            {
                return -1; // This will trigger the missing parameter error.
            }
        }

        public int EditRegistry(Guid ID, string Name, string Surname, string PhoneNumberI, string PhoneNumberII, string PhoneNumberIII,
            string Email, string WebAddress, string Address, string Description)
        {
            if (ID != Guid.Empty)
            {
                return dll.EditRegistry(new Entities.Directory()
                {
                    ID = ID,
                    Name = Name,
                    Surname = Surname,
                    PhoneNumberI = PhoneNumberI,
                    PhoneNumberII = PhoneNumberII,
                    PhoneNumberIII = PhoneNumberIII,
                    Email = Email,
                    WebAddress = WebAddress,
                    Address = Address,
                    Description = Description,
                });

            }
            else
            {
                return -1;
            }
        }

        public int DeleteRegistry(Guid ID)
        {
            if (ID != Guid.Empty)
            {
                return dll.DeleteRegistry(ID);
            }
            else
            {
                return -1;
            }
        }

        public List<Directory> RegistryList()
        {
            List<Directory> DirectoryList = new List<Directory>();
            try
            {
                SqlDataReader reader = dll.RegistryList();
                while (reader.Read())
                {
                    DirectoryList.Add(new Directory()
                    {
                        ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0), // if reader's 0. index is not equal to empty , than get 0.
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Surname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PhoneNumberI = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        PhoneNumberII = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        PhoneNumberIII = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        WebAddress = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Address = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Description = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                    }
                        );
                }
                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                dll.OptionsConnection();
            }
            return DirectoryList;
        }

        public Directory RegistryListID(Guid ID)
        {
            Directory DirectoryListID = new Directory();
            try
            {
                SqlDataReader reader = dll.RegistryListID(ID);
                while (reader.Read())
                {
                    DirectoryListID = new Directory()
                    {
                        ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0), // if reader's 0. index is not equal to empty , than get 0.
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Surname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PhoneNumberI = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        PhoneNumberII = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        PhoneNumberIII = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        WebAddress = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Address = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Description = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                dll.OptionsConnection();
            }
            return DirectoryListID;
        }
    }
}
