using System;
using UnityEngine;

namespace Observer
{
    public static class EventManager
    {
        public static Action OnFightEnd;
        public static Action OnFightStart;
        public static Action OnRoundEnd;

        public static Action OnAiRoundStart;
    }
}