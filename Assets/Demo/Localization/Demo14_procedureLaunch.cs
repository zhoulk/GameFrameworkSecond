using Demo14;
using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Localization;
using GameFramework.Procedure;
using System;
using UnityGameFramework.Runtime;
using LoadDictionarySuccessEventArgs = UnityGameFramework.Runtime.LoadDictionarySuccessEventArgs;

public class Demo14_procedureLaunch : ProcedureBase {

    LocalizationComponent localizationComponent;

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架Event组件
        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        SettingComponent Setting = UnityGameFramework.Runtime.GameEntry.GetComponent<SettingComponent>();

        // 加载框架Event组件
        localizationComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<LocalizationComponent>();
        //// 订阅UI加载成功事件
        Event.Subscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);

        Language language = localizationComponent.Language;
        Log.Info(language);

        string languageString = Setting.GetString(Constant.Setting.Language);
        if (!string.IsNullOrEmpty(languageString))
        {
            try
            {
                language = (Language)Enum.Parse(typeof(Language), languageString);
            }
            catch
            {
            }
        }

        if (language != Language.English
            && language != Language.ChineseSimplified
            && language != Language.ChineseTraditional
            && language != Language.Korean)
        {
            // 若是暂不支持的语言，则使用英语
            language = Language.English;

            Setting.SetString(Constant.Setting.Language, language.ToString());
            Setting.Save();
        }

        localizationComponent.Language = language;

        Log.Info(language);

        localizationComponent.LoadDictionary("Default", LoadType.Text, this);

    }

    void OnLoadDictionarySuccess(object sender, GameEventArgs e)
    {
        string cancelText = localizationComponent.GetString("Dialog.CancelButton");
        Log.Info(cancelText);
    }
}

public static class LocalizationExtension
{
    public static void LoadDictionary(this LocalizationComponent localizationComponent, string dictionaryName, LoadType loadType, object userData = null)
    {
        if (string.IsNullOrEmpty(dictionaryName))
        {
            Log.Warning("Dictionary name is invalid.");
            return;
        }

        localizationComponent.LoadDictionary(dictionaryName, AssetUtility.GetDictionaryAsset(dictionaryName, loadType), loadType, Constant.AssetPriority.DictionaryAsset, userData);
    }
}

namespace Demo14
{
    public static partial class Constant
    {
        public static class Setting
        {
            public const string Language = "Setting.Language";
            public const string QualityLevel = "Setting.QualityLevel";
            public const string SoundGroupMuted = "Setting.{0}Muted";
            public const string SoundGroupVolume = "Setting.{0}Volume";
            public const string MusicMuted = "Setting.MusicMuted";
            public const string MusicVolume = "Setting.MusicVolume";
            public const string SoundMuted = "Setting.SoundMuted";
            public const string SoundVolume = "Setting.SoundVolume";
            public const string UISoundMuted = "Setting.UISoundMuted";
            public const string UISoundVolume = "Setting.UISoundVolume";
        }

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

        public static string GetDictionaryAsset(string assetName, LoadType loadType)
        {
            LocalizationComponent localizationComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<LocalizationComponent>();
            return Utility.Text.Format("Assets/Demo/Localization/{0}/Dictionaries/{1}.{2}", localizationComponent.Language.ToString(), assetName, loadType == LoadType.Text ? "xml" : "bytes");
        }

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

