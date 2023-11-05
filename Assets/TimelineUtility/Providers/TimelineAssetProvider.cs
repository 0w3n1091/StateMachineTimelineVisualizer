#if UNITY_EDITOR
using System;
using System.IO;
using TimelineUtility.Interfaces;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

namespace TimelineUtility.Providers
{
    public class TimelineAssetProvider : ITimelineAssetProvider
    {
        private const string ASSETS_PATH = "Assets/TimelineUtility/Logs";
        
        /// <summary>
        /// Creates new timeline asset log.
        /// </summary>
        /// <returns>Created timeline asset.</returns>
        public TimelineAsset CreateAsset()
        {
            if (!Directory.Exists(ASSETS_PATH))
                Directory.CreateDirectory(ASSETS_PATH);
            
            string assetPath = $"{ASSETS_PATH}/{DateTime.Now.ToString("MM_dd_yyyy_HH-mm-ss")}.playable";
            TimelineAsset asset = ScriptableObject.CreateInstance<TimelineAsset>();
            TimelineEditor.GetOrCreateWindow();
            AssetDatabase.CreateAsset(asset, assetPath);

            return asset;
        }
    }
}
#endif