using MVC_Day_3.Models;

namespace MVC_Day_3.Repository
{
    public interface IDrugRepository
    {
        public void Add(Drug obj);

        public void Update(Drug obj);

        public void Delete(int? id);

        public List<Drug> GetAll();

        public Drug GetbyId(int? id);

        public void Save();

    }
}
