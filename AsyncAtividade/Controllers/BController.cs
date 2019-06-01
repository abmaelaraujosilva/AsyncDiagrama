using AsyncAtividade.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAtividade.Controllers
{
    public class BController : Controller
    {
        _Tarefa _tarefa = new _Tarefa();
        public async Task<IActionResult> Index()
        {
            // Monkeys Xamirin "Quinta feira do F#"
            CancellationTokenSource CancelSource = new CancellationTokenSource();
            var token = CancelSource.Token;

            var Task1 = _tarefa.Tarefa(1000, token);
            var Task2 = _tarefa.Tarefa(2000, token);
            await Task.WhenAny(Task1, Task2);
            CancelSource.Cancel();
            var Task3 = _tarefa.Tarefa(1000);
            var Task4 = _tarefa.Tarefa(2000);
            List<Task> tarefas = new List<Task>();
            tarefas.Add(Task3);
            tarefas.Add(Task4);

            while(tarefas.Count > 0)
            {
                var TT = await Task.WhenAny(tarefas);

                tarefas.Remove(TT);
            }

            ViewBag.Messagem = "Execução terminou";
            return View();

            
        }
        private async Task TarefaFunc()
        {
            await Task.Delay(1000);
        }
    }
}
