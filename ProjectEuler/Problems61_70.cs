using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public partial class Problems
    {
        public static long Problem67()
        {
            return SumFunctions.ComputeMaximumPath(FileHelpers.ReadNumberSequencePerLine(@"files\Problem67.txt"));
        }
    }
}
