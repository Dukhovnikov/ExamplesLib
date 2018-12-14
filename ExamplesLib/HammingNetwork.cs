using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesLib
{
    public static class HammingNetwork
    {
        public static double[,] ComputeMatrixOfLinks()
        {
            double[,] matrixofLinks = new double[25, 4];

            for (int i = 0; i < matrixofLinks.GetLength(0); i++)
            {
                matrixofLinks[i, 0] = letterA[i] / 2;
                matrixofLinks[i, 1] = letterB[i] / 2;
                matrixofLinks[i, 2] = letterD[i] / 2;
                matrixofLinks[i, 3] = letterN[i] / 2;
            }

            return matrixofLinks;
        }

        static int[] letterA = new int[25]
        {
                -1, -1,  1, -1, -1,
                -1,  1, -1,  1, -1,
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                -1,  1, -1,  1, -1
        };

        static int[] letterB = new int[25]
        {
                -1, 1,  1,  1, -1,
                -1 ,1, -1, -1, -1,
                -1, 1,  1,  1, -1,
                -1, 1, -1,  1, -1,
                -1, 1,  1,  1, -1
        };

        static int[] letterD = new int[25]
        {
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                 1,  1,  1,  1,  1,
                 1, -1, -1, -1,  1,
                 1, -1, -1, -1,  1
        };
        static int[] letterN = new int[25]
        {
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
        };

        static int[] letterForTest = new int[25]
        {
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
        };

        public static double[] Run()
        {
            var m = 25;
            var k1 = 0.1;
            var Un = 30;
            var eps = 0.25;

            var A = letterA;
            var B = letterB;
            var D = letterD;
            var N = letterN;

            int[] testData = letterForTest;
            double[] arrayUZ = new double[4];
            double[,] matrixOfLinks = ComputeMatrixOfLinks();

            for (int i = 0; i < arrayUZ.Length; i++)
            {
                arrayUZ[i] = m / 2;
            }

            // Рассчитываем входной сигнал каждого Z-нейрона по формуле (7)
            for (int i = 0; i < testData.Length; i++)
            {
                arrayUZ[0] += matrixOfLinks[i, 0] * testData[i];
                arrayUZ[1] += matrixOfLinks[i, 1] * testData[i];
                arrayUZ[2] += matrixOfLinks[i, 2] * testData[i];
                arrayUZ[3] += matrixOfLinks[i, 3] * testData[i];
            }

            // Рассчитываем выходной сигнал каждого Z-нейрона по формуле (6)
            for (int i = 0; i < arrayUZ.Length; i++)
            {
                var Uvh = arrayUZ[i];
                if (Uvh < 0)
                {
                    arrayUZ[i] = 0;
                }

                if (0 <= Uvh && Uvh <= Un)
                {
                    arrayUZ[i] = k1 * arrayUZ[i];
                }

                if (Uvh > Un)
                {
                    arrayUZ[i] = Un;
                }
            }

            double[] resultArray = new double[4];
            double lastSumm = 1;
            int k = 0;
            while (lastSumm != resultArray.Sum() && k < 10)
            {
                lastSumm = resultArray.Sum();

                for (int i = 0; i < resultArray.Length; i++)
                {
                    var summ = 0.0;
                    for (int j = 0; j < arrayUZ.Length; j++)
                    {
                        if (j != i)
                        {
                            summ += arrayUZ[j];
                        }
                    }
                    resultArray[i] = arrayUZ[i] - eps * summ;
                }

                k++;
            }

            for (int i = 0; i < resultArray.Length; i++)
            {
                if (resultArray[i] > 0)
                {
                    resultArray[i] = 1;
                }
                else
                {
                    resultArray[i] = 0;
                }
            }

            return resultArray;
        }

    }
}
