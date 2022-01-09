using System.Collections;
using System.Reflection.Metadata;

namespace Sharp2;

public class ResearchTeam : Team
{
    private string theme;
    private TimeFrame duration;
    private System.Collections.ArrayList partisipants = new System.Collections.ArrayList();
    private System.Collections.ArrayList papers = new System.Collections.ArrayList();

    public ResearchTeam(string name_value, string theme_value, int number_value, TimeFrame timeFrame)
    {
        name = name_value;
        theme = theme_value;
        number = number_value;
        duration = timeFrame;
        partisipants = new ArrayList();
        papers = new ArrayList();
    }

    public ResearchTeam()
    {
        name = "МИЭТ";
        number = 1965;
        theme = "IT";
        duration = TimeFrame.Year;
        partisipants = new ArrayList();
        papers = new ArrayList();
    }

    public ArrayList Papers
    {
        get => papers;
        set => papers = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Paper Last
    {
        get
        {
            if (papers == null)
                return null;
            else
            {
                Paper last = (Paper) papers[0];
                for (int i = 1; i < papers.Count; i++)
                {
                    Paper temp = (Paper) papers[index: i];
                    if (temp.Date > last.Date)
                        last = temp;
                }

                ref Paper lastref = ref last;
                return lastref;
            }
        }
    }

    public void AddPapers(params Paper[] papers_arr)
    {
        foreach (Paper item in papers_arr)
        {
            papers.Capacity++;
            papers.Add(item);
        }
    }

    public override string ToString()
    {
        string papersString = " Papers: \n";

        if (papers.Count > 0)
        {
            foreach (Paper paper in papers)
            {
                papersString += paper.ToString() + '\n';
            }
        }
        
        string partisipantsString = new string("Partisipants: \n");
        if (partisipants.Count > 0)
        {
            foreach (Person item in partisipants)
            {
                partisipantsString += item.ToString() + '\n';
            }
        }
        return "Theme: " + theme + '\n'
               + "Name: " + Name + '\n'
               + "Number: " + Number + '\n'
               + "Duration: " + duration + '\n'
               + papersString + partisipantsString;
    }

    public string ToShortString()
    {
        return "Name: " + name + " Theme " + theme + " Number " + number.ToString() + " Duration " + duration;
    }

    public override object DeepCopy()
    {
        ResearchTeam researchTeam = new ResearchTeam(name, theme, number, duration);
        researchTeam.papers = new ArrayList();
        foreach (Paper item in papers)
        {
            researchTeam.papers.Add(item);
        }

        researchTeam.partisipants = new ArrayList();
        foreach (Person item in partisipants)
        {
            researchTeam.partisipants.Add(item);
        }

        return researchTeam;
    }

    public ArrayList Partisipants
    {
        get => partisipants;
        set => partisipants = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Team Team
    {
        get
        {
            Team team = new Team(name, number);
            return team;
        }
        set
        {
            name = value.Name;
            number = value.Number;
        }
    }

    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }

    public void AddMembers(params Person[] person_arr)
    {
        foreach (Person item in person_arr)
        {
            partisipants.Capacity++;
            partisipants.Add(item);
        }
    }

    public System.Collections.Generic.IEnumerable<Person> NoPapers()
    {
        foreach (Person item in partisipants)
        {
            bool noPapers = true;

            foreach (Paper paper in papers)
            {
                if (paper.Author == item)
                {
                    noPapers = false;
                }
                
            }
            
            if (noPapers)
            {
                yield return item;
            }
        }
    }
    
    public System.Collections.Generic.IEnumerable<Paper> PapersForLastNYears(int n)
    {
        //throw new NotImplementedException();
        DateTime dateTime = new DateTime(DateTime.Today.Year - 2, DateTime.Today.Month, DateTime.Today.Day);
        
        foreach (Paper paper in papers) 
        {
            if (paper.Date > dateTime)
            {
                yield return paper;
            }
        }
    }


}
    