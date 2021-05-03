using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Rotina.Models
{
    class Dinheiro
    {
        public int Id { get; set; }
        public string Moeda { get; set; }
        
        public DateTime Data_Inicio { get; set; }
        
        public DateTime Data_Fim { get; set; }
    }
}
