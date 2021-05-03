using Rotina.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rotina.Services.Interfaces
{
    interface IHttp
    {
        public Dinheiro Get(string url);
    }
}
