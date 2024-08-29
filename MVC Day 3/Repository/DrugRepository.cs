using Microsoft.EntityFrameworkCore;
using MVC_Day_3.Data;
using MVC_Day_3.Repository.IRepository;

namespace MVC_Day_3.Repository
{
    public class DrugRepository : IDrugRepository
    {
        ApplicationDBContext _context;

        public DrugRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(Drug obj)
        {
            _context.Add(obj);
        }

        public void Update(Drug obj)
        {
            _context.Update(obj);
        }

        public void Delete(int id)
        {
            var drug = GetbyId(id);
            _context.Remove(drug);
        }

        public List<Drug> GetAll()
        {

            return _context.Drugs.ToList();
        }

        public Drug GetbyId(int id)
        {
            return _context.Drugs.FirstOrDefault(d => d.Id == id);
        }

        public Drug GetByIdAsNoTracking(int id)
        {
            return _context.Drugs.AsNoTracking().FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public Drug UniqueName(string name, int id)
        {
            return _context.Drugs.FirstOrDefault(x => x.Name == name && x.Id != id);
        }


        public List<Drug> GetByCompID(int Compid)
        {
            return _context.Drugs.Where(e => e.CompanyId == Compid).ToList();
        }

    }
}
