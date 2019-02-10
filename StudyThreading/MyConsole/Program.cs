using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ThreadingLib.Model;
using ThreadingLib.Service;

namespace MyConsole
{
    class Program
    {
        static Working service;
        static CancellationTokenSource _cts;
        static FindYourGuid model;

        static void Main(string[] args)
        {
            service = new Working();
            _cts = new CancellationTokenSource();
            model = new FindYourGuid('0', 12, 10000);


            //Example_001(model);
            //Example_002(model, _cts.Token);
            //Example_003(model, _cts.Token);
            Example_004(model, _cts.Token);
            

            Console.WriteLine("\n\n The Main is finished...");
            Console.ReadKey();
        }



        static void Example_001(FindYourGuid findYourGuid)
        {
            string result = service.ToDo(findYourGuid);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        static async void Example_002(FindYourGuid findYourGuid, CancellationToken ct)
        {
            string result = await Task.Factory.StartNew(() => 
            {
                return service.ToDo(model, ct);
            }, ct);

            Console.WriteLine(result);
        }

        static void Example_003(FindYourGuid findYourGuid, CancellationToken ct)
        {
            //somente para contar o tempo gasto entre todas as tasks;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var newTask = Task.Factory.StartNew(() =>
                {
                    string result = service.ToDo(model, ct);
                    Console.WriteLine(result);
                }, ct);

                tasks.Add(newTask);
            }

            Task.WaitAll(tasks.ToArray());

            stopWatch.Stop();

            Console.WriteLine($"\n\n\nAll Tasks is finished! Elapsed Time: {stopWatch.Elapsed}\n\n");
        }

        static void Example_004(FindYourGuid findYourGuid, CancellationToken ct)
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var newTask = Task.Factory.StartNew(() =>
                {
                    string result = service.ToDo(model, ct);
                    Console.WriteLine(result);
                }, ct);

                tasks.Add(newTask);
            }

            //Iniciar todas as tarefas e seguir a diante!
            Task.WhenAll(tasks.ToArray());

            //cancelar após 9 segundos;
            _cts.CancelAfter(9000);
        }
    }
}
