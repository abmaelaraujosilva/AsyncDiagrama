using System.Threading;
using System.Threading.Tasks;

namespace AsyncAtividade.Models
{
    public class _Tarefa
    {

        public async Task Tarefa(int ms)
        {
            await Task.Delay(ms);
        }

        public async Task Tarefa(int ms, CancellationToken token)
        {
            await Task.Delay(ms, token);
        }
    }
}
