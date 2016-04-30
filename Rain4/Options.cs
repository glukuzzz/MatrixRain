using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Rain4
{
    static class Options
    {
        public static string[] letter = new string[] { "ß", "Ѡ", "ȸ", "Ȣ", "Ʊ", "Ǽ", "Ʃ", "Œ", "ϡ", "ϗ" };


        public static int SizeX { get; set; } = 10;
        public static int SizeY { get; set; } = 10;

        public static List<SolidColorBrush> colors = new List<SolidColorBrush>();
    }
}
