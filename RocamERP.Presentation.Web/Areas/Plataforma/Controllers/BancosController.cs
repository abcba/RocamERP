﻿using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class BancosController : BaseController
    {
        private readonly IBancoApplicationService _bancoApplicationService;

        public BancosController(IBancoApplicationService bancoApplicationService)
        {
            _bancoApplicationService = bancoApplicationService;
        }

        public ActionResult Index(string prefix = "", bool hideEmptyCheques = false)
        {
            var bancosVM = new List<BancoViewModel>();
            var bancos = _bancoApplicationService.GetAll()
                .Where(b =>
                {
                    return hideEmptyCheques == true ? b.Cheques.Any() : true;
                })
                .Where(b => b.Nome.ToLower().Contains(prefix.ToLower()))
                .OrderByDescending(b => b.Cheques.Count);

            Mapper.Map(bancos, bancosVM);
            return View(bancosVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BancoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var banco = Mapper.Map<BancoViewModel, Banco>(model);
                _bancoApplicationService.Add(banco);

                SendMessage("Banco cadastrado com sucesso.");
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var banco = _bancoApplicationService.Get(id);
            var bancoVM = Mapper.Map<Banco, BancoViewModel>(banco);

            return View(bancoVM);
        }

        [HttpPost]
        public ActionResult Edit(int id, BancoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var banco = Mapper.Map<BancoViewModel, Banco>(model);
                _bancoApplicationService.Update(banco);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = _bancoApplicationService.Get(id);
            var bancoVM = Mapper.Map<Banco, BancoViewModel>(model);

            return View(bancoVM);
        }

        [HttpPost]
        public ActionResult Delete(int id, BancoViewModel model)
        {
            _bancoApplicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

