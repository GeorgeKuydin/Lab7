using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Car
    {
        public int Speed { get; set; }
        public int Position { get; set; }
        public string Type { get; set; }
        public PictureBox Image { get; set; }

        // constructor
        public Car(int speed, int position, string type, PictureBox image)
        {
            Speed = speed;
            Position = position;
            Type = type;
            Image = image;
        }

        // method to update the position of the car based on its speed
        public void Move()
        {
            Position += Speed;
        }

        // method to update the position of the car's image on the form
        public void UpdateImagePosition()
        {
            Image.Left = Position;
        }
    }
    public class Highway
    {
        private static readonly Highway _instance = new Highway();
        public static Highway Instance => _instance;

        private readonly List<Car> _cars = new List<Car>();
        private readonly PictureBox _highwayImage;

        // constructor
        private Highway()
        {
            // initialize the PictureBox control representing the highway
            _highwayImage = new PictureBox()
            {
                Width = 800,
                Height = 200,
                Image = Properties.Resources.car,
            };
        }

        // add a car to the highway
        public void AddCar(Car car)
        {
            _cars.Add(car);
            // add the car's image to the highway PictureBox control
            _highwayImage.Controls.Add(car.Image);
        }

        // simulate the movement of cars on the highway
        public void Simulate()
        {
            while (true)
            {
                // update the position of each car and its image
                foreach (Car car in _cars)
                {
                    car.Move();
                    car.UpdateImagePosition();
                }

                // sleep for some time to simulate real-time movement
                Thread.Sleep(1000);

                // refresh the highway PictureBox control
                _highwayImage.Refresh();
            }
        }
        public PictureBox GetHighwayImage()
        {
            return _highwayImage;
        }

    }
}
