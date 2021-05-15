using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
           // solution(15958);
            var watch = new Stopwatch();
            watch.Start();
            //
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
    
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("\neggs are ready");
                    Console.WriteLine($" ElapsedMilliseconds : {watch.ElapsedMilliseconds}ms");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("\nbacon is ready");
                    Console.WriteLine($" ElapsedMilliseconds : {watch.ElapsedMilliseconds}ms");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("\ntoast is ready");
                    Console.WriteLine($" ElapsedMilliseconds : {watch.ElapsedMilliseconds}ms");
                }
                breakfastTasks.Remove(finishedTask);
            }
            Console.WriteLine($" ElapsedMilliseconds : {watch.ElapsedMilliseconds}ms");

            Console.WriteLine($" .NET count : {await GetDotNetCount()}");
            
            Console.WriteLine($" ElapsedMilliseconds : {watch.ElapsedMilliseconds}ms");

            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //Console.WriteLine("1");
            //Egg eggs = await FryEggsAsync(2);
            //Console.WriteLine("eggs are ready");
            //Console.WriteLine("2");
            //Bacon bacon = await FryBaconAsync(3);
            //Console.WriteLine("bacon is ready");
            //Console.WriteLine("3");
            //Toast toast = await ToastBreadAsync(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Console.WriteLine("4");
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            //Console.WriteLine("Breakfast is ready!");
            //Console.WriteLine("5");
        }
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<int> GetDotNetCount()
        {
            // Suspends GetDotNetCount() to allow the caller (the web server)
            // to accept another request, rather than blocking on this one.
            var html = await HttpClient.GetStringAsync("https://dotnetfoundation.org");

            return Regex.Matches(html, @"\.NET").Count;
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);

            //Console.WriteLine("Fire! Toast is ruined!");
            //throw new InvalidOperationException("The toaster is on fire");
            //await Task.Delay(1000);

            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
        public static int solution(int N) {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var NumToString = N.ToString();
            List<int> index = new List<int>();
            List<string> sAfterRemove = new List<string>();
            List<int> nAfterRemove = new List<int>();
            for(int i = 0; i < NumToString.Length; i++){
                if(NumToString[i]=='5'){
                    index.Add(i);
                }

            }
        
            //adding values to compare later which is larger 
            for(int i = 0; i < index.Count; i++){
                sAfterRemove.Add(NumToString.Remove(index[i],1));
            }
       
            foreach(var x in sAfterRemove){
                nAfterRemove.Add(int.Parse(x));
            }
         
            int finalNum = 0;
            Console.WriteLine(" here is index "+nAfterRemove.Count);

            for(int i = 0; i < nAfterRemove.Count; i++){
                Console.WriteLine(" here is i "+i);

            
                Console.WriteLine(" here is num "+nAfterRemove[i]);
                Console.WriteLine(" here is finalNum "+finalNum);

                if(i+1==nAfterRemove.Count){
                    if(finalNum <nAfterRemove[i]){
                        finalNum = nAfterRemove[i];
                        Console.WriteLine(" here is finalNum  again"+finalNum);
                    }
                    break;
                };
                finalNum = nAfterRemove[i ];
                if(finalNum <nAfterRemove[i+1]){
                    finalNum = nAfterRemove[i+1];
                }
                Console.WriteLine(" here is finalNum  again"+finalNum);
            }

            return finalNum ;
        }

    }
   
    

    internal class Juice
    {
    }

    internal class Toast
    {
    }

    internal class Bacon
    {
    }

    internal class Egg
    {
    }

    internal class Coffee
    {
    }
}
