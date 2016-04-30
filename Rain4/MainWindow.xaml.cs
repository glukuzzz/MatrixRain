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
using System.Threading;

namespace Rain4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] TaskActive = new int[Options.SizeX];

        Dictionary<Coordinate, TextBlock> textBlocks = new Dictionary<Coordinate, TextBlock>();
        int colorCount;

        List<Line> lines = new List<Line>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MakingColorBase();
            colorCount = Options.colors.Count();

            for (int i = 0; i < Options.SizeX; ++i)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());

            }

            for (int j = 0; j < Options.SizeY; ++j)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int j = 0; j < Options.SizeY; ++j)
            {
                for (int i = 0; i < Options.SizeX; ++i)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.Background = Options.colors.Last();
                    textblock.Text = Options.letter[MyRandom.GenerateRandom(0, Options.letter.Count() - 1)];
                    textblock.FontSize = 500/Options.SizeX;
                    textblock.TextAlignment = TextAlignment.Center;

                    textblock.Foreground = Options.colors.Last();
                    Grid.SetColumn(textblock, i);
                    Grid.SetRow(textblock, j);
                    mainGrid.Children.Add(textblock);
                    textBlocks.Add(new Coordinate(i, j), textblock);
                }
            }
            for (int w = 0; w < Options.SizeX; ++w)
            {
                List<TextBlock> tblocks = new List<TextBlock>();
                for (int w1 = 0; w1 < Options.SizeY; ++w1)
                {
                    tblocks.Add(textBlocks[new Coordinate(w, w1)]);
                }
                
                lines.Add(new Line(w, tblocks, MyRandom.GenerateRandom(10, 50)));
            }

            Task.Factory.StartNew(ChangeText);
            
            

        }

        void MakingColorBase()
        {
            LinearGradientBrush gradient = new LinearGradientBrush();
            gradient.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 255), 0));
            gradient.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 0), 1));
            gradient.GradientStops.Add(new GradientStop(Color.FromRgb(43, 211, 18), 0.5));
            GradientStopCollection gsc = gradient.GradientStops;
            Options.colors.Clear();
            double j = 0;
            int n = Options.SizeY;
            for (int i = 0; i < n + 1; ++i)
            {
                j = Convert.ToDouble(i) / Convert.ToDouble(n);
                Options.colors.Add(new SolidColorBrush(GradientStopCollectionExtensions.GetRelativeColor(gsc, j)));
            }

            for (int i = 0; i <20; ++i)
            {
                Options.colors.Add(Brushes.Black);
            }
        }

        void ChangeText()
        {
            while (true)
            {
                Coordinate coor = new Coordinate(MyRandom.GenerateRandom(0, Options.SizeX - 1), MyRandom.GenerateRandom(0, Options.SizeY - 1));
                Dispatcher.Invoke(new Action(() =>
                {
                    textBlocks[coor].Text = Options.letter[MyRandom.GenerateRandom(0, 9)];
                }));
                Thread.Sleep(5);
            }
        }
    }
}