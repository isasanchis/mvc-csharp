using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaRepository PessoaRepository;

        public PessoaController()
        {
            PessoaRepository = new PessoaRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoa = PessoaRepository.Listar();
            return View(listaPessoa);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new Pessoa());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                PessoaRepository.Inserir(pessoa);

                @TempData["mensagem"] = "Pessoa cadastrada com sucesso!";
                return RedirectToAction("Index", "Pessoa");

            }
            else
            {
                return View(pessoa);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var pessoa = PessoaRepository.Consultar(Id);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Models.Pessoa pessoa)
        {

            if (ModelState.IsValid)
            {
                PessoaRepository.Alterar(pessoa);

                @TempData["mensagem"] = "Pessoa alterada com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            else
            {
                return View(pessoa);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var Pessoa = PessoaRepository.Consultar(Id);
            return View(Pessoa);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            PessoaRepository.Excluir(Id);

            @TempData["mensagem"] = "Pessoa removida com sucesso!";

            return RedirectToAction("Index", "Pessoa");
        }
    }
}
