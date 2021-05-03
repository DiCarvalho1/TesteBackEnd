using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiMoeda.Models
{
    public class Dinheiro
    {
        public int Id { get; set; }
        public string Moeda { get; set; }
        [JsonPropertyName("data_inicio")]
        public DateTime DataInicio { get; set; }
        [JsonPropertyName("data_fim")]
        public DateTime DataFim { get; set; }
    }
}
