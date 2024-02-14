using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPAssignmentProject.Domain.Model;
using MVPAssignmentProject.Infrastructure.DatabaseContext;

namespace MVPAssignmentProject.Infrastructure.Services
{
    public class BrokerService:IBroker
    {
        private MVPAssignmentDbContext _dbContext;

        public BrokerService(MVPAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<BrokerDetails>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BrokerDetails> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(BrokerDetails entity)
        {
            _dbContext.BrokerDetails.Add(entity);
            int i= await _dbContext.SaveChangesAsync();
            if (i > 0)
                return entity.BrokerId;
            else
                return 0;
        }

        public Task<int> Update(BrokerDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(BrokerDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
