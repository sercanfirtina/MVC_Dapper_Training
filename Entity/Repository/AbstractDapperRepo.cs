using Dapper;
using Entity.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Entity.Repository
{
    public abstract class AbstractDapperRepo : IDisposable
    {

        #region Connection Process
        public readonly IDbConnection DbConnection;

        protected AbstractDapperRepo()
        {
            DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
        }

        public AbstractDapperRepo(string connectionName)
        {
            //takes connection string value from web config
            DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
        }

        public AbstractDapperRepo(IDbConnection dbConnection)
        {
            dbConnection = DbConnection;
        }

        #endregion


        #region CRUD Operations       

        public Tentity Insert<Tentity>(string sqlQuery, Tentity item) where Tentity : IDbModel
        {
            try
            {
                //add Dapper
                var result = DbConnection.ExecuteScalar(sqlQuery, item);
                item.SetId(result);
            }
            catch (Exception ex)
            {
                //log;
            }
            return item;
        }

        public IEnumerable<Tentity> GetAll<Tentity>(string sqlQuery) where Tentity : IDbModel
        {
            try
            {
                return DbConnection.Query<Tentity>(sqlQuery).ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public IEnumerable<Tentity> GetById<Tentity>(string sqlQuery, object parameters) where Tentity : IDbModel
        {
            try
            {
                return DbConnection.Query<Tentity>(sqlQuery, parameters).ToList();
            }
            catch (Exception)
            {
                return null;

            }
        }

        public Tentity Update<Tentity>(string sqlQuery,Tentity item) where Tentity : IDbModel
        {
            try
            {
                DbConnection.Execute(sqlQuery, item);
            }
            catch (Exception ex)
            {

                throw;
            }
            return item;
        }

        public void Delete<Tentity>(string sqlQuery,Tentity item) where Tentity : IDbModel
        {
            try
            {
                DbConnection.Execute(sqlQuery, item);
            }
            catch (Exception)
            {

                throw;
            }
        }

      
        #endregion


        #region Execute
        public void ExecuteNonQuery(string sqlQuery, object parameter)
        {
            try
            {
                DbConnection.Execute(sqlQuery, parameter);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void ExecuteNonQuery(string sqlQuery)
        {
            try
            {
                DbConnection.Execute(sqlQuery);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Execute(string sqlQuery ,object parameter)
        {
            try
            {
                return DbConnection.ExecuteScalar<int>(sqlQuery, parameter);
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public object Execute<T>(string sqlQuery,object parameter)
        {
            try
            {
                return DbConnection.ExecuteScalar<T>(sqlQuery, parameter);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion


        #region Dispose Operation
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
                DbConnection.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
