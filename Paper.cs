using System.Globalization;

namespace Sharp2;

public class Paper
{
    public string Title
    {
        get;
        set;
    }

    public Person Author
    {
        get;
        set;
    }

    public DateTime Date
    {
        get;
        set;
    }

    public Paper()
    {
        Title = "IT in life";
        Author = new Person("Ivan", "Ivanov", new DateTime(1976, 02, 29));
        Date = new DateTime(1999, 01, 01);
    }

    public Paper(string title, Person person, DateTime date)
    {
        Title = title;
        Author = person;
        Date = date;
    }

    public override string ToString()
    {
        return "Title: " + this.Title + " Author: " + this.Author + " Date: " + this.Date.ToString();
    }
}