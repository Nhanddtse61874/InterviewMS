using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.InterfaceRepository
{
    public interface ICrossReferenceRepository
    {
        Task AddListCrossReferenceAsync(List<CrossReference> crossReferences);

        bool CheckExistedRelation(Guid teacherId, Guid studentId);
    }
}
