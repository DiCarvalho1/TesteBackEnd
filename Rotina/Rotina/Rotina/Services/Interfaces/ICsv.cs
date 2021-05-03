using Rotina.Model;
using Rotina.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rotina.Services
{
    interface ICsv
    {
        public List<DadosMoeda> LerDadosMoeda(string filePath, Dinheiro dinheiro);

        public List<DadosMoedaDTO> LerDadosCotacao(string filePath, List<DadosMoeda> lmoeda);
        void Gravar(string filePath, List<DadosMoedaDTO> lDadosMoedaDTO);
    }
}
