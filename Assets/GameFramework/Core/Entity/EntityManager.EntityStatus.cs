﻿
namespace GameFramework.Entity
{
    internal sealed partial class EntityManager : GameFrameworkModule, IEntityManager
    {
        /// <summary>
        /// 实体状态。
        /// </summary>
        private enum EntityStatus
        {
            Unknown = 0,
            WillInit,
            Inited,
            WillShow,
            Showed,
            WillHide,
            Hidden,
            WillRecycle,
            Recycled
        }
    }
}