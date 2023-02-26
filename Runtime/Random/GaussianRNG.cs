using UnityEngine;

namespace Lab5Games
{
    public static class GaussianRNG
    {
        public static float Next(float mean, float dev, float min, float max)
        {
            float x;

            do
            {
                x = Next(mean, dev);
            }
            while( x < min || x > max );

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
                v1 = 2.0f * RNG.Next() - 1.0f;
                v2 = 2.0f * RNG.Next() - 1.0f;
                s = v1 * v1 + v2 * v2;
            }
            while (s >= 1.0f || s == 0f);

            s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

            return v1 * s;
        }
    }
}
