using System;
using System.Diagnostics;

class Demo
{
	private Stopwatch sw = new Stopwatch();
	private double lastFrame;

	private double deltaTime()
	{
		 TimeSpan ts = this.sw.Elapsed;
		 double firstFrame = ts.TotalMilliseconds;
            
		 double dt = firstFrame - lastFrame;
           
		 this.lastFrame = ts.TotalMilliseconds;

		 return dt;
	}

	public void run()
  {
		this.sw.Start();
		
        double acc = 0.0;
		List<string> statementList = new List<string>();

		Console.WriteLine("Go!");
		Console.Write(">");

		while (acc <= 10000)
		{
			acc += this.deltaTime();
			if (!Console.KeyAvailable)
			{
				continue;
			}
			ConsoleKeyInfo key = Console.ReadKey();
			if (key.Key == ConsoleKey.Enter)
			{
				Console.WriteLine("");
				statementList.Add("\n");
				Console.Write(">");

			}
			else
			{
				statementList.Add(key.KeyChar.ToString());
			}
		}
	
		Console.WriteLine("\nTime's up!");
		Console.WriteLine("");

		statementList.Add("\n");

		int lineCount = statementList.Count(line => line == "\n");

		string statementListStr = String.Join<string>("", statementList);
		Console.WriteLine($"Here's what you typed: {statementListStr}");
		Console.WriteLine($"You listed {lineCount} lines\n");


  }
}

static class Program
{
	static void Main(string[] args)
  {
    Demo demo = new Demo();
		demo.run();
  }
}
