using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PointRepository
    {
        private readonly PointContext _context;

        public PointRepository(PointContext context)
        {
            _context= context;
        }

        // Add point to database
        public void AddPoint(Point point)
        {
            _context.Points.Add(point);
            _context.SaveChanges();
        }

        // Delete point from database
        public void DeletePoint(Point point)
        {
            if (point != null)
            {
                _context.Points.Remove(point);
                _context.SaveChanges();
            }
        }

        // Get all points from database
        public IEnumerable<Point> GetPoints()
        {
            return _context.Points;
        }
    }
}
