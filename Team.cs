namespace Sharp2;

public class Team
{
    protected string name;
    protected int number;

    public Team(string name_value, int number_value)
    {
        name = name_value;
        number = number_value;
    }

    public Team()
    {
        name = "МИЭТ";
        number = 1965;
    }
    
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Number
    {
        get
        {
            return number;
        }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Регистрационный номер должен быть положительным");
            }
            else
            {
                number = value;
            }
        }
    }

    public virtual object DeepCopy()
    {
        Team team = new Team(name, number);
        return team;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (this.GetType() != obj.GetType())
            return false;
        return (Team)obj == this;
    }

    public static bool operator==(Team obj1, Team obj2)
    {
        return (obj1.name == obj2.name) && (obj1.number == obj2.number);
    }

    public static bool operator !=(Team obj1, Team obj2)
    {
        return !(obj1 == obj2);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode() + number.GetHashCode();
    }

    public override string ToString()
    {
        return "Name: " + name + " ID number: " + number.ToString();
    }
}