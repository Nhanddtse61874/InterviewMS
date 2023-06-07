using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.InterfaceRepository
{
    public interface ITeacherRepository
    {
        Task AddteacherListAsync(List<Teacher> teachers);

        Task AddteacherAsync(Teacher teacher);

        Task Remove(Guid id);

        List<Teacher> GetAll();

        Teacher SearchByNameExactly(string name);
    }
}
