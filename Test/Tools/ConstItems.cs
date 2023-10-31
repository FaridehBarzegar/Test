using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Public
{
    public static class ConstItems
    {
        public const int WaitTimeoutDefault = 3;
        public const int MaxWaitTimeOut = 60;
        public const bool ModelImageCreating = false;
    }

    public  enum PageEnums
    {
        Login,
        ShellPage,
        cartable,
        command,
        followup,
        memorandomView,
        objectPiker,
        saveMemorandom,
        sendMemorandom

    }
}
