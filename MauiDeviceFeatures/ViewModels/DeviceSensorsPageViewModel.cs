using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiDeviceFeatures.ViewModels
{
    public class DeviceSensorsPageViewModel : ObservableObject
    {
        private const string NotSupportedText = "Not supported";

        private string _accelerometerReading;

        public string AccelerometerReading
        {
            get => _accelerometerReading;
            private set => SetProperty(ref _accelerometerReading, value);
        }

        private string _barometerReading;

        public string BarometerReading
        {
            get => _barometerReading;
            private set => SetProperty(ref _barometerReading, value);
        }

        private string _compassReading;

        public string CompassReading
        {
            get => _compassReading;
            private set => SetProperty(ref _compassReading, value);
        }

        private string _shakeDetected = false.ToString();

        public string ShakeDetected
        {
            get => _shakeDetected;
            private set => SetProperty(ref _shakeDetected, value);
        }

        private string _gyroscopeReading;

        public string GyroscopeReading
        {
            get => _gyroscopeReading;
            private set => SetProperty(ref _gyroscopeReading, value);
        }

        private string _magnetometerReading;

        public string MagnetometerReading
        {
            get => _magnetometerReading;
            private set => SetProperty(ref _magnetometerReading, value);
        }

        private string _orientationReading;

        public string OrientationReading
        {
            get => _orientationReading;
            private set => SetProperty(ref _orientationReading, value);
        }

        public DeviceSensorsPageViewModel()
        {
            if (Accelerometer.Default.IsSupported)
            {
                Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Default.ShakeDetected += Accelerometer_ShakeDetected;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                AccelerometerReading = NotSupportedText;
                ShakeDetected = NotSupportedText;
            }

            if (Barometer.Default.IsSupported)
            {
                Barometer.Default.ReadingChanged += Barometer_ReadingChanged;
                Barometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                BarometerReading = NotSupportedText;
            }

            if (Compass.Default.IsSupported)
            {
                Compass.Default.ReadingChanged += Compass_ReadingChanged;
                Compass.Default.Start(SensorSpeed.UI);
            }
            else
            {
                CompassReading = NotSupportedText;
            }

            if (Gyroscope.Default.IsSupported)
            {
                Gyroscope.Default.ReadingChanged += Gyroscope_ReadingChanged;
                Gyroscope.Default.Start(SensorSpeed.UI);
            }
            else
            {
                GyroscopeReading = NotSupportedText;
            }

            if (Magnetometer.Default.IsSupported)
            {
                Magnetometer.Default.ReadingChanged += Magnetometer_ReadingChanged;
                Magnetometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                MagnetometerReading = NotSupportedText;
            }

            if (OrientationSensor.Default.IsSupported)
            {
                OrientationSensor.Default.ReadingChanged += OrientationSensor_ReadingChanged;
                OrientationSensor.Default.Start(SensorSpeed.UI);
            }
            else
            {
                OrientationReading = NotSupportedText;
            }
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            AccelerometerReading = e.Reading.ToString();
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            ShakeDetected = true.ToString();
        }

        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            BarometerReading = e.Reading.ToString();
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            CompassReading = e.Reading.ToString();
        }

        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            GyroscopeReading = e.Reading.ToString();
        }

        private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            MagnetometerReading = e.Reading.ToString();
        }

        private void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            OrientationReading = e.Reading.ToString();
        }
    }
}
