using System.Runtime.CompilerServices;

namespace Sharp2;

public class Program
{
    static void Main(string[] args)
    {
        // We create two objects of Team class with identical fields
        Team team1 = new Team("One", 12);
        Team team2 = new Team("One", 12);
        // We check if this objects are equal
        Console.WriteLine("Does objects equal?");
        Console.WriteLine(team1.Equals(team2));
        // We check if references of this objects are equal
        Console.WriteLine("Does objects references equal?");
        Console.WriteLine(object.ReferenceEquals(team1,team2));
        // We get HashCode of team1
        Console.WriteLine("HashCode team1");
        Console.WriteLine(team1.GetHashCode());
        // We get HashCode of team2
        Console.WriteLine("HashCode team2");
        Console.WriteLine(team2.GetHashCode());
        // task 2 try/catch section, if we uncomment this (25-35) we will receive an error
        /*
         try
        {
            team1.Number = -5;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        */
        // We create object of ResearchTeam class
        ResearchTeam researchTeam = new ResearchTeam();
        Person[] temp1 = {new Person(), new Person("Petr", "Petrov", DateTime.Today), new Person("Viktor", "Viktorov", DateTime.Today)};
        // We add members to this object
        researchTeam.AddMembers(temp1);
        Paper[] temp2 = {new Paper(), new Paper(), new Paper(), new Paper("Physics", new Person("Viktor", "Viktorov", DateTime.Today), DateTime.Today)};
        // We add papers to this object
        researchTeam.AddPapers(temp2);
        // We print researchTeam
        Console.WriteLine("researchTeam");
        Console.WriteLine(researchTeam.ToString());
        // We print Team property of researchTeam
        Console.WriteLine("Team property in researchTeam");
        Console.WriteLine(researchTeam.Team.ToString());
        // We make copy of researchTeam
        ResearchTeam researchTeam2 = (ResearchTeam) researchTeam.DeepCopy();
        // We add members to original object again
        researchTeam.AddMembers(temp1);
        // We print researchTeam
        Console.WriteLine("researchTeam");
        Console.WriteLine(researchTeam.ToString());
        // We print researchTeam2
        Console.WriteLine("researchTeam2");
        Console.WriteLine(researchTeam2.ToString());
        // We use the NoPapers iterator to find participants without papers
        Console.WriteLine("Partisipants with no papers");
        foreach (Person person in researchTeam.NoPapers())
        {
            Console.WriteLine(person.ToString());
        }
        // We use the PapersForLastNYears iterator to find papers for last two years
        Console.WriteLine("Papers for last two years");
        foreach (Paper paper in researchTeam.PapersForLastNYears(2))
        {
            Console.WriteLine(paper.ToString());
        }
    }
}