namespace P5
{
    class Preference
    {
        public Preference(string username, string name, string value)
        {
            UserName = username;
            Name = name;
            Value = value;
        }

        public string UserName { get; }
        public string Name { get; }
        public string Value { get; }
    }
}
