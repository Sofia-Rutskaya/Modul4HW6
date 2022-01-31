using Modul4HW6;
using Modul4HW6.Data;
using Modul4HW6.Queries;
using Modul4HW6.Helper;
using Modul4HW6.Data.EntityConfigurations;

public class Program
{
    public static void Main(string[] args)
    {
        Tasks(args);

        Console.WriteLine("Done");
        Console.ReadLine();
    }

    public static async void Tasks(string[] args)
    {
        using (var db = new SampleContextFactory().CreateDbContext(args))
        {
            var info = new AddInfoDb(db);
            var transact = new TransactionCreate();
            await transact.AddTransaction(args, async () => await info.CheckDb(args));

            var queries = new Query(db);

            await transact.AddTransaction(args, async () => await queries.First());
            await transact.AddTransaction(args, async () => await queries.Second());
            await transact.AddTransaction(args, async () => await queries.Third());
        }
    }
}