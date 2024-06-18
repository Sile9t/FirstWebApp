namespace FirstWebApp.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Desctiption { get; set; }
        public virtual ProductGroup? Group { get; set; }
        public int GroupId { get; set; }
    }
}
