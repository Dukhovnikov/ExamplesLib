using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kohonen
{
    public class Symbols
    {
        public static double[,] symbols = new double[5, 25]
        {
            {
                -1, -1,  1, -1, -1,
                -1,  1, -1,  1, -1,
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                -1,  1, -1,  1, -1
        },
            {
                -1, 1,  1,  1, -1,
                -1 ,1, -1, -1, -1,
                -1, 1,  1,  1, -1,
                -1, 1, -1,  1, -1,
                -1, 1,  1,  1, -1
        },
            {
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                 1,  1,  1,  1,  1,
                 1, -1, -1, -1,  1,
                 1, -1, -1, -1,  1
        },
            {
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
        },
            {
                -1, 1, 1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, 1, 1, -1,
        },
        };
        public static double[,] getSymbols()
        {
            return symbols;
        }
    }
}
