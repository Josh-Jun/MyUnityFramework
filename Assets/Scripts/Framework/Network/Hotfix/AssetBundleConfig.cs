using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

namespace Data
{
    [System.Serializable]
    public class AssetBundleConfig
    {
        [XmlAttribute]
        public string GameVersion;//游戏版本号

        [XmlElement]
        public List<Scene> Scenes;//AB包场景
    }

    [System.Serializable]
    public class Scene
    {
        [XmlAttribute]
        public string SceneName;//AB包场景名

        [XmlAttribute]
        public string Version;//当前版本热更的版本号-第几次热更

        [XmlAttribute]
        public string Des;//热更描述

        [XmlElement]
        public List<Folder> Folders; //文件夹
    }

    /// <summary>
    /// 单个补丁包
    /// </summary>
    [System.Serializable]
    public class Folder
    {
        [XmlAttribute]
        public string FolderName;//文件夹名

        [XmlAttribute]
        public string BundleName;//包名

        [XmlAttribute]
        public string Platform;//当前包的平台

        [XmlAttribute]
        public string HashCode; //HashCode

        [XmlAttribute]
        public float Size;//资源大小
    }
}