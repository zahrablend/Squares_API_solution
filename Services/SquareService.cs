using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SquareService
    {
        // Method to find all squares in the list of points and return a list of squares
        public List<PointService.Point[]> FindSquares(List<PointService.Point> points)
        {
            var squares = new List<PointService.Point[]>();
            for (int i = 0; i < points.Count; i++)
                for (int j = i + 1; j < points.Count; j++)
                    for (int k = j + 1; k < points.Count; k++)
                        for (int l = k + 1; l < points.Count; l++)
                        {
                            PointService.Point[] square = new PointService.Point[] { points[i], points[j], points[k], points[l] };
                            if (IsSquare(square))
                            {
                                squares.Add(square);
                            }
                        }
            return squares;
        }

        // Method to count the number of squares in the list of points
        public int CountSquares(List<PointService.Point> points)
        {
            int count = 0;
            for (int i = 0; i < points.Count; i++)
                for (int j = i + 1; j < points.Count; j++)
                    for (int k = j + 1; k < points.Count; k++)
                        for (int l = k + 1; l < points.Count; l++)
                        {
                            PointService.Point[] square = new PointService.Point[] { points[i], points[j], points[k], points[l] };
                            if (IsSquare(square))
                                count++;
                        }
            return count;
        }

        // Helper method to check if four given points form a square
        private static bool IsSquare(PointService.Point[] square)
        {
            int[] distances = new int[6];
            distances[0] = DistanceSquared(square[0], square[1]);
            distances[1] = DistanceSquared(square[0], square[2]);
            distances[2] = DistanceSquared(square[0], square[3]);
            distances[3] = DistanceSquared(square[1], square[2]);
            distances[4] = DistanceSquared(square[1], square[3]);
            distances[5] = DistanceSquared(square[2], square[3]);
            Array.Sort(distances);
            return distances[0] > 0 && distances[0] == distances[1] && distances[1] == distances[2] && distances[2] == distances[3] && distances[4] == distances[5];
        }

        // Helper method to calculate the squared distance between two given points
        private static int DistanceSquared(PointService.Point p1, PointService.Point p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
        }
    }
}
