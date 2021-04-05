using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class DataBase
    {
        public static IEnumerable<Lecture1> GetLectures()
        {
            return new Lecture1[]
            {
                new Lecture1
                {
                    id = 1,
                    num = "L1",
                },
                new Lecture1
                {
                    id = 2,
                    num = "L2",
                },
                new Lecture1
                {
                    id = 3,
                    num = "L3",
                },
                new Lecture1
                {
                    id = 4,
                    num = "L4",
                },
                new Lecture1
                {
                    id = 5,
                    num = "L5",
                },
                new Lecture1
                {
                    id = 6,
                    num = "L6",
                },
                new Lecture1
                {
                    id = 7,
                    num = "L7",
                },
                new Lecture1
                {
                    id = 8,
                    num = "L8",
                },
                new Lecture1
                {
                    id = 9,
                    num = "L9",
                },
                new Lecture1
                {
                    id = 10,
                    num = "L10",
                },
            };
        } 
    }
}
