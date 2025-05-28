namespace MOD3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = CreateEmployee.CreateRandomEmployee(500);
            Director director = new Director("Олександр", "Шевченко", new DateTime(1980, 5, 15));
            Сonversation conversation = new Сonversation(employees, director);
            conversation.GetCandidateToConversation();

        }
    }
}
