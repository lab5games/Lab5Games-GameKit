using UnityEngine;

namespace Lab5Games
{
    public static class RNG
    {
        public delegate float RandomNumberDelegate();

        public static RandomNumberDelegate onGetRandomNumber;

        static RNG()
        {
            onGetRandomNumber = new RandomNumberDelegate(GetDefaultRandomValue);
        }

        static float GetDefaultRandomValue()
        {
            return UnityEngine.Random.value;
        }

        public static float Next()
        {
            return onGetRandomNumber.Invoke();            
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
    }
}
