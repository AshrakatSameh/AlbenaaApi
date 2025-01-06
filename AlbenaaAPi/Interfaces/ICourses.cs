using AlbenaaAPi.Dto;
using AlbenaaAPi.Entities;

namespace AlbenaaAPi.Interfaces
{
    public interface ICourses
    {
        Task<IEnumerable<Courses>> GetAll();
        Task<Courses> GetById(int id);
        Task<Courses> Add(CoursesDto dto);
        Task<Courses> Update(Courses courses);
        Task<Courses> Delete(int id);
    }
}
