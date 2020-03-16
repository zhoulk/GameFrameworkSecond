using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public static class DataTableExtension
    {
        private const string DataRowClassPrefixName = "StarForce.DR";
        internal static readonly char[] DataSplitSeparators = new char[] { '\t' };
        internal static readonly char[] DataTrimSeparators = new char[] { '\"' };

        public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName, LoadType loadType, object userData = null)
        {
            if (string.IsNullOrEmpty(dataTableName))
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            string[] splitNames = dataTableName.Split('_');
            if (splitNames.Length > 2)
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            string dataRowClassName = DataRowClassPrefixName + splitNames[0];

            Type dataRowType = Type.GetType(dataRowClassName);
            if (dataRowType == null)
            {
                Log.Warning("Can not get data row type with class name '{0}'.", dataRowClassName);
                return;
            }

            string dataTableNameInType = splitNames.Length > 1 ? splitNames[1] : null;
            dataTableComponent.LoadDataTable(dataRowType, dataTableName, dataTableNameInType, AssetUtility.GetDataTableAsset(dataTableName, loadType), loadType, Constant.AssetPriority.DataTableAsset, userData);
        }

        public static Color32 ParseColor32(string value)
        {
            string[] splitValue = value.Split(',');
            return new Color32(byte.Parse(splitValue[0]), byte.Parse(splitValue[1]), byte.Parse(splitValue[2]), byte.Parse(splitValue[3]));
        }

        public static Color ParseColor(string value)
        {
            string[] splitValue = value.Split(',');
            return new Color(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]), float.Parse(splitValue[3]));
        }

        public static Quaternion ParseQuaternion(string value)
        {
            string[] splitValue = value.Split(',');
            return new Quaternion(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]), float.Parse(splitValue[3]));
        }

        public static Rect ParseRect(string value)
        {
            string[] splitValue = value.Split(',');
            return new Rect(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]), float.Parse(splitValue[3]));
        }

        public static Vector2 ParseVector2(string value)
        {
            string[] splitValue = value.Split(',');
            return new Vector2(float.Parse(splitValue[0]), float.Parse(splitValue[1]));
        }

        public static Vector3 ParseVector3(string value)
        {
            string[] splitValue = value.Split(',');
            return new Vector3(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]));
        }

        public static Vector4 ParseVector4(string value)
        {
            string[] splitValue = value.Split(',');
            return new Vector4(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]), float.Parse(splitValue[3]));
        }
    }

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

        public static string GetDataTableAsset(string assetName, LoadType loadType)
        {
            return Utility.Text.Format("Assets/Demo/DataTable/{0}.{1}", assetName, loadType == LoadType.Text ? "txt" : "bytes");
        }

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