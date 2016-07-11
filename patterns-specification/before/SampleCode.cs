using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Course
    {
        public List<Module> Modules { get; set; } = new List<Module>();
        public List<AuthorContract> AuthorContracts { get; set; } = new List<AuthorContract>();  
        public DateTime? PublicationDate { get; set; }
        public string Description { get; set; }
    }

    public class Module
    {
        public string SlideUrl { get; set; }
        public string MaterialsUrl { get; set; }
    }

    public class AuthorContract
    {
        public bool Signed { get; set; }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T target);
    }

    public class CourseReadyToPublishSpecification : ISpecification<Course>, ISpec<Course>
    {
        public bool IsSatisfiedBy(Course course)
        {
            if (course.Modules.Count == 0) return false;
            if (course.AuthorContracts.Count == 0) return false;
            if (!course.PublicationDate.HasValue) return false;
            if (IsNullOrEmpty(course.Description)) return false;
            if (course.Modules.Any(m => IsNullOrEmpty(m.SlideUrl))) return false;
            if (course.Modules.Any(m => IsNullOrEmpty(m.MaterialsUrl))) return false;
            if (course.AuthorContracts.Any(c => !c.Signed)) return false;
            return true;
        }

        public Expression<Func<Course, bool>> CriteriaExpression
        {
            get
            {
                return c => (c.Modules.Count > 0)
                            && (c.AuthorContracts.Count > 0)
                            && c.PublicationDate.HasValue
                            && !IsNullOrEmpty(c.Description)
                            && c.Modules.All(m => !IsNullOrEmpty(m.SlideUrl))
                            && c.Modules.All(m => !IsNullOrEmpty(m.MaterialsUrl))
                            && c.AuthorContracts.All(ac => ac.Signed);
            }
        }
    }

    public class CourseRepo
    {
        private IQueryable<Course> _courses;
        public IEnumerable<Course> List(ISpecification<Course> spec)
        {
            return _courses.ToList() // convert to in-memory list
                                     // ReSharper disable once ConvertClosureToMethodGroup
                .Where(c => spec.IsSatisfiedBy(c))
                .AsEnumerable();
        }
        public IEnumerable<Course> List2(Expression<Func<Course, bool>> predicateExpression)
        {
            return _courses
                .Where(predicateExpression)
                .AsEnumerable();
        }
        public IEnumerable<Course> List2(ISpec<Course> spec)
        {
            return _courses
                .Where(spec.CriteriaExpression)
                .AsEnumerable();
        }
    }

    public interface ISpec<T>
    {
        Expression<Func<T,bool>> CriteriaExpression { get; }
    }
}
