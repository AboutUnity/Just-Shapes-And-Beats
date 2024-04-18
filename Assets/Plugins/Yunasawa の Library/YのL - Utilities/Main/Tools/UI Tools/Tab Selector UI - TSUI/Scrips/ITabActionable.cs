using System;

namespace YNL.Tools.UI
{
    public interface ITabActionable
    {
        void Select();
        void Deselect();
    }

    public static class TabEvent
    {
        public static Action OnStart;
    }
}