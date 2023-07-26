using LINQ;

delegate bool EligibilityCheck(People person);
class Program
{
    public static void Main(string[] args)
    {/*
        People[] people =
        {
            new People() {Name="john",Age=18 },
            new People() {Name="tom",Age=21 },
            new People() {Name="sam",Age=20 },
            new People() {Name="jerry",Age=15 },
            new People() {Name="ben",Age=19 },

        };*/
        /*
        People[] voters= new People[people.Length];
        int i = 0;
        foreach ( People person in people ) {
            if (person.Age >= 18)
            {
                voters[i]=person;
                Console.WriteLine(person.Name);
                i++;
            }
                
        }*/
     /* List<People> voters= VoterCheck.where(people,delegate(People person)
      {
           
            return person.Age >= 18;
        });
        foreach (People voter in voters)
        {
            Console.WriteLine(voter.Name);
        }*/

       /* People[] voters =people.Where(person=>person.Age >= 18).ToArray();
        foreach (People voter in voters)
        {
            Console.WriteLine(voter.Name);
        }*/

       // List<People> voters = people.Where(person => person.Age >= 18).ToList();
       
        /*
        var voters = from person in people where person.Age >=18 select person;
        foreach (People voter in voters)
        {
            Console.WriteLine(voter.Name);
        }*/

        ExamplesForClassification ex= new ExamplesForClassification();
        // ex.example1();
        //  ex.FliteringWhere();
        //  ex.filteringoftype();
        // ex.SortingOrderBy();
        ex.grouping();
    }
}