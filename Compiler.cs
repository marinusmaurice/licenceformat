/*
 * Created by Maurice Marinus 
 * Date: 2022 March 30
 * Time: 16:56
 * Licence: Proprietary
 */
using System;
using System.Collections.Generic;

namespace Demo1
{
	/// <summary>
	/// Description of Compiler.
	/// </summary>
	public class Compiler
	{
		public Compiler()
		{
			FileNames = new List<string>();
		}
		
		public List<string> FileNames {get;set;}
		
		public LicenceType LType {get;set;}
		
		public void Compile()
		{
			List<string> inc = new List<string>();
			List<string> excl = new List<string>();
			foreach (string fileName in FileNames) {
				string[] s = System.IO.File.ReadAllLines(fileName);
				if (s.Length > 4 && s[4].Contains(LType.ToString()))
				{
					inc.Add(fileName);
				}
				else
				{
					excl.Add(fileName);
				}
			}
			
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Files included in compilation");
			Console.WriteLine("=============================");
			Console.ResetColor();
			foreach (string fileName in inc) {
				Console.WriteLine(fileName);
			}
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Files excluded from compilation");
			Console.WriteLine("=============================");
			Console.ResetColor();
			foreach (string fileName in excl) {
				Console.WriteLine(fileName);
			}	
			
			Console.WriteLine("\nCompilation complete");
		}
	}
}
