using Services;

namespace ConsoleInterface
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the PointService class
            PointService pointService = new();
            SquareService squareService = new(pointService);
            JsonService jsonService = new(pointService);
            bool exit = false;

            // Initialize the fileName and filePath variables
            string fileName = "points.json";
            string filePath = JsonService.GetDesktopFilePath(fileName);

            while (!exit)
            {
                // Prompt the user to choose an operation
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Add point");
                Console.WriteLine("2. Delete point");
                Console.WriteLine("3. Save to JSON");
                Console.WriteLine("4. Load from JSON");
                Console.WriteLine("5. Print points");
                Console.WriteLine("6. Find squares");
                Console.WriteLine("7. Count squares");
                Console.WriteLine("8. Exit");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Add a point to the list
                        Console.Write("Enter x: ");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter y: ");
                        int y = Convert.ToInt32(Console.ReadLine());
                        pointService.AddPoint(new Services.PointService.Point(x, y));
                        break;
                    case "2":
                        // Delete a point from the list based on its x and y values
                        Console.Write("Enter x: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter y: ");
                        y = Convert.ToInt32(Console.ReadLine());
                        pointService.DeletePoint(x, y);
                        break;
                    case "3":
                        // Save the list of points to a JSON file
                        jsonService.SavePoints(filePath);
                        break;
                    case "4":
                        // Load the list of points from a JSON file
                        jsonService.LoadPoints(filePath);
                        break;
                    case "5":
                        // Print the list of points to the console
                        List<PointService.Point> points = jsonService.LoadPoints("path/to/your/file.json")!;
                        foreach (PointService.Point point in points)
                        {
                            Console.WriteLine("({0};{1})", point.X, point.Y);
                        }
                        break;
                    case "6":
                        // Find all squares in the list of points and print their coordinates
                        squareService.FindSquares();
                        break;
                    case "7":
                        // Count and print the number of squares in the list of points
                        int count = squareService.CountSquares();
                        Console.WriteLine("{0} squares found", count);
                        break;
                    case "8":
                        // Exit the program
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}