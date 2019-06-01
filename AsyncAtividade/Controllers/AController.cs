using AsyncAtividade.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsyncAtividade.Controllers
{
    public class AController : Controller
    {
        _Tarefa _tarefa = new _Tarefa();
        public async Task<IActionResult> Index()
        {
            await Task.WhenAll(Tarefa1(), Tarefa2());
            ViewBag.Messagem = "Execução terminou";
            return View();
        }
        private async Task Tarefa1()
        {
            await Task.WhenAll(_tarefa.Tarefa(1700), _tarefa.Tarefa(2000)); // T1 e T2
            await _tarefa.Tarefa(1500); // T4
        }
        private async Task Tarefa2()
        {
            await _tarefa.Tarefa(1700); // T3
            await Task.WhenAll(_tarefa.Tarefa(2000), _tarefa.Tarefa(1500)); // T5 e T6
        }
    }
}