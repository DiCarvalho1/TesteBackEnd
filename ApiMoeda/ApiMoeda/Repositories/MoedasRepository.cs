using ApiMoeda.Database;
using ApiMoeda.Models;
using ApiMoeda.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoeda.Repositories
{
    class MoedasRepository : IMoedasRepository
    {
        private readonly MoedasContext _moedas;
        public MoedasRepository(MoedasContext moedas)
        {
            _moedas = moedas;
        }
        public void Cadastrar(Dinheiro dinheiro)
        {
            _moedas.Add(dinheiro);
            _moedas.SaveChanges();
        }

        public List<Dinheiro> Obter()
        {
            var item =_moedas.Dinheiros.AsQueryable();

            return item.ToList();
        }

        void IMoedasRepository.Excluir(int id)
        {
            var item = _moedas.Find<Dinheiro>(id);
            _moedas.Remove<Dinheiro>(item);
            _moedas.SaveChanges();
        }
    }
}
