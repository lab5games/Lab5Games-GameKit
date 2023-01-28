using System;

using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Mathf = UnityEngine.Mathf;

namespace Lab5Games
{
    public static class RNG 
    {        
        static Random m_Rnd = new Random(m_Seed);

        static int m_Seed = 0;

        public static int seed => m_Seed;

        public static void Init(int seed)
        {
            m_Seed = seed;
            m_Rnd = new Random(m_Seed);
        }

        public static float Next()
        {
            return (float)m_Rnd.NextDouble();
        }

        public static float Next(float min, float max)
        {
            if (min >= max)
                return min;

            return min + Next() * (max - min);
        }

        public static int Next(int min, int max)
        {
            if (min >= max)
                return min;

            return min + (int)(Next() * (max - min));
        }

        public static Vector2 GetInsideUnitCircle()
        {
            float r = Next();
            float theta = Next(0f, 2 * Mathf.PI);

            return r * new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        }

        public static Vector3 GetInsideUnitSphere()
        {
            float r = Next();
            float a = Next(0f, Mathf.PI);
            float b = Next(0f, 2 * Mathf.PI);

            return r * new Vector3(
                Mathf.Sin(a) * Mathf.Cos(b),
                Mathf.Sin(a) * Mathf.Sin(b),
                Mathf.Cos(a));
        }

        public static Vector2 GetNormalizedVector2()
        {
            float r = 1;
            float theta = Next(0f, 2 * Mathf.PI);

            return r * new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        }
        
        public static Vector3 GetNormalizedVector3()
        {
            float r = 1;
            float a = Next(0f, Mathf.PI);
            float b = Next(0f, 2 * Mathf.PI);

            return r * new Vector3(
                Mathf.Sin(a) * Mathf.Cos(b),
                Mathf.Sin(a) * Mathf.Sin(b),
                Mathf.Cos(a));
        }
    }
}
