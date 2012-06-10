//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // Utils
    //
    // Helper class, global for methods that do not fall in any object and that
    // do not need to be instantiated
    //-----------------------------------------------------------------------------
    public static class Utils
    {
        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static bool MustSkipFrame(float waitMilliseconds, TimeSpan currentTime, TimeSpan previousTime)
        {
            return ((waitMilliseconds > 0.0f) && (currentTime.TotalMilliseconds - previousTime.TotalMilliseconds < waitMilliseconds));
        }
    }
}
