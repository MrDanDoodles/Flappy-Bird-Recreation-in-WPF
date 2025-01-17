using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // - - - - - VARIABLES - - - - - 
        private int _counter = 0;

        //Images: The images are sent back to front. 4 Being Back, 1 being Front
        string background1 = @"C:\Users\1211d\Desktop\Computer Science\Personal Projects\C#\Flappy Bird Clone\FlappyBird\FlappyBird\images\FloorFlappy.png"; //Floor
        string background2 = @"C:\Users\1211d\Desktop\Computer Science\Personal Projects\C#\Flappy Bird Clone\FlappyBird\FlappyBird\images\TreesFlappy.png"; //Trees
        string background3 = @"C:\Users\1211d\Desktop\Computer Science\Personal Projects\C#\Flappy Bird Clone\FlappyBird\FlappyBird\images\Clouds_BuildingsFlappy.png"; //Clouds and Buildings
        string background4 = @"C:\Users\1211d\Desktop\Computer Science\Personal Projects\C#\Flappy Bird Clone\FlappyBird\FlappyBird\images\SkyFlappy.png"; //Sky

        string birdImage = @"C:\Users\1211d\Desktop\Computer Science\Personal Projects\C#\Flappy Bird Clone\FlappyBird\FlappyBird\images\FlappyBird_Bird.png"; //Image for the bird

        // - - - - - MAIN WINDOW - - - - - 
        public MainWindow()
        {
            InitializeComponent();

            // - - - - - BACKGROUND - - - - - 

            //Initializing all Background Objects
            var floor = new Background(background1, 4);             //Floor         
            var trees = new Background(background2, 3);             //Trees
            var clouds_buildings = new Background(background3, 2);  //Clouds and Buildings
            var sky = new Background(background4, 1);               //Sky

            //Adding all layers to the Grid
            mainGrid.Children.Add(floor.Shape);
            mainGrid.Children.Add(trees.Shape);
            mainGrid.Children.Add(clouds_buildings.Shape);
            mainGrid.Children.Add(sky.Shape);

            // Set the Grid as the content of the Window
            this.Content = mainGrid;

            //Animating the Layers
            animateLayer(floor.Shape, 5);
            animateLayer(trees.Shape, 7, -0.5);
            animateLayer(clouds_buildings.Shape, 10, -0.3);
            animateLayer(sky.Shape, 13, -0.1);
            // - - - - - END BACKGROUND - - - - -


            // - - - - - BIRD - - - - - 
            //Constructing and Adding Bird to Game
            Bird bird = new Bird(birdImage);
            GameCanvas.Children.Add(bird.Shape); //Adding Bird to the GameCanvas
            
            //Position:
            Canvas.SetLeft(bird.Shape, 75);                         //X-Position
            Canvas.SetBottom(bird.Shape, bird.startingYPosition);   //Y-Poisition
            bird.birdGravity(bird.Shape, 10, 5);

            //Z Index
            Grid.SetZIndex(GameCanvas, 5);       //GameCanvas is set to front layer

            // - - - - - SCORE BOARD - - - - - 
            CounterText.Text = ("Score: " + _counter).ToString();   //Setting the ScoreBoard's Text
            Grid.SetZIndex(CounterText, 6);                         //CounterText is set to front layer
        }//END MAIN WINDOW

        // - - - - - FUNCTIONS - - - - - 

        //Function to raise the counter
        private void Window_Key_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                _counter++;
                CounterText.Text = ("Score: " + _counter).ToString();
            }
        }//END Window_Key_Down

        //Function to Animate a Background Layer
        private void animateLayer(Rectangle layer, int speed, double offsetX = -1)
        {
            // Ensure the Fill of the layer is an ImageBrush
            if (layer.Fill is ImageBrush brush)
            {
                // Create the animation for the Viewport property
                var rectAnimation = new RectAnimation
                {
                    From = new Rect(0, 0, 1, 1),           // Starting position
                    To = new Rect(offsetX, 0, 1, 1),       // Scroll by offsetX
                    Duration = new Duration(TimeSpan.FromSeconds(speed)), // Animation speed
                    RepeatBehavior = RepeatBehavior.Forever // Loop the animation
                };

                // Apply the animation to the ImageBrush
                brush.BeginAnimation(ImageBrush.ViewportProperty, rectAnimation);
            }
            else
            {
                throw new InvalidOperationException($"The layer's Fill property is not an ImageBrush.");
            }
        }//End animateLayer


    }
}