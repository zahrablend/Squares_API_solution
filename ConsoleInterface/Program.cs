using Services;

namespace ConsoleInterface
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the PointService class
            PointService pointService = new();
            JsonService jsonService = new(pointService);
            SquareService squareService = new();
            bool exit = false;

            // Initialize the fileName and filePath variables
            string fileName = "points.json";
            string filePath = JsonService.GetDesktopFilePath(fileName);

            // Create an instance of the UserInputHandler class
            UserInputHandler userInputHandler = new();

            // Create an instance of the ProgramFlowManager class
            ProgramFlowManager programFlowManager = new(pointService, jsonService, squareService);

            while (!exit)
            {
                // Prompt the user to choose an operation
                userInputHandler.DisplayMenu();

                // Get user input
                string? input = userInputHandler.GetUserInput();

                // Delegate responsibility to the ProgramFlowManager class
                exit = programFlowManager.HandleOperation(input, filePath);
            }
        }
    }

    internal class UserInputHandler
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Add point");
            Console.WriteLine("2. Delete point");
            Console.WriteLine("3. Save to JSON");
            Console.WriteLine("4. Load from JSON");
            Console.WriteLine("5. Print points");
            Console.WriteLine("6. Find squares");
            Console.WriteLine("7. Count squares");
            Console.WriteLine("8. Exit");
        }

        public string? GetUserInput()
        {
            return Console.ReadLine();
        }
    }

    internal class ProgramFlowManager
    {
        private readonly PointService _pointService;
        private readonly JsonService _jsonService;
        private readonly SquareService _squareService;

        public ProgramFlowManager(PointService pointService, JsonService jsonService, SquareService squareService)
        {
            _pointService = pointService;
            _jsonService = jsonService;
            _squareService = squareService;
        }

        public bool HandleOperation(string? input, string filePath)
        {
            bool exit = false;

            switch (input)
            {
                case "1":
                    // Add a point to the list
                    Console.Write("Enter x: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter y: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    _pointService.AddPoint(new Services.PointService.Point(x, y));
                    break;
                case "2":
                    // Delete a point from the list based on its x and y values
                    Console.Write("Enter x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    _pointService.DeletePoint(x, y);
                    break;
                case "3":
                    // Save the list of points to a JSON file
                    _jsonService.SavePoints(filePath);
                    break;
                case "4":
                    // Load the list of points from a JSON file
                    _jsonService.LoadPoints(filePath);
                    break;
                case "5":
                    // Print the list of points to the console
                    List<PointService.Point> points = _pointService.GetPoints();
                    foreach (PointService.Point point in points)
                    {
                        Console.WriteLine("({0};{1})", point.X, point.Y);
                    }
                    break;
                case "6":
                    // Find all squares in the list of points and print their coordinates
                    List<PointService.Point[]> squares = _squareService.FindSquares(_pointService.GetPoints());
                    var uniqueSquares = new HashSet<string>();
                    foreach (var square in squares)
                    {
                        var orderedSquare = square.OrderBy(p => p.X).ThenBy(p => p.Y).ToArray();
                        var squareString = $"({orderedSquare[0].X},{orderedSquare[0].Y}),({orderedSquare[1].X},{orderedSquare[1].Y}),({orderedSquare[2].X},{orderedSquare[2].Y}),({orderedSquare[3].X},{orderedSquare[3].Y})";
                        if (!uniqueSquares.Contains(squareString))
                        {
                            uniqueSquares.Add(squareString);
                            Console.WriteLine(squareString);
                        }
                    }
                    break;

                case "7":
                    // Count and print the number of squares in the list of points
                    int countSquares = _squareService.CountSquares(_pointService.GetPoints());
                    Console.WriteLine(countSquares);

                    break;

                case "8":
                    // Exit the program
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            return exit;
        }
    }
}



