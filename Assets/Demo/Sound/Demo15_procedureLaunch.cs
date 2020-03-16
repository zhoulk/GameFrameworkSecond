using Demo15;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Localization;
using GameFramework.Procedure;
using GameFramework.Sound;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;
using LoadDictionarySuccessEventArgs = UnityGameFramework.Runtime.LoadDictionarySuccessEventArgs;

public class Demo15_procedureLaunch : ProcedureBase {

    SoundComponent soundComponent;

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架Event组件
        soundComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<SoundComponent>();
        // 获取框架事件组件
        EventComponent Event
            = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        // 获取框架数据表组件
        DataTableComponent DataTable
            = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();

        // 订阅加载成功事件
        Event.Subscribe(UnityGameFramework.Runtime.LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        // 加载配置表
        DataTable.LoadDataTable<DRUISound>("Hero", "Assets/Demo/Sound/UISound.txt", GameFramework.LoadType.Text);
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (Input.GetMouseButtonDown(0))
        {
            PlayUISound(10000);
        }
    }

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        PlayUISound(10000);
    }

    public int PlayUISound(int uiSoundId, object userData = null)
    {
        DataTableComponent dataTableComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();
        IDataTable<DRUISound> dtUISound = dataTableComponent.GetDataTable<DRUISound>();
        DRUISound drUISound = dtUISound.GetDataRow(uiSoundId);
        if (drUISound == null)
        {
            Log.Warning("Can not load UI sound '{0}' from data table.", uiSoundId.ToString());
            return -1;
        }

        PlaySoundParams playSoundParams = PlaySoundParams.Create();
        playSoundParams.Priority = drUISound.Priority;
        playSoundParams.Loop = false;
        playSoundParams.VolumeInSoundGroup = drUISound.Volume;
        playSoundParams.SpatialBlend = 0f;
        return soundComponent.PlaySound(AssetUtility.GetUISoundAsset(drUISound.AssetName), "UISound", Demo15.Constant.AssetPriority.UISoundAsset, playSoundParams, userData);
    }
}

/// <summary>
/// 声音配置表。
/// </summary>
public class DRUISound : DataRowBase
{
    private int m_Id = 0;


    /// <summary>
    /// 获取资源名称。
    /// </summary>
    public string AssetName
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取优先级（默认0，128最高，-128最低）。
    /// </summary>
    public int Priority
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取音量（0~1）。
    /// </summary>
    public float Volume
    {
        get;
        private set;
    }

    public override int Id
    {
        get
        {
            return m_Id;
        }
    }

    public bool ParseDataRow(GameFrameworkSegment<string> dataRowSegment)
    {
        char[] DataSplitSeparators = new char[] { '\t' };
        char[] DataTrimSeparators = new char[] { '\"' };

        // Star Force 示例代码，正式项目使用时请调整此处的生成代码，以处理 GCAlloc 问题！
        string[] columnTexts = dataRowSegment.Source.Substring(dataRowSegment.Offset, dataRowSegment.Length).Split(DataSplitSeparators);
        for (int i = 0; i < columnTexts.Length; i++)
        {
            columnTexts[i] = columnTexts[i].Trim(DataTrimSeparators);
        }

        int index = 0;
        index++;
        m_Id = int.Parse(columnTexts[index++]);
        index++;
        AssetName = columnTexts[index++];
        Priority = int.Parse(columnTexts[index++]);
        Volume = float.Parse(columnTexts[index++]);

        GeneratePropertyArray();
        return true;
    }

    public bool ParseDataRow(GameFrameworkSegment<byte[]> dataRowSegment)
    {
        // Star Force 示例代码，正式项目使用时请调整此处的生成代码，以处理 GCAlloc 问题！
        using (MemoryStream memoryStream = new MemoryStream(dataRowSegment.Source, dataRowSegment.Offset, dataRowSegment.Length, false))
        {
            using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
            {
                m_Id = binaryReader.ReadInt32();
                AssetName = binaryReader.ReadString();
                Priority = binaryReader.ReadInt32();
                Volume = binaryReader.ReadSingle();
            }
        }

        GeneratePropertyArray();
        return true;
    }

    public bool ParseDataRow(GameFrameworkSegment<Stream> dataRowSegment)
    {
        throw new NotImplementedException();
    }

    //public override bool ParseDataRow(GameFrameworkSegment<Stream> dataRowSegment)
    //{
    //    Log.Warning("Not implemented ParseDataRow(GameFrameworkSegment<Stream>)");
    //    return false;
    //}

    //public bool ParseDataRow(GameFrameworkSegment<Stream> dataRowSegment)
    //{
    //    throw new NotImplementedException();
    //}

    private void GeneratePropertyArray()
    {

    }
}

namespace Demo15
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

        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Demo/Sound/UISounds/{0}.wav", assetName);
        }
    }
}

