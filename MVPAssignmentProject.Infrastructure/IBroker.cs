﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPAssignmentProject.Domain.Model;

namespace MVPAssignmentProject.Infrastructure
{
    public interface IBroker:ICommonRepository<BrokerDetails>
    {
    }
}
