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
    class Line
    {
        public int Row { get; set; }
        public int Delay { get; set; }
        public List<TextBlock> Tblocks { get; set; }


        public Line(int Row, List<TextBlock> Tblocks, int Delay)
        {
            this.Row = Row;
            this.Tblocks = Tblocks;
            this.Delay = Delay;
            Task.Factory.StartNew(Go);
        }

        public void Go()
        {
            int tblockCount = Tblocks.Count();
            int[] a = new int[tblockCount];
            for (int i = 0; i< tblockCount; ++i)
            {
                a[i] = i;
            }
            int colorCount = Options.colors.Count();
            while (true)
            {
                for (int i = 0; i < colorCount; ++i)
                {
                    for (int x = 0; x < tblockCount; ++x)
                    {
                        Tblocks[x].Dispatcher.Invoke(new Action(() => {

                            Tblocks[x].Foreground = Options.colors[a[x] % colorCount];


                        }));
                    }
                    
                    

                    Thread.Sleep(Delay);
                }
                for (int b = 0; b < tblockCount; ++b)
                {
                    a[b]++;
                }
            }
        }
    } 
}

