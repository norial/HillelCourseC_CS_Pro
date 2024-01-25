class Actor
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
}

abstract class ArtObject
{
    public string Author { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
}

class Film : ArtObject
{
    public int Length { get; set; }
    public IEnumerable<Actor> Actors { get; set; }
}

class Book : ArtObject
{
    public int Pages { get; set; }
}

class Program
{
    static void Main()
    {
        var data = new List<object>()
        {
            "Hello",
            new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
            new List<int>() {4, 6, 8, 2},
            new string[] {"Hello inside array"},
            new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                new Actor() { Name = "Jack Nicholson", Birthdate = new DateTime(1937, 4, 22)},
                new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
            }},
            new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
            }},
            new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
            "Leonardo DiCaprio"
        };

        // 1. Виведіть усі елементи, крім ArtObjects
        Console.WriteLine(string.Join(", ", data.Where(item => !(item is ArtObject) && !(item is List<int>) && !(item is string[]))));

        // 2. Виведіть імена всіх акторів
        Console.WriteLine(string.Join(", ", data.OfType<Film>()
            .SelectMany(film => film.Actors)
            .Select(actor => actor.Name)));
        //TODO: 3. Виведіть кількість акторів, які народилися в серпні
        Console.WriteLine(data.OfType<Actor>().Count(actor => actor.Birthdate.Month == 8));

        //TODO: 4. Виведіть два найстаріших імена акторів
        Console.WriteLine(string.Join(", ", data.OfType<Actor>()
            .OrderByDescending(actor => actor.Birthdate)
            .Take(2)
            .Select(actor => actor.Name)));

        // 5. Вивести кількість книг на авторів
        Console.WriteLine(string.Join(", ", data.OfType<Book>()
            .GroupBy(book => book.Author)
            .Select(group => $"{group.Key}: {group.Count()}")));

        // 6. Виведіть кількість книг на одного автора та фільмів на одного режисера
        Console.WriteLine($"Books per Author: {data.OfType<Book>()
            .GroupBy(book => book.Author)
            .Count()}, Films per Director: {data.OfType<Film>()
            .GroupBy(film => film.Author)
            .Count()}");

        //TODO: 7. Виведіть, скільки різних букв використано в іменах усіх акторів
        Console.WriteLine(data.OfType<Actor>()
            .SelectMany(actor => actor.Name.ToLower()
            .Distinct())
            .Count(char.IsLetter));

        // 8. Виведіть назви всіх книг, упорядковані за іменами авторів і кількістю сторінок
        Console.WriteLine(string.Join(", ", data.OfType<Book>()
            .OrderBy(book => book.Author)
            .ThenBy(book => book.Pages)
            .Select(book => book.Name)));

        // 9. Виведіть ім'я актора та всі фільми за участю цього актора
        Console.WriteLine(string.Join(", ", data.OfType<Film>()
            .SelectMany(film => film.Actors, (film, actor) => new { ActorName = actor.Name, FilmName = film.Name })));

        // 10. Виведіть суму загальної кількості сторінок у всіх книгах і всі значення int у всіх послідовностях у даних
        Console.WriteLine($"Total Pages in Books: {data.OfType<Book>()
            .Sum(book => book.Pages)}, Sum of Int Values: {data.OfType<IEnumerable<int>>()
            .SelectMany(seq => seq)
            .Sum()}");

        // 11. Отримати словник з ключем - автор книги, значенням - список авторських книг
        Console.WriteLine(string.Join(", ", data.OfType<Book>()
            .GroupBy(book => book.Author)
            .ToDictionary(group => group.Key, group => string.Join(", ", group.Select(book => book.Name)))));

        // 12. Вивести всі фільми "Метт Деймон", за винятком фільмів з акторами, імена яких представлені в даних у вигляді рядків
        Console.WriteLine(string.Join(", ", data.OfType<Film>()
            .Where(film => film.Actors
            .Any(actor => actor.Name == "Matt Damon" && !data.OfType<string>()
            .Contains(actor.Name)))
            .Select(film => film.Name)));
    }
}