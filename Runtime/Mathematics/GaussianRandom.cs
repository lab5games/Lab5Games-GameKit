using System;
using Mathf = UnityEngine.Mathf;

namespace Lab5Games.Mathematics
{
    // https://www.jianshu.com/p/d683ee23362e

    public static class GaussianRandom 
    {
        static Random m_Rnd = new Random(m_Seed);

        static int m_Seed = 0;

        public static int seed => m_Seed;

        public static void Init(int seed)
        {
            m_Seed = seed;
            m_Rnd = new Random(m_Seed);
        }

        public static float Next(float mean, float dev, float min, float max)
        {
            float x;
            do
            {
                x = Next(mean, dev);
            } while (x < min || x > max);
            return x;
        }

        public static float Next(float mean, float dev)
        {
            return mean + Next() * dev;
        }

        public static float Next()
        {
            float v1, v2, s;
            do
            {
                v1 = 2.0f * (float)m_Rnd.NextDouble() - 1.0f;
                v2 = 2.0f * (float)m_Rnd.NextDouble() - 1.0f;
                s = v1 * v1 + v2 * v2;
            } while (s >= 1.0f || s == 0f);
            s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
            return v1 * s;
        }
    }
}
