using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Application.Interfaces
{
    public interface IQuartzTransaction
    {
        void Commit();
        Task CommitAsync(CancellationToken cancel);
    }
}
