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

        public Ellipse Shape { get; private set; }

        // - - - - - - CONSTRUCTOR - - - - - - 

        public Bird()
        {
            // Initialize the Ellipse representing the bird
            Shape = new Ellipse
            {
                Width = 50,
                Height = 50,
                Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)), // Red fill
                Stroke = Brushes.Black,
                StrokeThickness = 1
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
