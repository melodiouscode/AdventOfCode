using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal abstract class MyBase : BaseDay
    {
        protected const string TabSpaces = "   ";

        protected IEnumerable<string> InputFile => File.ReadAllLines(InputFilePath);

        public abstract override ValueTask<string> Solve_1();

        public abstract override ValueTask<string> Solve_2();

        protected (IList<int> left, IList<int> right) Int32Columns(bool sorted = false)
        {
            var left = new List<int>();
            var right = new List<int>();

            foreach (string line in InputFile)
            {
                string[] split = line.Split(TabSpaces);

                left.Add(split[0].ToInt32());
                right.Add(split[1].ToInt32());
            }

            if (!sorted)
            {
                return (left, right);
            }

            left.Sort();
            right.Sort();

            return (left, right);
        }

        protected (IList<string> left, IList<string> right) StringColumns(bool sorted = false)
        {
            var left = new List<string>();
            var right = new List<string>();

            foreach (string line in InputFile)
            {
                string[] split = line.Split(TabSpaces);

                left.Add(split[0]);
                right.Add(split[1]);
            }

            if (!sorted)
            {
                return (left, right);
            }

            left.Sort();
            right.Sort();

            return (left, right);
        }
    }
}
