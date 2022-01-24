using ConsoleEnhancedLib;
using System;

namespace ExampleConsoleEnhancedLib {
	internal class Program {
		static void Main(string[] args) {

			double x = 0, y = 0;

			Cmd.AddButton("x + y");
			Cmd.AddButton("x - y");
			Cmd.AddButton("x * y");
			Cmd.AddButton("x / y");
			Cmd.AddButton("QUIT");

			while (!Cmd.IsButtonSelected("QUIT")) {

				Cmd.MenuInit();

				if (Cmd.IsAnyButtonSelected() && !Cmd.IsButtonSelected("QUIT")) {

					x = double.Parse(Cmd.Input("x"));
					y = double.Parse(Cmd.Input("y"));
				}

				if (Cmd.IsButtonSelected("x + y")) {

					Cmd.Output("Result is: " + (x + y));
					Cmd.Output("Press any key to continue");
					Console.ReadKey();
				}

				if (Cmd.IsButtonSelected("x - y")) {

					Cmd.Output("Result is: " + (x - y));
					Cmd.Output("Press any key to continue");
					Console.ReadKey();
				}

				if (Cmd.IsButtonSelected("x * y")) {

					Cmd.Output("Result is: " + x * y);
					Cmd.Output("Press any key to continue");
					Console.ReadKey();
				}

				if (Cmd.IsButtonSelected("x / y")) {

					Cmd.Output("Result is: " + x / y);
					Cmd.Output("Press any key to continue");
					Console.ReadKey();
				}
			}

			Cmd.ClearAllButtons();

			Cmd.AddButton("Were the answers correct?\n");
			Cmd.AddButton("Yes");
			Cmd.AddButton("No");

			Cmd.MenuInit();
		}
	}
}
