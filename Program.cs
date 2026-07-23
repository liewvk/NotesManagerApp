using System;
using System.IO;

namespace NotesManagerApp
{
    internal class Program
    {
        static string filePath = "notes.txt";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Notes Manager App");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add Note");
                Console.WriteLine("2. View Notes");
                Console.WriteLine("3. Delete Notes");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddNote();
                        break;

                    case "2":
                        ViewNotes();
                        break;

                    case "3":
                        DeleteNotes();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose 1 to 4.");
                        break;
                }
            }
        }

        static void AddNote()
        {
            Console.Write("Enter your note: ");
            string note = Console.ReadLine();

            File.AppendAllText(filePath, note + Environment.NewLine);

            Console.WriteLine("Note saved successfully.");
        }

        static void ViewNotes()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No notes file found.");
                return;
            }

            string[] notes = File.ReadAllLines(filePath);

            if (notes.Length == 0)
            {
                Console.WriteLine("No notes saved.");
                return;
            }

            Console.WriteLine("Saved Notes");
            Console.WriteLine("-----------");

            for (int i = 0; i < notes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {notes[i]}");
            }
        }

        static void DeleteNotes()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("All notes deleted.");
            }
            else
            {
                Console.WriteLine("No notes file to delete.");
            }
        }
    }
}

