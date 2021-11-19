﻿namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100_000)]
        public int Count { get; set; }

        private List<int> _data;
        private int[] _array;
        private List<long> _data64;
        private long[] _array64;


        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();

            _data = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _data.Add(r.Next());
                _array = _data.ToArray();
            }
        }

        [Benchmark]
        public int MaxUsingEnumeratorList()
        {
            int value;
            using (IEnumerator<int> e = _data.GetEnumerator())
            {
                value = e.Current;
                while (e.MoveNext())
                {
                    int x = e.Current;
                    if (x > value)
                    {
                        value = x;
                    }
                }
            }

            return value;
        }

        [Benchmark(Baseline = true)]
        public int MaxUsingForEachList()
        {
            int value = 0;

            foreach (int x in _data)
            {
                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public int MaxUsingForLoopList()
        {
            int value = 0;

            for (int i = 0; i < _data.Count; i++)
            {
                int x = _data[i];

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public int MaxUsingEnumeratorArray()
        {
            int value = int.MinValue;
            IEnumerator e = _array.GetEnumerator();

            while (e.MoveNext())
            {
                int x = (int)e.Current;

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public int MaxUsingForEachArray()
        {
            int value = 0;

            foreach (int x in _array)
            {
                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public int MaxUsingForLoopArray()
        {
            int value = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                int x = _array[i];

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public long MaxUsingEnumeratorList64()
        {
            long value;
            using (IEnumerator<long> e = _data64.GetEnumerator())
            {
                value = e.Current;
                while (e.MoveNext())
                {
                    long x = e.Current;
                    if (x > value)
                    {
                        value = x;
                    }
                }
            }

            return value;
        }

        [Benchmark]
        public long MaxUsingForEachList64()
        {
            long value = 0;

            foreach (long x in _data64)
            {
                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public long MaxUsingForLoopList64()
        {
            long value = 0;

            for (int i = 0; i < _data64.Count; i++)
            {
                long x = _data64[i];

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public long MaxUsingEnumeratorArray64()
        {
            long value = long.MinValue;
            IEnumerator e = _array64.GetEnumerator();

            while (e.MoveNext())
            {
                long x = (long)e.Current;

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public long MaxUsingForEachArray64()
        {
            long value = 0;

            foreach (long x in _array64)
            {
                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public long MaxUsingForLoopArray64()
        {
            long value = 0;

            for (int i = 0; i < _array64.Length; i++)
            {
                long x = _array64[i];

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }
    }
}
