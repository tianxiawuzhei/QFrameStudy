using System;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace QFStudyLesson
{
    public class ResKitTest : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Awake()
        {
            ResMgr.Init();
        }
        
        /// <summary>
        /// 每一个需要加载资源的单元（脚本、界面）申请一个 ResLoader
        /// ResLoader 本身会记录该脚本加载过的资源
        /// </summary>
        /// <returns></returns>
        ResLoader mResLoader = ResLoader.Allocate ();

        private void Start()
        {
            // 通过 LoadSync 同步加载资源
            // 只需要传入资源名即可，不需要传入 AssetBundle 名。
            mResLoader.LoadSync<GameObject> ("Cube")
                .Instantiate ();
        }

        private void OnDestroy()
        {
            mResLoader.Recycle2Cache();
            mResLoader = null;
        }
    }
}
