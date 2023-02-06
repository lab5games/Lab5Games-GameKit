using UnityEngine;

namespace Lab5Games
{
    public static class RNG
    {
        public static RandomTable Table { get; private set; }

        public static void Init(RandomTable randomTable)
        {
            Table = randomTable;
        }

        public static float Next()
        {
            return Table.Next();
        }

        public static float Next(float min, float max)
        {
            if (min >= max) 
                return min;

            return min + Next() * (max - min);
        }

        public static float Next(int min, int max)
        {
            if (min >= max)
                return min;

            return min + Mathf.FloorToInt(Next() * (max - min));
        }

        public static Vector2 NextInsideUnitCircle()
        {
            float r = Next();
            float theta = Next(0f, 2 * Mathf.PI);

            return r * new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        }

        public static Vector3 NextInsideUnitSphere()
        {
            float r = Next();
            float a = Next(0f, Mathf.PI);
            float b = Next(0f, 2 * Mathf.PI);

            return r * new Vector3(
                Mathf.Sin(a) * Mathf.Cos(b),
                Mathf.Sin(a) * Mathf.Sin(b),
                Mathf.Cos(a));
        }

        public static Vector2 NextNormalizedVector2()
        {
            float r = 1;
            float theta = Next(0f, 2 * Mathf.PI);

            return r * new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        }

        public static Vector3 NextNormalizedVector3()
        {
            float r = 1;
            float a = Next(0f, Mathf.PI);
            float b = Next(0f, 2 * Mathf.PI);

            return r * new Vector3(
                Mathf.Sin(a) * Mathf.Cos(b),
                Mathf.Sin(a) * Mathf.Sin(b),
                Mathf.Cos(a));
        }

        #region Gaussian
        public static float NextGaussian(float mean, float dev, float min, float max)
        {
            float x;
            do
            {
                x = Next(mean, dev);
            } while (x < min || x > max);
            return x;
        }

        public static float NextGaussian(float mean, float dev)
        {
            return mean + Next() * dev;
        }

        public static float NextGaussian()
        {
            float v1, v2, s;
            do
            {
                v1 = 2.0f * RNG.Next() - 1.0f;
                v2 = 2.0f * RNG.Next() - 1.0f;
                s = v1 * v1 + v2 * v2;
            } while (s >= 1.0f || s == 0f);
            s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
            return v1 * s;
        }
        #endregion
    }
}
