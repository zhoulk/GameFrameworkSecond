using Demo13;
using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

public class Demo13_procedureLaunch : ProcedureBase {

    ConfigComponent configComponent;

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架Event组件
        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        // 订阅UI加载成功事件
        Event.Subscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);

        //根据绝对路径设置与获取数据
        configComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<ConfigComponent>();
        configComponent.LoadConfig("DefaultConfig", LoadType.Text, this);

        
    }

    void OnLoadConfigSuccess(object sender, GameEventArgs e)
    {
        int value = configComponent.GetInt("Scene.Menu");
        Log.Info(value);
    }
}

public static class ConfigExtension
{
    public static void LoadConfig(this ConfigComponent configComponent, string configName, LoadType loadType, object userData = null)
    {
        if (string.IsNullOrEmpty(configName))
        {
            Log.Warning("Config name is invalid.");
            return;
        }

        configComponent.LoadConfig(configName, AssetUtility.GetConfigAsset(configName, loadType), loadType, Constant.AssetPriority.ConfigAsset, userData);
    }
}

namespace Demo13
{

    public static partial class Constant
    {
        /// <summary>
        /// 资源优先级。
        /// </summary>
        public static class AssetPriority
        {
            public const int ConfigAsset = 100;
            public const int DataTableAsset = 100;
            public const int DictionaryAsset = 100;
            public const int FontAsset = 50;
            public const int MusicAsset = 20;
            public const int SceneAsset = 0;
            public const int SoundAsset = 30;
            public const int UIFormAsset = 50;
            public const int UISoundAsset = 30;

            public const int MyAircraftAsset = 90;
            public const int AircraftAsset = 80;
            public const int ThrusterAsset = 30;
            public const int WeaponAsset = 30;
            public const int ArmorAsset = 30;
            public const int BulletAsset = 80;
            public const int AsteroiAsset = 80;
            public const int EffectAsset = 80;
        }
    }

    public static class AssetUtility
    {
        public static string GetConfigAsset(string assetName, LoadType loadType)
        {
            return Utility.Text.Format("Assets/Demo/Config/{0}.{1}", assetName, loadType == LoadType.Text ? "txt" : "bytes");
        }

        //public static string GetDataTableAsset(string assetName, LoadType loadType)
        //{
        //    return Utility.Text.Format("Assets/GameMain/DataTables/{0}.{1}", assetName, loadType == LoadType.Text ? "txt" : "bytes");
        //}

        //public static string GetDictionaryAsset(string assetName, LoadType loadType)
        //{
        //    return Utility.Text.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.{2}", GameEntry.Localization.Language.ToString(), assetName, loadType == LoadType.Text ? "xml" : "bytes");
        //}

        //public static string GetFontAsset(string assetName)
        //{
        //    return Utility.Text.Format("Assets/GameMain/Fonts/{0}.ttf", assetName);
        //}

        //public static string GetSceneAsset(string assetName)
        //{
        //    return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        //}

        //public static string GetMusicAsset(string assetName)
        //{
        //    return Utility.Text.Format("Assets/GameMain/Music/{0}.mp3", assetName);
        //}

        //public static string GetSoundAsset(string assetName)
        //{
        //    return Utility.Text.Format("Assets/GameMain/Sounds/{0}.wav", assetName);
        //}

        //public static string GetEntityAsset(string assetName)
        //{
        //    return Utility.Text.Format("Assets/GameMain/Entities/{0}.prefab", assetName);
        //}

        //public static string GetUIFormAsset(string assetName)
        //{
        //    return Utility.Text.Format("Assets/GameMain/UI/UIForms/{0}.prefab", assetName);
        //}

        //public static string GetUISoundAsset(string assetName)
        //{
        //    return Utility.Text.Format("Assets/GameMain/UI/UISounds/{0}.wav", assetName);
        //}
    }
}


