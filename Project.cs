namespace P5
{
    public class Project
    {
        public Project(string name)
        {
            Name = name;
        }

        public Project(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name}";
        }
    }
}
