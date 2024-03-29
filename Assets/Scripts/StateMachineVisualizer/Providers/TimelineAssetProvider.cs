﻿#if UNITY_EDITOR
using System;
using System.IO;
using StateMachineVisualizer.Interfaces;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

namespace StateMachineVisualizer.Providers
{
    /// <summary>
    /// Provides functionality to create a new timeline asset for the state machine.
    /// </summary>
    public class TimelineAssetProvider : ITimelineAssetProvider
    {
        
        private const string ASSETS_PATH = "Assets/Logs";
        
        /// <summary>
        /// Creates a new timeline asset for the state machine.
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