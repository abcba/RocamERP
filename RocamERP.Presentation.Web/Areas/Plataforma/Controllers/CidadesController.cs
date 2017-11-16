﻿using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using RocamERP.Presentation.Web.Exceptions;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class CidadesController : Controller
    {
        private readonly ICidadeApplicationService _cidadeApplicationService;
        private readonly IEstadoApplicationService _estadoApplicationService;
        
        public CidadesController(ICidadeApplicationService cidadeApplicationService, IEstadoApplicationService estadoApplicationService)
        {
            _cidadeApplicationService = cidadeApplicationService;
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index(string prefix = "", string estado = "")
        {
            ViewBag.Estado = new SelectList(_estadoApplicationService.GetAll());

            var listVM = new List<CidadeViewModel>();
            var list = _cidadeApplicationService.GetAll()
                .Where(c => c.Nome.ToLower().Contains(prefix.ToLower()))
                .Where(c =>
                {
                    if (!string.IsNullOrWhiteSpace(estado))
                    {
                        return c.Nome == estado;
                    }

                    return true;
                })
                .OrderBy(c => c.Nome);

            Mapper.Map(list, listVM);
            return View(listVM.OrderBy(c => c.EstadoId));
        }

        public ActionResult Details(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeVM);
        }

        public ActionResult Create()
        {
            var estados = _estadoApplicationService.GetAll();
            var estadosVM  = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(estados);

            CidadeViewModel cidadeVM = new CidadeViewModel();
            cidadeVM.LoadEstadosList(estadosVM);
            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Create(CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Add(cidade);

                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(_estadoApplicationService.GetAll(), "Nome", "Nome", model.EstadoId);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);
            var estadosVM = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoApplicationService.GetAll());
            cidadeVM.LoadEstadosList(estadosVM);

            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Edit(string id, CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Update(cidade);

                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Delete(int id, CidadeViewModel model)
        {
            _cidadeApplicationService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
