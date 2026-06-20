// See https://aka.ms/new-console-template for more information

using ChainOfResponsibilityPattern;
using Microsoft.Extensions.DependencyInjection;

var serivices = new ServiceCollection();
serivices.AddTransient<IDispensar>(sp => new FiveHunderedNoteDispensar(
    new TwoHundredNoteDispensar(
        new HundredNoteDispensar()
        )
    )
);

var serviceProvider = serivices.BuildServiceProvider();

Console.WriteLine("Enter the amount (Amount should be multiple of hundred) :");

int amountWithdrawn = Convert.ToInt32(Console.ReadLine());

if (amountWithdrawn == 0 || amountWithdrawn % 100 != 0) 
{
    Console.WriteLine("Please Enter the amount in multple of 100, Thank you !!");
    return;
}


IDispensar dispensar = serviceProvider.GetRequiredService<IDispensar>();

dispensar.Dispense(amountWithdrawn);
