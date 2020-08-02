using challenge.Models;
using System;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface IComepnsationRepository
    {
        Compensation GetById(String id);
        Compensation Add(Compensation compensation);
        Task SaveAsync();
    }
}