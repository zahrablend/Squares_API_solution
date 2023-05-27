namespace Services
{
    public class PointService
    {
        // Define a struct to represent a point with x and y coordinates
        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        // A List<Point> to store the points
        private readonly List<Point> points;

        // Constructor to initialize the list of points
        public PointService()
        {
            points = new List<Point>();
        }

        // Method to add a point to the list
        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        // Method to delete a point from the list based on its x and y values
        public void DeletePoint(int x, int y)
        {
            points.RemoveAll(point => point.X == x && point.Y == y);
        }

        public List<Point> GetPoints()
        {
            return points;
        }

        // Method to print the list of points to the console
        public void PrintPoints()
        {
            foreach (Point point in points)
            {
                Console.WriteLine("({0};{1})", point.X, point.Y);
            }
        }
    }
}