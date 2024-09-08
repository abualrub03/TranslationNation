using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Interfaces;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using ViewModel.AdminViewModels;

namespace RacoonProvider
{
    public class TN_DB_Accounts : Core.Disposable 
    {

        public List<Entities.Contact> getAllContacts()
        {
            using var DAL = new DataAccess.DataAccessLayer();
            return DAL.ExecuteReader<Entities.Contact>("spSelectFromTblContact");
        }
        public bool deleteContact(int Id)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Id", Value =  Id }
            };
            return DAL.ExecuteNonQuery("spDelFromTblContact");
        }
        public bool newContactRequest(Entities.Contact contact)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Name", Value =  contact.Name },
                new SqlParameter{ ParameterName = "@Email", Value =  contact.Email },
                new SqlParameter{ ParameterName = "@PhoneNumber", Value =  contact.PhoneNumber },
                new SqlParameter{ ParameterName = "@Service", Value =  contact.Service },
                new SqlParameter{ ParameterName = "@message", Value =  contact.message },

            };
            return DAL.ExecuteNonQuery("spInsertIntoTblContact");
        }
        public List<Entities.Contact> SearchIntblContact(string searchString, int start, int end)
        {
            string newStr = '%' + searchString + '%';
            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@searchString", Value =  newStr },
                new SqlParameter{ ParameterName = "@end", Value = end },
                new SqlParameter{ ParameterName = "@start", Value = start },
            };
            return DAL2.ExecuteReader<Entities.Contact>("spSearchIntblContactbyName");
        }
        public int spCountSearchByName(string searchString)
        {
            string newStr = '%' + searchString + '%';
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@searchedName", Value =  newStr },
            };
            var Count = DAL.ExecuteReader<ViewModel.AdminViewModels.CountContactsViewModel>("spCountSearchByName").FirstOrDefault();

            return Count.Count;

        }
       

        public int spNewCountSearchByName(string searchString, string filter)
        {

            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@searchString", Value =  searchString },
                new SqlParameter{ ParameterName = "@filterValue", Value =  filter },

            };
            var Count = DAL.ExecuteReader<ViewModel.AdminViewModels.CountContactsViewModel>("SearchAndFilterCount").FirstOrDefault();

            return Count.Count;

        }

        //TRANSLATION 
        public Entities.Accounts newSignUpClientRequest(string FullName, string Email, string BirthDate, string Password, bool AcceptTerms)
        {
            // Split the FullName into parts
            var nameParts = FullName.Split(' ');

            // Initialize name variables
            string firstName = nameParts.Length > 0 ? nameParts[0] : string.Empty;
            string secondName = nameParts.Length > 1 ? nameParts[1] : string.Empty;
            string thirdName = nameParts.Length > 2 ? nameParts[2] : string.Empty;
            string lastName = nameParts.Length > 3 ? nameParts[3] : string.Empty;

            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@FirstName", Value = firstName },
                new SqlParameter{ ParameterName = "@SecondName", Value = secondName },
                new SqlParameter{ ParameterName = "@ThirdName", Value = thirdName },
                new SqlParameter{ ParameterName = "@LastName", Value = lastName },
                new SqlParameter{ ParameterName = "@EmailAddress", Value = Email },
                new SqlParameter{ ParameterName = "@DateOfBirth", Value = BirthDate },
                new SqlParameter{ ParameterName = "@Password", Value = Password },
            };
            return DAL.ExecuteReader<Entities.Accounts>("sp_TN_DB_Acccounts_newSignUpClientRequest").FirstOrDefault();

        }
        public Entities.Accounts newSignUpTranslatorRequest(string FullName, string Email, string BirthDate, string Password, bool AcceptTerms)
        {
            // Split the FullName into parts
            var nameParts = FullName.Split(' ');

            // Initialize name variables
            string firstName = nameParts.Length > 0 ? nameParts[0] : string.Empty;
            string secondName = nameParts.Length > 1 ? nameParts[1] : string.Empty;
            string thirdName = nameParts.Length > 2 ? nameParts[2] : string.Empty;
            string lastName = nameParts.Length > 3 ? nameParts[3] : string.Empty;

            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@FirstName", Value = firstName },
                new SqlParameter{ ParameterName = "@SecondName", Value = secondName },
                new SqlParameter{ ParameterName = "@ThirdName", Value = thirdName },
                new SqlParameter{ ParameterName = "@LastName", Value = lastName },
                new SqlParameter{ ParameterName = "@EmailAddress", Value = Email },
                new SqlParameter{ ParameterName = "@DateOfBirth", Value = BirthDate },
                new SqlParameter{ ParameterName = "@Password", Value = Password },
            };
            return DAL.ExecuteReader<Entities.Accounts>("sp_TN_DB_Acccounts_newSignUpTranslatorRequest").FirstOrDefault();

        }
        public Entities.Accounts newSignUpSupervisorRequest(string FullName, string Email,string Location, string PhoneNumber, string Username, string University, string Password, bool AcceptTerms)
        {
            var nameParts = FullName.Split(' ');
            string firstName = nameParts.Length > 0 ? nameParts[0] : string.Empty;
            string secondName = nameParts.Length > 1 ? nameParts[1] : string.Empty;
            string thirdName = nameParts.Length > 2 ? nameParts[2] : string.Empty;
            string lastName = nameParts.Length > 3 ? nameParts[3] : string.Empty;

            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@FirstName", Value = firstName },
                new SqlParameter{ ParameterName = "@SecondName", Value = secondName },
                new SqlParameter{ ParameterName = "@ThirdName", Value = thirdName },
                new SqlParameter{ ParameterName = "@LastName", Value = lastName },
                new SqlParameter{ ParameterName = "@EmailAddress", Value = Email },
                new SqlParameter{ ParameterName = "@Location", Value = Location },
                new SqlParameter{ ParameterName = "@Password", Value = Password },
                new SqlParameter{ ParameterName = "@PhoneNumber", Value = PhoneNumber },
                new SqlParameter{ ParameterName = "@University", Value = University },
                new SqlParameter{ ParameterName = "@Username", Value = Username },
            };
            return DAL.ExecuteReader<Entities.Accounts>("sp_TN_DB_Acccounts_newSignUpSupervisorRequest").FirstOrDefault();

        }
        public Entities.Accounts newSignInRequest(string Email, string Password)
        {
            
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@EmailAddress", Value = Email },
                new SqlParameter{ ParameterName = "@Password", Value = Password }            
            };

            return DAL.ExecuteReader<Entities.Accounts>("sp_TN_DB_Acccounts_newSignInRequest").FirstOrDefault();

        }


    }
}
    