using UnityEngine;
namespace Utilities.Lerpers
{
   public static class LerpUtils
   {
      public static float TimedLerp(float from, float to, ref float elapsed, float duration, bool forward)
      {
         if (forward)
         {
            elapsed += Time.deltaTime;
            if (elapsed > duration) elapsed = duration;
         }
         else
         {
            elapsed -= Time.deltaTime;
            if (elapsed < 0f) elapsed = 0f;
         }

         return Mathf.Lerp(from, to, duration > 0f ? elapsed / duration : 1f);
      }
   }
}

