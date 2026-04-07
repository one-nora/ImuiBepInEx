using System;
using System.Collections.Generic;
using System.Text;
using Imui.IO.UGUI;
using UnityEngine;
using UnityEngine.UI;

namespace ImuiBepInEx.API
{
    public static class Utility
    {
        /// <summary>
        /// Creates a canvas object that scales with the screen, it has no parent and is at the root of the hierarchy. 
        /// </summary>
        /// <returns> The canvas component.</returns>
        public static Canvas CreateCanvas()
        {
            GameObject canvasGO = new GameObject("ImuiCanvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            Canvas canvas = canvasGO.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 5000;

            // Configure CanvasScaler to scale with screen size
            CanvasScaler scaler = canvasGO.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1280, 720);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            scaler.matchWidthOrHeight = 0.5f;
            scaler.referencePixelsPerUnit = 100;

            canvasGO.transform.SetParent(null);
            canvasGO.transform.SetSiblingIndex(0); // Move it to the first position among root objects
            
            return canvas;
        }

        /// <summary>
        /// Creates a UI gameobject that streches to the limits of the canvas and contains a Imui backend component, thats necessary for rendering.
        /// </summary>
        /// <returns> The Imui backend of the created gameobject.</returns>
        public static ImuiUnityGUIBackend CreateImuiPanel(Transform parent = null)
        {
            var go = new GameObject("ImuiPanel");
            go.SetActive(false);

            var rect = go.AddComponent<RectTransform>();
            go.AddComponent<CanvasRenderer>();

            if (parent != null)
            {
                rect.SetParent(parent, false);
            }

            StrechRect(rect);

            ImuiUnityGUIBackend backend = go.AddComponent<ImuiUnityGUIBackend>();

            go.SetActive(true);
            return backend;
        }

        // For testing purposes
        public static GameObject CreateWhiteImageObject(Transform parent = null)
        {
            var go = new GameObject("ImuiPanel");
            go.SetActive(false);

            var rect = go.AddComponent<RectTransform>();
            go.AddComponent<CanvasRenderer>();

            if (parent != null)
            {
                rect.SetParent(parent, false);
            }

            StrechRect(rect);

            var raw = go.AddComponent<RawImage>();
            raw.texture = Texture2D.whiteTexture;

            go.SetActive(true);
            return go;
        }

        private static void StrechRect(RectTransform rect)
        {
            // Reset to a clean stretched state
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;

            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            rect.localScale = Vector3.one;
            rect.localRotation = Quaternion.identity;
            rect.anchoredPosition3D = Vector3.zero;

            rect.sizeDelta = Vector2.zero;
            rect.pivot = new Vector2(0.5f, 0.5f);
        }
    }
}