using Infrastructure.Context;
using Infrastructure.Models;
using Infrastructure.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.HandleRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;
        private readonly DbSet<Student> _dbSet;
        public StudentRepository(SchoolContext context)
        {
            _context = context;
            _dbSet = _context.Student;
        }

        public async Task AddStudentListAsync(List<Student> students)
        {
            await _dbSet.AddRangeAsync(students);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            await _dbSet.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id) 
        { 
            var student = await _dbSet.FindAsync(id);
            if (student is not null)
                _dbSet.Remove(student);
            else
                throw new Exception("Student is not exist");
        }

        public List<Student> SearchByName(string name)
        => _dbSet.Where(x => x.FullName.Contains(name))
            .Include(x => x.CrossReferences)
            .ThenInclude(y => y.Teacher)
            .OrderBy(y => y.DOB)
            .ToList();

        public Student SearchByNameExactly(string name)
        => _dbSet.FirstOrDefault(x => x.FullName == name);
    }
}
