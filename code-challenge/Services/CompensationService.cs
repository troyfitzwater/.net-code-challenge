using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly IComepnsationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, IComepnsationRepository comepnsationRepository)
        {
            _logger = logger;
            _compensationRepository = comepnsationRepository;
        }

        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        public Compensation GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetById(id);
            }
            else
            {
                return null;
            }
        }
    }
}