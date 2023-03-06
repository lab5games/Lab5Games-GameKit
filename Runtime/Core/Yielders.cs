using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace Lab5Games
{
    public static class Yielders
    {
        public static readonly WaitForEndOfFrame EndOfFrame = new WaitForEndOfFrame();


        static readonly Dictionary<float, WaitForSeconds> _waitSeconds = new Dictionary<float, WaitForSeconds>(new FloatComparer());
        public static WaitForSeconds WaitSeconds(float seconds)
        {
            WaitForSeconds wfs = null;
            if (!_waitSeconds.TryGetValue(seconds, out wfs))
            {
                wfs = new WaitForSeconds(seconds);
                _waitSeconds.Add(seconds, wfs);
            }

            return wfs;
        }
    }
}
