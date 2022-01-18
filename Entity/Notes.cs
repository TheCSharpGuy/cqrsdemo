namespace CQRSDemo.Entity
{
    public record Notes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}
