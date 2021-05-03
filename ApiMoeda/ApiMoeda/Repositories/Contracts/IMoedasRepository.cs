using ApiMoeda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoeda.Repositories.Contracts
{
    public interface IMoedasRepository
    {
        public List<Dinheiro> Obter();

        public void Cadastrar(Dinheiro dinheiro);

        public void Excluir(int id);
    }
}
