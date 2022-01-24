using System;
using System.Collections.Generic;

namespace ConsoleEnhancedLib
{
	public class Cmd
	{	
		// Returns a ConsoleColor object based on a color string, to make color selection in console cleaner
		// Example: GetColor("red") will return ConsoleColor.Red
		protected static ConsoleColor GetColor(string color) {

			ConsoleColor colorObj = ConsoleColor.White;

			switch (color) {

				case "black":
					colorObj = ConsoleColor.Black;
					break;

				case "blue":
					colorObj = ConsoleColor.Blue;
					break;

				case "cyan":
					colorObj = ConsoleColor.Cyan;
					break;

				case "darkblue":
					colorObj = ConsoleColor.DarkBlue;
					break;

				case "darkcyan":
					colorObj = ConsoleColor.DarkCyan;
					break;

				case "darkgray":
					colorObj = ConsoleColor.DarkGray;
					break;

				case "darkgreen":
					colorObj = ConsoleColor.DarkGreen;
					break;

				case "darkmagenta":
					colorObj = ConsoleColor.DarkMagenta;
					break;

				case "darkred":
					colorObj = ConsoleColor.DarkRed;
					break;

				case "darkyellow":
					colorObj = ConsoleColor.DarkYellow;
					break;

				case "gray":
					colorObj = ConsoleColor.Gray;
					break;

				case "green":
					colorObj = ConsoleColor.Green;
					break;

				case "magenta":
					colorObj = ConsoleColor.Magenta;
					break;

				case "red":
					colorObj = ConsoleColor.Red;
					break;

				case "white":
					colorObj = ConsoleColor.White;
					break;

				case "yellow":
					colorObj = ConsoleColor.Yellow;
					break;
			}

			return colorObj;
		}
		
		// A styled Console.ReadLine()
		public static string Input(string prompt = "", string prompt_separator = ": ", string prompt_color_str = "cyan", string input_color_str = "red") {

			ConsoleColor prompt_color = GetColor(prompt_color_str);
			ConsoleColor input_color = GetColor(input_color_str);

			Console.ForegroundColor = prompt_color;
			Console.Write(prompt + prompt_separator);
			Console.ForegroundColor = input_color;

			string input = Console.ReadLine();

			Console.ForegroundColor = ConsoleColor.White;

			return input;
		}

		// A styled Console.WriteLine() or Console.Write() (based on newline variable)
		// NOTE: Does not accept formatted output or placeholders
		public static void Output(dynamic text = null, bool newline = true, string color_str = "yellow") {

			ConsoleColor color = GetColor(color_str);

			Console.ForegroundColor = color;

			if (newline) {
				Console.WriteLine(text);
			}
			else {
				Console.Write(text);
			}

			Console.ForegroundColor = ConsoleColor.White;
		}

		protected static ConsoleKey key_press;
		protected static List<string> button_list = new List<string>();
		protected static int selected = 0;

		// Adds option to the console menu
		public static void AddButton(string button) {
			button_list.Add(button);
		}

		protected static void UpdateInterface(string foreground_color_selected_str, string background_color_selected_str, string foreground_color_str, string background_color_str) {        
			
			ConsoleColor background_color_selected = GetColor(background_color_selected_str);
			ConsoleColor foreground_color_selected = GetColor(foreground_color_selected_str);

			ConsoleColor background_color = GetColor(background_color_str);
			ConsoleColor foreground_color = GetColor(foreground_color_str);

			Console.Clear();

			for (int i = 0; i < button_list.Count; i++) {
				
				if (i == selected) {
					Console.ForegroundColor = foreground_color_selected;
					Console.BackgroundColor = background_color_selected;

					Console.WriteLine(button_list[i]);

					Console.ResetColor();
				}
				else {
					Console.ForegroundColor = foreground_color;
					Console.BackgroundColor = background_color; 

					Console.WriteLine(button_list[i]);
				}

			}
		}

		protected static void KeyInput() {     

			key_press = Console.ReadKey().Key;

			if (key_press == ConsoleKey.UpArrow) {
				if (selected > 0) {
					selected -= 1;
				}

			}

			if (key_press == ConsoleKey.DownArrow) {
				if (selected < button_list.Count) {
					selected += 1;
				}

			}


			if (selected >= button_list.Count) {
				selected = button_list.Count - 1;
			}
		}

		// Check if specific button is selected
		public static bool IsButtonSelected(string selected_button) {       
			if (button_list.IndexOf(selected_button) == selected && key_press == ConsoleKey.Enter) {
				return true;
			}
			else {
				return false;
			}

		}

		// Check if ANY button is selected
		public static bool IsAnyButtonSelected() {        
			if (key_press == ConsoleKey.Enter) {
				return true;
			}
			else {
				return false;
			}
		}
		
		// Initiates the menu
		// Runs until any button on the menu is selected by the user
		public static void MenuInit(string foreground_color_selected = "black", string background_color_selected = "white", string foreground_color = "white", string background_color = "black") {

			key_press = ConsoleKey.NoName;

			while (!IsAnyButtonSelected()) {
				
				UpdateInterface(foreground_color_selected, background_color_selected, foreground_color, background_color);
				KeyInput();
			}

			Console.Clear();
		}

		// Remove all buttons from console menu
		public static void ClearAllButtons() {
			selected = 0;
			button_list.Clear();
		}
	}
}
