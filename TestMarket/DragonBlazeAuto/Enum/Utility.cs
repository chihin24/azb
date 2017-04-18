using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBlazeAuto.Enum
{
    public class Utility
    {
        public const string ERROR_HEADER = "[****]";
        public enum TapStatus
        {
            NotError = 0,
            Error,
            LocationEmpty
        }
    }
}
