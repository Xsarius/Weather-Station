using System;
using Windows.Devices.I2c;

namespace Sensor_Scrypt
{
    public class Sensor
    {
        // Adress of the sensor
        public int adress;

        // Data outputed by the sensor
        public float data;
        // This device 
        I2cDevice device;

        public async void OpenConnection()
        {
            // this.sensorAdress is the I2C device address
            var settings = new I2cConnectionSettings(this.adress);

            // FastMode = 400KHz
            settings.BusSpeed = I2cBusSpeed.FastMode;

            // Create an I2cDevice with the specified I2C settings
            var controller = await I2cController.GetDefaultAsync();

            // Create an I2cDevice with the specified I2C settings
            device = controller.GetDevice(settings);
        }

        public float DataOutput()
        {
            // Buffer array
            byte[] readBuff = { };

            // Start transmission line with the sensor
            OpenConnection();

            // Read sensor output
            using (device)
            {
                device.Read(readBuff);
            }

            //  BitConverter.ToSingle(byte[], int32) converts byte[] to float[] type
            return BitConverter.ToSingle(readBuff, 0);
        }

    }
}
