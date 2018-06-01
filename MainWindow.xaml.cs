using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2dGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double[,] myCells;
        public MainWindow()
        {
            InitializeComponent();

            myCells = new double[20, 20];
            string temp = "";
            int offset = 0;
            Rectangle[,] myRectangles = new Rectangle[20, 20];
            MessageBox.Show(myCells.GetLength(1).ToString());
            for (int col = 0; col < myCells.GetLength(0); col++) {
                for (int row = 0; row < myCells.GetLength(1); row++) {
                    myRectangles[row, col] = new Rectangle();
                    myRectangles[row, col].Stroke = Brushes.Black;
                    myRectangles[row, col].Fill = Brushes.White;
                    if (this.Width < this.Height)
                    {
                        myRectangles[row, col].Width = this.Width / 20 - offset;
                        myRectangles[row, col].Height = this.Width / 20 - offset;
                    }
                    else {
                        myRectangles[row, col].Width = this.Height / 20 - offset;
                        myRectangles[row, col].Height = this.Height / 20 - offset;
                    }
                    canvas.Children.Add(myRectangles[row, col]);
                    Canvas.SetTop(myRectangles[row, col], row * myRectangles[row, col].Height);
                    Canvas.SetLeft(myRectangles[row, col], col * myRectangles[row, col].Width);
                    myCells[row, col] = 0;
                    temp += myCells[row, col].ToString() + " ";
                    myRectangles[row, col].MouseDown += MainWindow_MouseDown;
                }
                temp += "\n";
            }
            Console.WriteLine(temp);
            myRectangles[0, 0].Fill = Brushes.Red;
            myRectangles[11, 11].Fill = Brushes.Blue;
            myRectangles[15, 7].Fill = Brushes.Green;
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle temp = (Rectangle)sender;
            temp.Fill = Brushes.Black;
            MessageBox.Show(Canvas.GetLeft(temp).ToString()+", "+Canvas.GetTop(temp).ToString());
        }

        
    }
}
