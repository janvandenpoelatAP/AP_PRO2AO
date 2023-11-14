using Microsoft.EntityFrameworkCore;

namespace Voorbeeld_07_01_EFSamurai;

public class Program
{
    static void Main(string[] args)
    {
        InsertSamurai();
        SimpleSamuraiQuery();
        Filtering();
        RetrieveAndUpdateSamurai();
        QueryAndUpdateBattleDisconnected();
        Delete();
        InsertNewPkFkGraph();
        AddChildToExistingObjectWhileTracked();
        AddChildToExistingObjectNotTracked(4);
        EagerLoadingWithQoutes();
        ProjectSomeProperties();
    }
    private static void InsertSamurai()
    {
        var samurai = new Samurai() { Name = "Dimitri" };
        using (var context = new SamuraiContext())
        {
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
    }
    private static void SimpleSamuraiQuery()
    {
        using (var context = new SamuraiContext())
        {
            var samurais = context.Samurais.ToList();
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
    private static void Filtering()
    {
        using (var context = new SamuraiContext())
        {
            var samurais = context.Samurais.Where(x => x.Name == "Sampson").ToList();
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
            context.SaveChanges();
        }
    }
    private static void RetrieveAndUpdateSamurai()
    {
        using (var context = new SamuraiContext())
        {
            var samurai = context.Samurais.First();
            samurai.Name += " Updated";
            context.SaveChanges();
        }
    }
    private static void QueryAndUpdateBattleDisconnected()
    {
        Battle battle;
        using (var context = new SamuraiContext())
        {
            battle = context.Battles.First();
        }
        battle.EndDate = DateTime.Now;
        using (var context = new SamuraiContext())
        {
            context.Battles.Update(battle);
            context.SaveChanges();
        }
    }
    private static void Delete()
    {
        Samurai samurai;
        using (var context = new SamuraiContext())
        {
            samurai = context.Samurais.First();
        }
        using (var context = new SamuraiContext())
        {
            context.Samurais.Remove(samurai);
            context.SaveChanges();
        }
    }
    private static void InsertNewPkFkGraph()
    {
        var samurai = new Samurai()
        {
            Name = "Kambei Shimada",
            Quotes = new List<Quote>()
            {
                new Quote()
                {
                    Text = "I've come to save you"
                }
            }
        };
        using (var context = new SamuraiContext())
        {
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
    }
    private static void AddChildToExistingObjectWhileTracked()
    {
        using (var context = new SamuraiContext())
        {
            var samurai = context.Samurais.First();
            samurai.Quotes.Add(new Quote()
            {
                Text = "I bet you're happy I've saved you!"
            });
            context.SaveChanges();
        }
    }
    private static void AddChildToExistingObjectNotTracked(int samuraiId)
    {
        var quote = new Quote()
        {
            Text = "Now that I've saved you, will you feed me dinner?",
            SamuraiId = samuraiId
        };
        using (var context = new SamuraiContext())
        {
            context.Quotes.Add(quote);
            context.SaveChanges();
        }
    }
    private static void EagerLoadingWithQoutes()
    {
        using (var context = new SamuraiContext())
        {
            var samuraiWithQuotes = context.Samurais.Include(s => s.Quotes).ToList();
        }
    }
    private static void ProjectSomeProperties()
    {
        using (var context = new SamuraiContext())
        {
            var samuraiWithQuotes = context.Samurais.Select(s => new { s.Id, s.Name, s.Quotes }).ToList();
            var idAndNames = context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        }
    }
    public struct IdAndName
    {
        public int Id;
        public string Name;
        public IdAndName(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}