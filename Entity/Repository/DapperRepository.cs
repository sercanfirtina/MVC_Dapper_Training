using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class DapperRepository:AbstractDapperRepo
    {
        public DapperRepository(string connectionName) :base(connectionName)
        {

        }

        public DapperRepository(IDbConnection dbConnection) :base(dbConnection)
        {

        }
    }
}
