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

        // - - - - - CONSTRUCTOR - - - - - 
        public MainWindow()
        {
            InitializeComponent();

            // - - - - - BACKGROUND - - - - - 
            //Creating the Background Grid
            var mainGrid = new Grid();

            //FLOOR
            var floor = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new ImageSourceConverter().ConvertFromString(background1) as ImageSource,
                    Stretch = Stretch.Fill,
                    TileMode = TileMode.Tile,
                }
            };
            Grid.SetZIndex(floor, 3); //END FLOOR

            //TREES
            var trees = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new ImageSourceConverter().ConvertFromString(background2) as ImageSource,
                    Stretch = Stretch.UniformToFill,
                    TileMode = TileMode.Tile,
                }
            };
            Grid.SetZIndex(trees, 2); //END TREES

            //CLOUDS AND BUILDINGS
            var clouds_buildings = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new ImageSourceConverter().ConvertFromString(background3) as ImageSource,
                    Stretch = Stretch.UniformToFill,
                    TileMode = TileMode.Tile,
                }
            };
            Grid.SetZIndex(clouds_buildings, 1); //END CLOUDS AND BUILDINGS

            //SKY
            var sky = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new ImageSourceConverter().ConvertFromString(background4) as ImageSource,
                    Stretch = Stretch.UniformToFill,
                    TileMode = TileMode.Tile,
                }
            };
            Grid.SetZIndex(floor, 0); //END SKY

            //Adding all layers to the Grid
            mainGrid.Children.Add(floor);
            mainGrid.Children.Add(trees);
            mainGrid.Children.Add(clouds_buildings);
            mainGrid.Children.Add(sky);

            // Set the Grid as the content of the Window
            this.Content = mainGrid;

            //Animating the Layers
            animateLayer(floor, 5);
            animateLayer(trees, 7, -0.5);
            animateLayer(clouds_buildings, 10, -0.3);
            animateLayer(sky, 13, -0.1);
            // - - - - - END BACKGROUND - - - - -


            // - - - - - BIRD - - - - - 
            Bird bird = new Bird();

            //Setting the Bird on the Canvas
            Canvas.SetLeft(bird.Shape, 100);
            Canvas.SetBottom(bird.Shape, 400);
            GameCanvas.Children.Add(bird.Shape);
            Grid.SetZIndex(bird.Shape, 100);

            // - - - - - SCORE BOARD - - - - - 
            CounterText.Text = ("Score: " + _counter).ToString();
        }

        //Function to raise the counter
        private void Window_Key_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                _counter++;
                CounterText.Text = ("Score: " + _counter).ToString();
            }
        }//END Window_Key_Down

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
        }
    }
}