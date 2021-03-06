using DG.Tweening.Plugins.Core.PathCore;
using Platform;
using UnityEngine;
public abstract class PlatformManager
{
    private static PlatformManager _instance;
    public static PlatformManager Instance
    {
        get
        {
            if (_instance == null)
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsPlayer:
                        _instance = new WindowPlayer();
                        break;
                    case RuntimePlatform.IPhonePlayer:
                        _instance = new IPhonePlayer();
                        break;
                    case RuntimePlatform.Android:
                        _instance = new AndroidPlayer();
                        break;
                    case RuntimePlatform.WindowsEditor:
                        _instance = new EditorPlayer();
                        break;
                    default:
                        break;
                }
            }
            return _instance;
        }
    }
    public abstract bool IsEditor();
    public abstract string Name();
}
