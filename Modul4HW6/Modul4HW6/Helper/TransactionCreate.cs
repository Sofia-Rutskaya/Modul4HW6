using Modul4HW6.Data;

namespace Modul4HW6.Helper
{
    public class TransactionCreate
    {
        public async Task AddTransaction(string[] args, Func<Task> func)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await func.Invoke();
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        await transaction.RollbackAsync();
                    }
                }
            }
        }
    }
}
