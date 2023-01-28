using System;

namespace Lab5Games
{
    public static class EqualityExtensions
    {
        public static bool IsNullable(this object obj)
        {
            return Nullable.GetUnderlyingType(obj.GetType()) != null;
        }

        public static bool IsNull(this object obj)
        {
            if (!obj.IsNullable())
                return false;

            return ReferenceEquals(obj, null);
        }

        public static bool SafeEquals(this object obj, object other)
        {
            if (IsNull(obj) && IsNull(other))
            {
                return true;
            }
            else
            {
                return ReferenceEquals(obj, other);
            }
        }
    }
}
