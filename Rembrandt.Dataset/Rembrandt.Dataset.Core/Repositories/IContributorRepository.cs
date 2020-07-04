using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Core.Repositories
{
    public interface IContributorRepository
    {
        Task<Contributor> GetAsync(int id);
    }
}