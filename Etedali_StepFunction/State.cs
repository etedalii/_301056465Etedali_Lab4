using System;
using System.Collections.Generic;
using System.Text;

namespace Etedali_StepFunction
{
    /// <summary>
    /// The state passed between the step function executions.
    /// </summary>
    public class State
    {
        public string BucketName { get; set; }

        public string Key { get; set; }

        public int WaitInSeconds { get; set; }
    }
}
