using Imui.IO.UGUI;
using UnityEngine;

namespace ImuiBepInEx.API
{
    public class ImuiPanel
    {
        public Canvas Canvas;
        public ImuiUnityGUIBackend Backend;

        public ImuiPanel(Canvas Canvas = null, ImuiUnityGUIBackend Backend = null)
        {
            this.Canvas = Canvas;
            this.Backend = Backend;
        }
    }
}

