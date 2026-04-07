using BepInEx;
using UnityEngine;

namespace ImuiBepInEx;

[BepInPlugin(GUID, NAME, VERSION)]
public class Plugin : BaseUnityPlugin
{
    public const string GUID = "com.prideunique.imuibepinex";
    public const string NAME = "ImuiBepInEx";
    public const string VERSION = "1.0.0";
    
    private void Awake()
    {
        // Initialize Assets
        AssetsManager.Initialize();
        
        Debug.Log("[ImuiBepInEx]: Loaded assets!");
    }

    private void OnDestroy()
    {
        AssetsManager.Deinitialize();
    }
}