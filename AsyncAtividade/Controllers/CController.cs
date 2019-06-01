using AsyncAtividade.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsyncAtividade.Controllers
{
    public class CController : Controller
    {
        _Tarefa _tarefa = new _Tarefa();
        public async Task<IActionResult> Index()
        {
            var proc1 = _tarefa.Tarefa(1000); // T1
            var proc2 = Tarefa1();

            await Task.WhenAll(proc1, proc2);

            ViewBag.Messagem = "Execução terminou";
            return View();
        }
        private async Task Tarefa1()
        {
            await _tarefa.Tarefa(1500); // T2

            await Task.WhenAny(_tarefa.Tarefa(1700), _tarefa.Tarefa(2000)); // T3 e T4
            
        }
    }
}