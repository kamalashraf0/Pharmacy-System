using MVC_Day_3.Models;

namespace MVC_Day_3.Repository
{
    public interface ICompaniesRepository
    {

        public void Add(Company obj);



        public void Update(Company obj);



        public void Delete(int? id);



        public List<Company> GetAll();



        public Company GetbyId(int? id);



        public bool Any(int id);



        public Company First(string name, int id);



        public void Save();

    }
}
