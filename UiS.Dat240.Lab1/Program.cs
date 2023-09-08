using UiS.Dat240.Lab1.Commands;
// using UiS.Dat240.Lab1.Queues;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;

Queue<string> q = new Queue<string>();


// Console.WriteLine("Welcome to my program!");
// string totalString = string.Empty;
// while(true) {
//     totalString = Console.ReadLine();
//     string[] values = totalString.Split(" ", 2);
//     if(values[0] == "add") {
//         Console.WriteLine("You wrote: "+values[1]);
//     } else if(values[0] == "rem") {
//         Console.WriteLine("You wrote the remove command");
//     } else if(values[0] == "size") {
//         Console.WriteLine("The size of the queue is: ");
//     } else if(values[0] == "exit") {
//         Console.WriteLine("You wrote the exit command");
//         break;
//     } else {
//         Console.WriteLine("You wrote: "+totalString);
//     }
// }

var serviceProvider = UiS.Dat240.Lab1.TestSubmissions.CreateServiceProvider();
var handlers = serviceProvider.GetServices<ICommandHandler>();
var addHandler = handlers.FirstOrDefault(a => a.Name.Equals("add"));
var remHandler = handlers.FirstOrDefault(a => a.Name.Equals("rem"));
var sizeHandler = handlers.FirstOrDefault(a => a.Name.Equals("size"));

string totalString = string.Empty;
while(true) {
    Console.Write(">");
    totalString = Console.ReadLine();
    var splitted = totalString.Split(' ',2);
    if(addHandler.Name == splitted[0]) {
        if(splitted.Length > 1) {
            addHandler.Handle(splitted[1]);
            Console.WriteLine($"add Handle function was successfully called with {splitted[1]}");
            continue;
        } else {
            Console.WriteLine("No arguments were given to add");
            continue;
        }
    } else if(remHandler.Name == splitted[0]) {
        remHandler.Handle(splitted[0]);
        continue;
    } else if (sizeHandler.Name == splitted[0]) {
        sizeHandler.Handle("lol");
        continue;
    } else if(totalString == "exit") {
        break;
    }
    else {
        Console.WriteLine("Command not found");
    }

    // check all handlers
    // if handler.Name == splitted[0]
        // run the Handle function of that handler
    // if not found print an error that the command was not found

}
