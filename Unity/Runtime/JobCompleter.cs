using System;
using Unity.Jobs;

namespace UtilityLibrary.Unity.Runtime
{
    public static class JobCompleter
    {
        public static JobHandleCompleter Schedule(Func<JobHandle> schedule, Action onComplete)
        {
            var handle = schedule();
            var job = new JobHandleCompleter(handle, onComplete);
            return job;
        }
    }
}
