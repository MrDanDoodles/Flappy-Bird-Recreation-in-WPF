using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

/*
    Purpose: This class controls everything related to the bird 
*/

namespace FlappyBird
{
    public class Bird
    {
        //Variable Initialization
        public Rectangle Shape {  get; private set; }
        public double startingYPosition = 300;

        //Constructor
        public Bird(string imageAddress)
        {
            // Initialize the Ellipse representing the bird
            Shape = new Rectangle
            {
                Width = 75,
                Height = 75,
                Fill = new ImageBrush
                {
                    ImageSource = new ImageSourceConverter().ConvertFromString(imageAddress) as ImageSource
                },
            };
            
        }

        // - - - - - FUNCTIONS - - - - - 
        public void birdGravity(Rectangle player, int speed, double offsetY = 2)
        {
            //Ensure that the player has a fill
            if (player.Fill is ImageBrush brush)
            {
                //Creating Animation
                var birdAnimation = new RectAnimation
                {
                    From = new Rect(0, 0, 1, 1),           // Starting position
                    To = new Rect(0, offsetY, 1, 1),       // Scroll by offsetY
                    Duration = new Duration(TimeSpan.FromSeconds(speed)), // Animation speed
                };
                // Apply the animation to the ImageBrush
                brush.BeginAnimation(ImageBrush.ViewportProperty, birdAnimation);
            }
        }
    }
}
