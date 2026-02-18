using System;
using System.Collections.Generic;
using System.Text;
using Imui.IO.UGUI;
using UnityEngine;

namespace ImuiBepInEx
{
    public static class Main
    {
        private static GameObject mainCanvas;
        private static ImuiUnityGUIBackend mainBackend;

        /// <summary>
        /// Loads all the assets necessary for Imui to work, and creates a Canvas
        /// with a gameobject as a child, this gameobject contains a backend (necessary for rendering)
        /// </summary>
        /// <param name="onAssetLoad">Callback thats called once the assets are loaded</param>
        public static void Initalize(Action onAssetLoad = null)
        {
            AssetsManager.Initalize(() =>
            {
                onAssetLoad?.Invoke();

                mainCanvas = Utility.CreateCanvasObject();
                if (mainCanvas != null)
                {
                    mainBackend = Utility.CreateImuiObject();
                }
            });
        }

        public static GameObject GetMainCanvas()
        {
            return mainCanvas;
        }

        public static ImuiUnityGUIBackend GetMainBackend()
        {
            return mainBackend;
        }
    }
}
