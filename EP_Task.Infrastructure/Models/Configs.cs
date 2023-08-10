using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Infrastructure.Models
{
    public class Configs
    {
        public string ToKenKey { get; set; }
        public int TokenTimeOut { get; set; }
        public int RefreshTokenTimeout { get; set; }

    }
}
