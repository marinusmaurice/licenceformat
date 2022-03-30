/*
 * Created by Maurice Marinus 
 * Date: 2022 March 30
 * Time: 16:52
 * Licence: Proprietary
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Demo1
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Demo of idea I had long ago that licence data in source code should have a set format. So one could do the following..\n");
			Compiler compiler = new Compiler();
						
			string s = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);			 
			s = s+"\\..\\..\\";
		 
			Uri uri = new Uri(s);
			Console.WriteLine("Searching path: " +uri.LocalPath);
			DirectoryInfo di = new DirectoryInfo(uri.LocalPath);
			FileInfo[] files = di.GetFiles("*.cs");
			
			Console.WriteLine("\nFound files:");
			Console.WriteLine("============");
			foreach (FileInfo fileInfo in files) {				
				Console.WriteLine(fileInfo.FullName);
				compiler.FileNames.Add(fileInfo.FullName);
			}
			
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\nSetting licence to only include: " +LicenceType.Type1.ToString());
			Console.ResetColor();
			compiler.LType = LicenceType.Type1;
			compiler.Compile();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}