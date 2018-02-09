using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        //O controller de Cliente espera no construtor um objeto IClienteAppService
        //Precisamos injetar esse parâmetro no construor através de um container de injeção de dependência (existem vários no caso utilizei o Ninject)
        //Para instalar utilize o Packege Manger Consolor selecionando o Projeto MVC. Digite o seguinte comando: Install-Package Ninject.MVC5
        //Injeção de dependência
        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            //Transforma todos os Cliente (Domain.Entities) para ClienteViewModel (ViewModels.ClienteViewModel)
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.GetAll());
            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.ObterClientesEspeciais());
            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, IEnumerable<ClienteViewModel>>(cliente);
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _clienteAppService.Add(clienteDomain);

                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, IEnumerable<ClienteViewModel>>(cliente);
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteAppService.Update(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);

        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, IEnumerable<ClienteViewModel>>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        //Utilizando o atributo ActionName(“Delete”) faz que o roteamento do site aceite o método DeleteConfirmed como Delete 
        //quando uma URL que inclua o /Delete/ for acionada via Post.
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            _clienteAppService.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}
