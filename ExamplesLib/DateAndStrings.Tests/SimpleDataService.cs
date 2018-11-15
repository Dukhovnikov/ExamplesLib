using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesLib
{
    public static class SimpleDataService
    {
        public static List<SimpleData> GerDefaultSimpleDataList()
        {
            var stepTime = DateTime.Now;

            return new List<SimpleData>()
            {
                new SimpleData() {Date = stepTime.AddMinutes(4), Id = 4},
                new SimpleData() {Date = stepTime.AddMinutes(8), Id = 8},
                new SimpleData() {Date = stepTime, Id = 0},
                new SimpleData() {Date = stepTime.AddMinutes(9), Id = 9},
                new SimpleData() {Date = stepTime.AddMinutes(6), Id = 6},
                new SimpleData() {Date = stepTime.AddMinutes(3), Id = 3},
                new SimpleData() {Date = stepTime.AddMinutes(3), Id = 3},
                new SimpleData() {Date = stepTime.AddMinutes(3), Id = 3},
                new SimpleData() {Date = stepTime.AddMinutes(1), Id = 1},
                new SimpleData() {Date = stepTime.AddMinutes(5), Id = 5},
                new SimpleData() {Date = stepTime.AddMinutes(2), Id = 2},
                new SimpleData() {Date = stepTime.AddMinutes(7), Id = 7},
            };
        }
    }
}
