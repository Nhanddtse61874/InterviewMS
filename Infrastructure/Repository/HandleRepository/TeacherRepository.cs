using Infrastructure.Context;
using Infrastructure.Models;
using Infrastructure.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.HandleRepository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext _context;
        private readonly DbSet<Teacher> _dbSet;
        public TeacherRepository(SchoolContext context)
        {
            _context = context;
            _dbSet = _context.Teacher;
        }

        public async Task AddTeacherListAsync(List<Teacher> teachers)
        {
            await _dbSet.AddRangeAsync(teachers);
            await _context.SaveChangesAsync();
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            await _dbSet.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var teacher = await _dbSet.FindAsync(id);
            if (teacher is not null)
                _dbSet.Remove(teacher);
            else
                throw new Exception("teacher is not exist");
        }

        public List<Teacher> GetAll()
        {
            return _dbSet.Include(x => x.CrossReferences).ThenInclude(y => y.Student).OrderBy(x => x.FullName).ToList();
        }

        public Teacher SearchByNameExactly(string name)
        {
            return _dbSet.FirstOrDefault(x => x.FullName == name);
        }
    }
}
