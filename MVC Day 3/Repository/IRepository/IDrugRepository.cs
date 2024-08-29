namespace MVC_Day_3.Repository.IRepository
{
    public interface IDrugRepository
    {
        public void Add(Drug obj);

        public void Update(Drug obj);

        public void Delete(int id);

        public List<Drug> GetAll();

        public Drug GetbyId(int id);
        public Drug GetByIdAsNoTracking(int id);

        public void Save();

        public Drug UniqueName(string name, int id);

        public List<Drug> GetByCompID(int Compid);

    }
}
