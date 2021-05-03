using Rotina.Enumeradores;
using Rotina.Model;
using Rotina.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rotina.Services
{
    class Csv : ICsv
    {
        public void Gravar(string filePath, List<DadosMoedaDTO> lDadosMoedaDTO)
        {
            Console.WriteLine($"{DateTime.Now} - Realizando gravação do arquivo 'Resultado_aaaammdd_HHmmss.csv'");

            using (TextWriter sw = new StreamWriter($"{filePath}\\Resultado_aaaammdd_HHmmss.csv"))
            {
                string cabecalhoIdMoeda = "ID_MOEDA";
                string cabecalhoDataReferencia = "DATA_REF";
                string cabecalhoValorCotacao = "vlr_cotacao";
                sw.WriteLine($"{cabecalhoIdMoeda}; {cabecalhoDataReferencia}; {cabecalhoValorCotacao}");

                foreach (var item in lDadosMoedaDTO)
                {
                    string idMoeda = item.IdMoeda;
                    string dataReferencia = item.DataReferencia.ToString();
                    string valorCotacao = item.ValorCotacao;

                    sw.WriteLine($"{idMoeda}; {dataReferencia}; {valorCotacao}");
                }

                Console.WriteLine($"{DateTime.Now} - Arquivo gravado! Este se encontra no caminho {filePath}\\Resultado_aaaammdd_HHmmss.csv");
            }
        }

        public List<DadosMoeda> LerDadosMoeda(string filePath, Dinheiro dinheiro)
        {
            using (var reader = new StreamReader($"{filePath}\\DadosMoeda.csv"))
            {
                Console.WriteLine($"{DateTime.Now} - Iniciando a leitura do arquivo DadosMoeda.csv");

                List<DadosMoeda> moeda = new List<DadosMoeda>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (values[0] != "ID_MOEDA")
                    {
                        moeda.Add(new DadosMoeda() { IdMoeda = values[0], DataReferencia = Convert.ToDateTime(values[1]) });
                    }
                }

                List<DadosMoeda> moedasFiltradas = moeda.FindAll(x => x.DataReferencia >= dinheiro.Data_Inicio && x.DataReferencia <= dinheiro.Data_Fim);

                Console.WriteLine($"{DateTime.Now} - DadosMoeda.csv lido");

                return moedasFiltradas;
            }
        }

        List<DadosMoedaDTO> ICsv.LerDadosCotacao(string filePath, List<DadosMoeda> lmoeda)
        {
            using (var reader = new StreamReader($"{filePath}\\DadosCotacao.csv"))
            {
                Console.WriteLine($"{DateTime.Now} - Iniciando retorno dos valores correspondentes do arquivo DadosCotacao.csv");
                Console.WriteLine($"{DateTime.Now} - Este arquivo é um pouco grande, aguarde um pouco por gentileza...");

                List<DadosCotacao> cotacao = new List<DadosCotacao>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (values[0] != "vlr_cotacao")
                    {
                        cotacao.Add(new DadosCotacao() { ValorCotacao = values[0], CodigoCotacao = Convert.ToByte(values[1]), DataCotacao = Convert.ToDateTime(values[2]) });
                    }
                }

                List<DadosMoedaDTO> cotacaoFiltrada = new List<DadosMoedaDTO>();

                var lmoedasAgrupadas = lmoeda
                    .OrderBy(x => x.IdMoeda)
                    .GroupBy(x => x.IdMoeda)
                    .Select(a => a.ToList())
                    .ToList();

                foreach(var moeda in lmoedasAgrupadas)
                {
                    foreach(var item in moeda)
                    {
                        int valorDePara = (int)Enum.Parse(typeof(CodigoCotacao.Cotacao), moeda[0].IdMoeda);

                        var cotacaoDoItem = cotacao.FindAll(x => x.CodigoCotacao == valorDePara && x.DataCotacao == item.DataReferencia).FirstOrDefault();

                        //cotacaoFiltrada.Add(new DadosCotacao() { CodigoCotacao = cotacaoDoItem.CodigoCotacao, DataCotacao = cotacaoDoItem.DataCotacao, ValorCotacao = cotacaoDoItem.ValorCotacao });

                        cotacaoFiltrada.Add(new DadosMoedaDTO { IdMoeda = item.IdMoeda, DataReferencia = item.DataReferencia, ValorCotacao = cotacaoDoItem.ValorCotacao });
                    }
                }

                Console.WriteLine($"{DateTime.Now} - O arquivo DadosCotacao.csv foi lido!");
                return cotacaoFiltrada;
            }
        }
    }
}
