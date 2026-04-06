using System;
using System.Collections.Generic;
using System.Text;
using Imui.IO.UGUI;
using UnityEngine;

namespace ImuiBepInEx.API
{
    public static class ImuiBepInExAPI
    {
        /// <summary>
        /// Loads all the assets necessary for Imui to work.
        /// </summary>
        /// <param name="onAssetLoad">Callback thats called once the assets are loaded</param>
        public static void Initialize(Action onAssetLoad = null)
        {
            AssetsManager.Initialize(onAssetLoad);
        }

        public static T CreateImuiPanel<T>() where T : MonoBehaviour
        {
            var canvas = Utility.CreateCanvasObject();
            if (canvas == null)
                return null;

            var backend = Utility.CreateImuiPanel(canvas.transform);
            if (backend == null)
                return null;

            return backend.gameObject.AddComponent<T>();
        }

        public static void Deinitialize(Action onAssetDeload = null)
        {
            AssetsManager.Deinitialize(onAssetDeload);
        }
    }
}
