using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.SqlQuery
{
    public static class QueryWarehouse
    {

        //query for multiplw model 
        public static class Employee
        {
            public static string Insert => @"insert into Employee   ([FirstName]
                                                                    ,[LastName]
                                                                    ,[DateOfBirth]
                                                                    ,[StartDate]
                                                                    ,[Department]
                                                                    ,[PhoneNumber]
                                                                    ,[Email]
                                                                    ,[City])                
                                                                  values (
                                                                    @FirstName,
                                                                    @LastName,
                                                                    @DateOfBirth,
                                                                    @StartDate,
                                                                    @Department,
                                                                    @PhoneNumber,
                                                                    @Email,
                                                                    @City
                                                                  )select SCOPE_IDENTITY() ";


            public static string Update => @" Update Employee set 
                                                [FirstName]    = @FirstName,
                                                [LastName]     = @LastName,
                                                [DateOfBirth]  = @DateOfBirth,
                                                [StartDate]    = @StartDate,
                                                [Department]   = @Department,
                                                [PhoneNumber]  = @PhoneNumber,
                                                [Email]        = @Email,
                                                [City]         = @City
                                                where Id=@ID";                
                                                               
            public static string Delete => "delete from employee with(nolock) where Id=@Id";
            public static string GetAll => "select * from employee with(nolock)"; //deadlock problem solved
            public static string GetById => "select * from employee with(nolock) where Id=@Id";
        }
    }
}
