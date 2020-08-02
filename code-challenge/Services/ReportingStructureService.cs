using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public ReportingStructure GetByEmployeeId(string id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
            {
                return null;
            }
            else
            {
                var numberOfReports = CalculateNumberOfReports(employee);

                var reportingStructure = new ReportingStructure
                {
                    Employee = employee,
                    NumberOfReports = numberOfReports

                };

                return reportingStructure;
            }
        }

        // recursively loop through a given employee's direct reports, and each 
        // of those direct reports until we reach one that is completely null (no reports)
        public int CalculateNumberOfReports(Employee employee)
        {
            int directReportsCounter = 0;

            if (employee.DirectReports != null)
            {
                foreach (var report in employee.DirectReports)
                {
                    directReportsCounter ++;
                    directReportsCounter += CalculateNumberOfReports(report);
                }
            }
            
            return directReportsCounter;
        }
    }
}