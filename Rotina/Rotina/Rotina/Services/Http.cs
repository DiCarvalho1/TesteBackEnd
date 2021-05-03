using Rotina.Models;
using Rotina.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Rotina.Services
{
    class Http : IHttp
    {
        public Dinheiro Get(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine($"{DateTime.Now} - Consultando a API Moeda");

            HttpResponseMessage response = client.GetAsync("").Result; 
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var dataObjects = response.Content.ReadAsAsync<Dinheiro>().Result;

                    if (dataObjects != null)
                    {
                        Console.WriteLine($"{DateTime.Now} - Moeda retornada da api: {dataObjects.Moeda}, data inicio: {dataObjects.Data_Inicio}, data fim: {dataObjects.Data_Fim}");
                    } else
                    {
                        Console.WriteLine($"{DateTime.Now} - Nenhuma moeda retornada da api");
                    }

                    
                    return dataObjects;
                }
                catch (Exception a)
                {
                    throw new Exception($"{DateTime.Now} - Falha ao receber retorno da api", a);
                }
            }

            return new Dinheiro();
        }
    }
}
