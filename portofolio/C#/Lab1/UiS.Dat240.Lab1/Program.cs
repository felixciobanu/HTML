// TODO: Implement

using System;
using Microsoft.Extensions.DependencyInjection;
using UiS.Dat240.Lab1;
using UiS.Dat240.Lab1.Commands;
using UiS.Dat240.Lab1.Queues;


public class Program
{
    static void Main(string[] args)
    {
        // Gets collections and singletons
        var provider = TestSubmissions.CreateServiceProvider();
        var handler = provider.GetServices<ICommandHandler>();
        // TODO: Implement
        while (true)
        {
            Console.WriteLine("cmd>");
            var input = Console.ReadLine();
            
            // Count: 2 amount of elements in Kommando: string[]
            var kommando = input?.Split(" ", 2);
            
            if (input == "exit"){
                break;
            }
            
            // Finds command with the same name as the input
            // cmd could be AddHandler, RemHandler, SizeHandler
            // cmd.Handle == "add" handle argument kommando[1] is the value you append to queue
            // otherwise run kommando[0]
            foreach(var cmds in handler) {
                if (kommando != null && kommando[0] == cmds.Name)
                {
                    cmds.Handle(cmds.Name == "add" ? kommando[1] : kommando[0]);
                }
            }
        }
    }
}