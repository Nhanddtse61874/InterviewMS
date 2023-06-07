using Infrastructure.Models;

namespace Infrastructure.Repository.InterfaceRepository
{
    public interface IStudentRepository
    {
        Task AddStudentListAsync(List<Student> students);

        Task AddStudentAsync(Student student);

        Task Remove(Guid id);

        List<Student> SearchByName(string name);

        Student SearchByNameExactly(string name);
    }
}
