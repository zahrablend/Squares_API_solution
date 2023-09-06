using DataAccess;

namespace Services
{
    public class PointService
    {
        private readonly PointRepository _pointRepository;
        public PointService(PointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        // Method to clear all points from the database
        public void ClearPoints()
        {
            var points = GetPointsFromDatabase();
            foreach (var point in points)
            {
                _pointRepository.DeletePoint(point);
            }
        }

        // Method to add a point to the database
        public void AddPoint(Point point)
        {
            _pointRepository.AddPoint(point);
        }

        // Method to delete a point from the database based on its x and y values
        public void DeletePoint(int x, int y)
        {
            var pointToDelete = GetPointsFromDatabase().FirstOrDefault(point => 
            point.X == x && point.Y == y);
            if (pointToDelete != null)
            {
                _pointRepository.DeletePoint(pointToDelete);
            }
        }

        public List<Point> GetPoints()
        {
            return _pointRepository.GetPoints().ToList();
        }

        private IEnumerable<Point> GetPointsFromDatabase()
        {
            return _pointRepository.GetPoints();
        }
    }
}