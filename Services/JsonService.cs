using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JsonService
    {
        private readonly PointService pointService;

        public JsonService(PointService pointService)
        {
            this.pointService = pointService;
        }

        public void SavePoints(string filePath)
        {
            List<PointService.Point> points = pointService.GetPoints();
            string jsonString = JsonSerializer.Serialize(points);
            File.WriteAllText(filePath, jsonString);
        }

        public List<PointService.Point>? LoadPoints(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            List<PointService.Point>? points = JsonSerializer.Deserialize<List<PointService.Point>>(jsonString);
            if (points != null)
            {
                foreach (PointService.Point point in points)
                {
                    pointService.AddPoint(point);
                }
            }

            return points;
        }

        public static string GetDesktopFilePath(string fileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return Path.Combine(desktopPath, fileName);
        }


    }
}
