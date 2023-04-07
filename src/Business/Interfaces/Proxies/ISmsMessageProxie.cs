using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Proxies
{
    public interface ISmsMessageProxie
    {
        Task SendMessage(string text, string phoneTo);
    }
}
