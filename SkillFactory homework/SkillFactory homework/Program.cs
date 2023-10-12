var phoneBook = new List<Contact>();

# region ДЗ
phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

var newPhoneBook = phoneBook
    .OrderBy(c => c.Name)
    .ThenBy(c => c.LastName);

foreach (var c in newPhoneBook)
    Console.WriteLine($"{c.Name} {c.LastName}");

#endregion

while (true)
{
    var input = Console.ReadKey().KeyChar;
    var parsed = int.TryParse(input.ToString(), out int pageNumber);

    if (!parsed || pageNumber < 1 || pageNumber > 3)
    {
        Console.WriteLine();
        Console.WriteLine("Страницы не существует");
    }
    else
    {
        var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
        Console.WriteLine();
        foreach (var entry in pageContent)
            Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);
        Console.WriteLine();
    }
}

public class Contact
{
    public Contact(string name, string lastName, long phoneNumber, string email)
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public string Name { get; }
    public string LastName { get; }
    public long PhoneNumber { get; }
    public string Email { get; }
}