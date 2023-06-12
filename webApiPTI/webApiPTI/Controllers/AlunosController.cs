using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiPTI.Data;
using webApiPTI.Helper;
using webApiPTI.Models;
using webApiPTI.Repositorios;
using webApiPTI.Repositorios.Interfaces;

namespace webApiPTI.Controllers
{
   
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly SessionHelper _session = new SessionHelper();

        public AlunosController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var alunosResult = await _alunoRepositorio.GetAllAsync();
            return View(alunosResult);

        }

        public IActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    Aluno alunoInstaced = await _alunoRepositorio.CriarAsync(aluno);

                    if (alunoInstaced != null)
                    {
                        return RedirectToAction("Index", "Alunos");
                    }

                    return View(aluno);
                }
                return View(aluno);
            }
            catch (Exception ex)
            {
                return View(aluno);
            }
        }
    }
}
