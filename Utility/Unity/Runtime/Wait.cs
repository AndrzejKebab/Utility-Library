using System.Collections.Generic;
using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Wait {
        public class WaitForSecondsCache {
            private Dictionary<float, WaitForSeconds> cache = new();
            public WaitForSeconds this[float time] => cache.TryGetValue(time, out var wait)
                ? wait
                : cache[time] = new WaitForSeconds(time);
        }
        public class WaitForSecondsRealtimeCache {
            private Dictionary<float, WaitForSecondsRealtime> cache = new();
            public WaitForSecondsRealtime this[float time] => cache.TryGetValue(time, out var wait)
                ? wait
                : cache[time] = new WaitForSecondsRealtime(time);
        }

        public static readonly WaitForFixedUpdate ForFixedUpdate = new WaitForFixedUpdate();
        public static readonly WaitForEndOfFrame ForEndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForSecondsCache ForSeconds = new WaitForSecondsCache();
        public static readonly WaitForSecondsRealtimeCache ForSecondsRealtime = new WaitForSecondsRealtimeCache();
    }
}