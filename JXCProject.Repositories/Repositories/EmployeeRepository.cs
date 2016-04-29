using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Repositories;
using JXCProject.Domain.Models;
using System.Data;

namespace JXCProject.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(JXCContext unitOfWork)
            : base(unitOfWork)
        { }
    }
}
