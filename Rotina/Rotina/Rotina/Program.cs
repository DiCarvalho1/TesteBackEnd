using ClosedXML.Excel;
using CsvHelper;
using Rotina.Model;
using Rotina.Models;
using Rotina.Services;
using Rotina.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Rotina
{
    class Program
    {
        private const string URL = "https://localhost:44337/api/dinheiro";

        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} - Seja bem vindo!");

            while (true)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                string filePath = AppDomain.CurrentDomain.BaseDirectory;

                IHttp http = new Http();
                ICsv csv = new Csv();

                var retornoApi = http.Get(URL);

                if (retornoApi != null)
                {
                    csv.Gravar(filePath, csv.LerDadosCotacao(filePath, csv.LerDadosMoeda(filePath, retornoApi)));
                }

                stopwatch.Stop();
                Console.WriteLine($"{DateTime.Now} - Tempo decorrido neste ciclo: {stopwatch.Elapsed}");
                Console.WriteLine($"{DateTime.Now} - A aplicação irá aguardar por 2 minutos antes de executar o ciclo novamente");
                Console.WriteLine("\n");
                Thread.Sleep(120000);
            }
        }
    }
}
