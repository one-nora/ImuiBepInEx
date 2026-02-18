using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ImuiBepInEx
{
    internal static class AssetsManager
    {
        private static AssetBundle? _bundle = null;
        public static bool AssetBundleLoaded = false;

        public static void Initialize(Action onLoaded = null)
        {
            Debug.Log("Loading Imui assets");

            byte[] data;
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resourceName = $"ImuiBepInEx.Assets.ImuiAssetBundle";
                var streamData = assembly.GetManifestResourceStream(resourceName);
                streamData = streamData ?? throw new FileNotFoundException($"Could not find embedded resource '{resourceName}'.");
                
                using var memoryStream = new MemoryStream();
                streamData.CopyTo(memoryStream);
                data = memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error loading assets: " + ex.Message);
                return;
            }

            if (_bundle != null)
                return;

            _bundle = AssetBundle.LoadFromMemory(data);
            AssetBundleLoaded = true;
            
            Debug.Log("Loaded Imui assets");

            onLoaded?.Invoke();
        }

        public static T? LoadAsset<T>(string assetName) where T : UnityEngine.Object
        {
            if (_bundle == null)
                return null;

            var asset = _bundle.LoadAsset<T>(assetName);
            if (asset == null)
                return null;

            return asset;
        }

        public static T? LoadAndInstantiateAsset<T>(string assetName) where T : UnityEngine.Object
        {
            if (_bundle == null)
                return null;

            var go = _bundle.LoadAsset<T>(assetName);
            if (go == null)
                return null;

            return UnityEngine.Object.Instantiate<T>(go);
        }
    }
}