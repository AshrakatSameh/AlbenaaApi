using AlbenaaAPi.Context;
using AlbenaaAPi.Dto;
using AlbenaaAPi.Entities;
using AlbenaaAPi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlbenaaAPi.Implementation
{
    public class CoursesServices : ICourses
    {

        private readonly AppDbContext _context;

        public CoursesServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Courses> Add(CoursesDto dto)
        {
            var MyCourse = new Courses
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                Duration = dto.Duration,
                TrainerName = dto.TrainerName
            };
            await _context.Courses.AddAsync(MyCourse);
            await _context.SaveChangesAsync();
            return MyCourse;
        }

        public async Task<Courses> Delete(int id)
        {
            var myCourse = _context.Courses.FirstOrDefault(d => d.Id == id);
            if (myCourse != null)
            {
                _context.Courses.Remove(myCourse);
                await _context.SaveChangesAsync();
                return myCourse;
            }
            return null;
        }

        public async Task<IEnumerable<Courses>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Courses> GetById(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Courses> Update(Courses courses)
        {
            var mycourses = await _context.Courses.FirstOrDefaultAsync(e => e.Id == courses.Id);
            if (mycourses != null)
            {


                mycourses.Title = courses.Title;
                mycourses.Description = courses.Description;
                mycourses.Price = courses.Price;
                mycourses.Duration = courses.Duration;
                mycourses.TrainerName = courses.TrainerName;

                await _context.SaveChangesAsync();
                return mycourses;

            }
            return null;
        }
    }
}
