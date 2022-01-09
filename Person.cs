using System.Globalization;

namespace Sharp2;

public class Person
{
    private string name;
    private string surname;
    private System.DateTime date;

    public Person()
    {
        name = "Ivan";
        surname = "Ivanov";
        date = new DateTime(1976, 2, 29);
    }

    public Person(string name_value, string surname_value, DateTime date_value)
    {
        name = name_value;
        surname = surname_value;
        date = date_value;
    }
    
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public string Surname
    {
        get => surname;
        set => surname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Date
    {
        get => date;
        set => date = value;
    }

    public int Year
    {
        get => date.Year;
        set => date = new DateTime(value, date.Month, date.Day);
    }

    public override string ToString()
    {
        return "Name: " + name + " Surname: " + surname + " Date of birth: " + date.ToString(CultureInfo.CurrentCulture);
    }

    public virtual string ToShortString()
    {
        return "Name: " + name + " Surname: " + surname;
    }
    
    public virtual object DeepCopy()
    {
        Person person = new Person(name, surname, date);
        return person;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (this.GetType() != obj.GetType())
            return false;
        return (Person)obj == this;
    }

    public static bool operator ==(Person obj1, Person obj2)
    {
        return (obj1.name == obj2.name) && (obj1.surname == obj2.surname) && (obj1.date == obj2.date);
    }

    public static bool operator !=(Person obj1, Person obj2)
    {
        return !(obj1 == obj2);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode()+surname.GetHashCode()+date.GetHashCode();
    }
}