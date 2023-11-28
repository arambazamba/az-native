namespace ActorClient;
using System;
using System.Threading.Tasks;
using Dapr.Actors;
using Dapr.Actors.Client;

using IBankActorInterface;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Creating a Bank Actor");
        var actor = ActorId.CreateRandom();
        var bankUser = ActorProxy.Create<IBankActor>(actor, "BankActor");
        await bankUser.SetupNewAccount(1000m);

        var balance = await bankUser.GetAccountBalance();
        Console.WriteLine($"Balance for account '{balance.AccountId}' is '{balance.Balance:c}'.");

        Console.WriteLine($"Withdrawing 50");
        var status = await bankUser.Withdraw(new WithdrawRequest(){ Amount = 50m });
        Console.WriteLine($"Withdrawal status: {status.Status}");
        
        balance = await bankUser.GetAccountBalance();
        Console.WriteLine($"Balance for account '{balance.AccountId}' is '{balance.Balance:c}'.");
    }
}