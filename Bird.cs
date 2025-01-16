using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

/*
    Purpose: This class controls everything related to the bird 
*/

namespace FlappyBird
{
    public class Bird
    {
        //Variable Initialization
        public int _playerYPosition = 300;
        private string birdImageLocation = @"C:\Users\1211d\Desktop\Computer Science\Personal Projects\C#\Flappy Bird Clone\FlappyBird\FlappyBird\images\FlappyBird_Bird.png"; //Image for the bird


        public Ellipse Shape { get; private set; }

        public Rectangle birdShape { get; private set; }

        // - - - - - - CONSTRUCTOR - - - - - - 

        public Bird()
        {
            // Initialize the Ellipse representing the bird
            Shape = new Ellipse
            {
                Width = 75,
                Height = 75,
                Fill = new ImageBrush
                {
                    ImageSource = new ImageSourceConverter().ConvertFromString(birdImageLocation) as ImageSource
                },
                
            };
        }

        // - - - - - - FUNCTIONS - - - - - - 
        public void PlayerUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                _playerYPosition += 10;
            }
        }

        
    }
}
