using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
