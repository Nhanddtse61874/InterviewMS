using Infrastructure.Context;
using Infrastructure.Models;
using Infrastructure.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.HandleRepository
{
    public class CrossReferenceRepository : ICrossReferenceRepository
    {
        private readonly SchoolContext _context;
        private readonly DbSet<CrossReference> _dbSet;
        public CrossReferenceRepository(SchoolContext context)
        {
            _context = context;
            _dbSet = _context.CrossReference;
        }

        public async Task AddListCrossReferenceAsync(List<CrossReference> crossReferences)
        {
            await _dbSet.AddRangeAsync(crossReferences);
            await _context.SaveChangesAsync();
        }

        public bool CheckExistedRelation(Guid teacherId, Guid studentId)
        => _dbSet.Where(x => x.StudentId == studentId && x.TeacherId == teacherId).Count() > 0;
    }
}
