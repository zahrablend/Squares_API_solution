using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SquareService
    {
        private readonly PointService pointService;

        public SquareService(PointService pointService)
        {
            this.pointService = pointService;
        }

        public void FindAndPrintSquares()
        {
            var points = pointService.GetPoints();
            var squares = FindSquares(points);
            foreach (var square in squares)
            {
                Console.WriteLine("Square: ");
                foreach (var point in square)
                {
                    Console.WriteLine("({0};{1})", point.X, point.Y);
                }
            }
        }

        public int CountSquares()
        {
            var points = pointService.GetPoints();
            var squares = FindSquares(points);
            return squares.Count;
        }

        private List<List<PointService.Point>> FindSquares(List<PointService.Point> points)
        {
            var squares = new List<List<PointService.Point>>();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    for (int k = j + 1; k < points.Count; k++)
                    {
                        for (int l = k + 1; l < points.Count; l++)
                        {
                            if (IsSquare(points[i], points[j], points[k], points[l]))
                            {
                                squares.Add(new List<PointService.Point> { points[i], points[j], points[k], points[l] });
                            }
                        }
                    }
                }
            }
            return squares;
        }

        private bool IsSquare(PointService.Point p1, PointService.Point p2, PointService.Point p3, PointService.Point p4)
        {
            // Helper method to check if four given points form a square
            throw new NotImplementedException();
        }
    }
}
