using MediatorPractice.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPractice.Application.Common.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindUserByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
