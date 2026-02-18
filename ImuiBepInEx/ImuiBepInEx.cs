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
        public static void Initialize(Action onAssetLoad = null)
        {
            AssetsManager.Initialize(() =>
            {
                onAssetLoad?.Invoke();
            });
        }

        public static GameObject GetMainCanvas()
        {
            if (mainCanvas == null)
                mainCanvas = Utility.CreateCanvasObject();

            return mainCanvas;
        }

        public static ImuiUnityGUIBackend GetMainBackend()
        {
            if (mainCanvas == null)
            {
                mainCanvas = Utility.CreateCanvasObject();
                if (mainCanvas != null)
                {
                    mainBackend = Utility.CreateImuiObject(mainCanvas.transform);
                    return mainBackend;
                }

                return null;
            }

            if (mainBackend == null)
                mainBackend = Utility.CreateImuiObject(mainCanvas.transform);

            return mainBackend;
        }
    }
}
