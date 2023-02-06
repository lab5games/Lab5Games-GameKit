using System;

namespace Lab5Games
{
    public class RandomTable
    {
        private Random m_Rnd;
        
        public int seed { get; private set; }

        public int size { get; private set; }

        public int state { get; private set; }

        public float[] table { get; private set; }

        public RandomTable(int seed, int size, int state)
        {
            this.state = seed;
            this.size = size;
            this.state = state;

            m_Rnd = new Random(seed);
            table = CreateTable(size);
        }

        public RandomTable(int seed) : this(seed, 256, 0)
        {
        }

        public RandomTable(int seed, int size) : this(seed, size, 0)
        {
        }

        float[] CreateTable(int size)
        {
            const int PRECISION = 100000;

            float[] table = new float[size];

            for(int i=0; i<size; i++)
            {
                table[i] = m_Rnd.Next(0, PRECISION) / (float)PRECISION;
            }

            return table;
        }

        public float Next()
        {
            if (state == size)
                state = 0;

            return table[state++];
        }
    }
}
