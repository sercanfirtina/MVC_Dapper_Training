using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public sealed class MvcDBHelper
    {
        private static volatile AbstractDapperRepo _repositoryInstance;

        private static object _syncRoot = new object();


        public MvcDBHelper()
        {

        }

        public static AbstractDapperRepo Repository
        {
            get
            {
                if (_repositoryInstance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_repositoryInstance == null)
                             _repositoryInstance = new DapperRepository("ConnectionName");
                    }
                }
                return _repositoryInstance;
            }
        }
    }
}