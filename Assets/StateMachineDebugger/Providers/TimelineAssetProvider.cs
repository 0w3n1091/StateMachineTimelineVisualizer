#if UNITY_EDITOR
using System;
using System.IO;
using StateMachineDebugger.Interfaces;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

namespace StateMachineDebugger.Providers
{
    public class TimelineAssetProvider : ITimelineAssetProvider
    {
        private const string ASSETS_PATH = "Assets/StateMachineDebugger/Logs";

        /// <summary>
        /// Creates a new timeline asset log.
        /// </summary>
        /// <returns>The created timeline asset.</returns>
        public TimelineAsset CreateAsset()
        {
            if (!Directory.Exists(ASSETS_PATH))
                Directory.CreateDirectory(ASSETS_PATH);
            
            string assetPath = $"{ASSETS_PATH}/{DateTime.Now:MM_dd_yyyy_HH-mm-ss}.playable";
            TimelineAsset asset = ScriptableObject.CreateInstance<TimelineAsset>();
            TimelineEditor.GetOrCreateWindow();
            AssetDatabase.CreateAsset(asset, assetPath);

            return asset;
        }
    }
}
#endif