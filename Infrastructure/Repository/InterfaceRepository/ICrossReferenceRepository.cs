using Infrastructure.Models;

namespace Infrastructure.Repository.InterfaceRepository
{
    public interface ICrossReferenceRepository
    {
        Task AddListCrossReferenceAsync(List<CrossReference> crossReferences);

        bool CheckExistedRelation(Guid teacherId, Guid studentId);
    }
}
