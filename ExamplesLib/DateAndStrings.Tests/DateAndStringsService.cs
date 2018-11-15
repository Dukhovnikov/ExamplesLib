using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesLib
{
    public static class DateAndStringsService
    {
        public static void GroupDateAndStringListQithLinq()
        {
            var dateAndStringList = DateAndStringsService.GerDefaultDateAndStringsList();

            var grouplist = dateAndStringList
                .GroupBy(r => r.DateTime)
                .Select(gr => new
                {
                    Date = gr.Key,
                    Numbers = gr.SelectMany(r => r.Numbers ?? Array.Empty<string>()).Distinct()
                });

            foreach (var item in grouplist)
            {
                Console.WriteLine(item.Date.ToShortDateString());
                Console.WriteLine("\n");
                foreach (var number in item.Numbers)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine("------------------------------------------------------------\n");
            }
        }

        public static void GroupDateAndStringListQithLinqWithRepetitions()
        {
            var dateAndStringList = DateAndStringsService.GerTestDateAndStringsListWithRepetitions();

            var grouplist = dateAndStringList
                .GroupBy(r => r.DateTime)
                .Select(gr => new DateAndStrings()
                {
                    DateTime = gr.Key,
                    Numbers = gr.SelectMany(r => r.Numbers ?? Array.Empty<string>()).Distinct().ToArray<string>()
                })
                .OrderBy(entity => entity.DateTime);


            foreach (var item in grouplist)
            {
                Console.WriteLine(item.DateTime.ToShortDateString());
                Console.WriteLine("\n");
                foreach (var number in item.Numbers)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine("------------------------------------------------------------\n");
            }
        }

        public static void GroupDateAndStringListQithLinqWithRepetitionsAnon()
        {
            var dateAndStringList = DateAndStringsService.GerTestDateAndStringsListWithRepetitions();

            var grouplist = dateAndStringList
                .GroupBy(r => r.DateTime)
                .Select(gr => new
                {
                    Date = gr.Key,
                    Numbers = gr.SelectMany(r => r.Numbers ?? Array.Empty<string>()).Distinct()
                })
                .OrderBy(entity => entity.Date);


            foreach (var item in grouplist)
            {
                Console.WriteLine(item.Date.ToShortDateString());
                Console.WriteLine("\n");
                foreach (var number in item.Numbers)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine("------------------------------------------------------------\n");
            }
        }


        public static List<DateAndStrings> GerDefaultDateAndStringsList()
        {
            var stepTime = DateTime.Now;

            return new List<DateAndStrings>()
            {
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(1),
                   Numbers = new string[]
                   {
                       "1001",
                       "1002",
                       "1003",
                       "1004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(2),
                   Numbers = new string[]
                   {
                       "2001",
                       "2002",
                       "2003",
                       "2004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(3),
                   Numbers = new string[]
                   {
                       "3001",
                       "3002",
                       "3003",
                       "3004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(4),
                   Numbers = new string[]
                   {
                       "4001",
                       "4002",
                       "4003",
                       "4004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(5),
                   Numbers = new string[]
                   {
                       "5001",
                       "5002",
                       "5003",
                       "5004"
                   }
               }
            };
        }

        public static List<DateAndStrings> GerTestDateAndStringsListWithRepetitions()
        {
            var stepTime = DateTime.Now;

            return new List<DateAndStrings>()
            {
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(2),
                   Numbers = new string[]
                   {
                       "1001",
                       "1002",
                       "1003",
                       "1004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(2),
                   Numbers = new string[]
                   {
                       "1001",
                       "1002",
                       "2003",
                       "2004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(1),
                   Numbers = new string[]
                   {
                       "3001",
                       "3002",
                       "3003",
                       "3004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(1),
                   Numbers = new string[]
                   {
                       "3001",
                       "3002",
                       "4003",
                       "4004"
                   }
               },
               new DateAndStrings()
               {
                   DateTime = stepTime.AddDays(3),
                   Numbers = new string[]
                   {
                       "5001",
                       "5002",
                       "5003",
                       "5004"
                   }
               }
            };
        }
    }
}
