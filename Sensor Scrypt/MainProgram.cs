using System.IO;

namespace Sensor_Scrypt
{
    class MainProgram
    {

        static void Main(string[] args)
        {
            // Sensor declarations

            Sensor thermometer = new Sensor();
            thermometer.adress = 1; // Sensor adress, specified for every sensor in datasheet(hex)

            /*
            Sensor sensor2 = new Sensor();
            Sensor sensor3 = new Sensor();
            .
            .
            .
            */

            Sensor[] devices = { thermometer /*, sensor 1, sensor 2, sensor 3, etc.*/ }; //Type in all sensors

            string filePath = @"C:\\\Downloads\test1.txt";

            StreamWriter FileStream = File.CreateText(filePath); // Create/open file in file path

            foreach (var sensor in devices)
            {
                FileStream.Write(sensor.DataOutput());  // Writing data to file
            }

        }

    }
}
