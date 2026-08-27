using StudentManager;

var service = new StudentService();

// ── Sample data ──────────────────────────────────────────
service.Add(new Student("SE001", "Nguyen Van An", 8.5, "Software Eng"));
service.Add(new Student("SE002", "Tran Thi Binh", 7.2, "Software Eng"));
service.Add(new Student("IT001", "Le Van Chi", 9.1, "IT"));
service.Add(new Student("IT002", "Pham Thi Dung", 6.8, "IT"));
service.Add(new Student("SE003", "Hoang Van Em", 4.5, "Software Eng"));
service.Add(new Student("IT003", "Vo Thi Phuong", 8.9, "IT"));
Console.Clear();

// ── Main menu loop ────────────────────────────────────────
bool running = true;
while (running)
{
    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════╗");
    Console.WriteLine("║   STUDENT MANAGER — Collections  ║");
    Console.WriteLine("╠══════════════════════════════════╣");
    Console.WriteLine("║  1. Add student                  ║");
    Console.WriteLine("║  2. Display all                  ║");
    Console.WriteLine("║  3. Search by name               ║");
    Console.WriteLine("║  4. Highest / Lowest score       ║");
    Console.WriteLine("║  5. Sort list                    ║");
    Console.WriteLine("║  6. Delete student               ║");
    Console.WriteLine("║  7. Filter by score range        ║");
    Console.WriteLine("║  8. Statistics                   ║");
    Console.WriteLine("║  0. Exit                         ║");
    Console.WriteLine("╚══════════════════════════════════╝");
    Console.Write("  Choose option: ");

    string choice = Console.ReadLine()?.Trim() ?? "0";

    Console.WriteLine();
    switch (choice)
    {
        case "1":
            Console.Write("  ID: "); string id = Console.ReadLine();
            Console.Write("  Name: "); string name = Console.ReadLine();
            Console.Write("  Score: "); double score = double.Parse(Console.ReadLine());
            Console.Write("  Major: "); string major = Console.ReadLine();
            service.Add(new Student(id, name, score, major));
            break;

        case "2":
            service.DisplayAll();
            break;

        case "3":
            Console.Write("  Enter name keyword: ");
            service.SearchByName(Console.ReadLine());
            break;

        case "4":
            service.ShowMinMax();
            break;

        case "5":
            Console.Write("  Sort by (name/score): ");
            service.Sort(Console.ReadLine()?.ToLower() ?? "name");
            break;

        case "6":
            Console.Write("  Enter ID to delete: ");
            service.DeleteById(Console.ReadLine());
            break;

        case "7":
            Console.Write("  Score from: "); double lo = double.Parse(Console.ReadLine());
            Console.Write("  Score to: "); double hi = double.Parse(Console.ReadLine());
            service.FilterByScore(lo, hi);
            break;

        case "8":
            service.Statistics();
            break;

        case "0":
            Console.WriteLine("  Goodbye!");
            running = false;
            break;

        default:
            Console.WriteLine("  ✖  Invalid option.");
            break;
    }
}
