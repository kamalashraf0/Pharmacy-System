namespace MVC_Day_3.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Drug>? Drugs { get; set; } = new List<Drug>();
    }
}
