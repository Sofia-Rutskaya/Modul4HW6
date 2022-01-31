using Modul4HW6;
using Modul4HW6.Data;
using Modul4HW6.Queries;
using Modul4HW6.Helper;
using Modul4HW6.Data.EntityConfigurations;

public class Program
{
    public static async Task Main(string[] args)
    {
        using (var db = new SampleContextFactory().CreateDbContext(args))
        {
            var info = new AddInfoDb(db);
            var transact = new TransactionCreate();
            await transact.AddTransaction(args, async () => await info.CheckDb(args));
        }

        Console.WriteLine("Done");
        Console.ReadLine();
    }
}