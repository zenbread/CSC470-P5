namespace P5
{
    class Preference
    {
        public Preference(string username, string name, string value)
        {
            Username = username;
            Name = name;
            Value = value;
        }

        public string Username { get; }
        public string Name { get; }
        public string Value { get; }
    }
}
