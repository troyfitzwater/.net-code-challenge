using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class CompensationRepository : IComepnsationRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IComepnsationRepository> _logger;

        public CompensationRepository(ILogger<IComepnsationRepository> logger, EmployeeContext employeeContext)
        {
            _logger = logger;
            _employeeContext = employeeContext;
        }

        public Compensation Add(Compensation compensation)
        {
            _employeeContext.Compensations.Add(compensation);

            return compensation;
        }

        public Compensation GetById(string id)
        {
            return _employeeContext.Compensations.Find(id);
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}