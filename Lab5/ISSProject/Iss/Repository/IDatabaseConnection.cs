using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    internal interface IDatabaseConnection
    {
        public void OpenConnection();
        public void CloseConnection();
    }
}
