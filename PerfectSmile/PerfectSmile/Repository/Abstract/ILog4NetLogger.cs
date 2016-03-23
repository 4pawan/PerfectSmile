using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSmile.Repository.Abstract
{
    public interface ILog4NetLogger
    {
        void Info(string message);
        void Debug(string message);
        void Warn(string message);
        void Exception(string message);
    }
}
