using System;
using Unity.Jobs;

namespace UtilityLibrary.Unity.Runtime
{
    public class JobHandleCompleter
    {
        private readonly JobHandle handle;
        private readonly Action onComplete;

        public JobHandleCompleter(JobHandle handle, Action onComplete)
        {
            this.handle = handle;
            this.onComplete = onComplete;
        }

        public bool IsCompleted => handle.IsCompleted;

        public void Complete()
        {
            handle.Complete();
            onComplete();
        }
    }
}