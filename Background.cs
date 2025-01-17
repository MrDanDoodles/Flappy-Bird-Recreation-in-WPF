using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

/*
    Purpose: This class will simplify the background making process.
        It will allow the user to quickly create parts of the background using images, tiling, etc.
*/

namespace FlappyBird
{
    internal class Background
    {
        //Variables
        public Rectangle Shape { get; private set; }    //Creating the Shape Object and Attribute of Background
        private const int column_and_row_span = 5;            //Never Change, this is the row and column span

        //Constructor
        public Background(string imageAddress, int backgroundLayerNumber)
        {
            Shape = new Rectangle
            {
                Fill = new ImageBrush //This is what determines what the shape looks like
                {
                    ImageSource = new ImageSourceConverter().ConvertFromString(imageAddress) as ImageSource,
                    Stretch = Stretch.UniformToFill,
                    TileMode = TileMode.Tile,
                }
            };

            //Grid Settings
            Grid.SetZIndex(this.Shape, backgroundLayerNumber);   //Setting which layer the object will be in
            Grid.SetColumnSpan(this.Shape, column_and_row_span); //Column Span
            Grid.SetRowSpan(this.Shape, column_and_row_span);    //Row Span
        }

    }
}
