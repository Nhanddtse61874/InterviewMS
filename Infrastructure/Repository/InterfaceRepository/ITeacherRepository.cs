using Infrastructure.Models;

namespace Infrastructure.Repository.InterfaceRepository
{
    public interface ITeacherRepository
    {
        Task AddTeacherListAsync(List<Teacher> teachers);

        Task AddTeacherAsync(Teacher teacher);

        Task Remove(Guid id);

        List<Teacher> GetAll();

        Teacher SearchByNameExactly(string name);
    }
}
