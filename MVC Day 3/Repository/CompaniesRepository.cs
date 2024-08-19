using MVC_Day_3.Data;
using MVC_Day_3.Models;

namespace MVC_Day_3.Repository
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly ApplicationDBContext _context;

        public CompaniesRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public void Add(Company obj)
        {
            _context.Add(obj);
        }

        public void Update(Company obj)
        {
            _context.Update(obj);
        }

        public void Delete(int? id)
        {
            var comp = GetbyId(id);
            _context.Remove(comp);
        }

        public List<Company> GetAll()
        {

            return _context.Companies.ToList();
        }

        public Company GetbyId(int? id)
        {
            return _context.Companies.FirstOrDefault(d => d.Id == id);
        }

        public bool Any(int id)
        {
            return _context.Companies.Any(x => x.Id == id);
        }

        public Company First(string name, int id)
        {
            return _context.Companies.FirstOrDefault(x => x.Name == name && x.Id != id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
