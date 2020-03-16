
using Demo19;
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using Constant = Demo19.Constant;

public class Demo19_procedureLaunch : ProcedureBase {

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架Event组件
        LoadFont("MainFont");
    }

    private void LoadFont(string fontName)
    {
        ResourceComponent resourceComponent = GameEntry.GetComponent<ResourceComponent>();
        resourceComponent.LoadAsset(AssetUtility.GetFontAsset(fontName), Constant.AssetPriority.FontAsset, new LoadAssetCallbacks(
            (assetName, asset, duration, userData) =>
            {
                //UGuiForm.SetMainFont((Font)asset);
                Log.Info("Load font '{0}' OK.  {1}", fontName , asset);
            },

            (assetName, status, errorMessage, userData) =>
            {
                Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", fontName, assetName, errorMessage);
            }));
    }
}


namespace Demo19
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

        public static string GetFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Demo/Resource/{0}.ttf", assetName);
        }

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