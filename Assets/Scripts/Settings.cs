using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public sealed class Settings
{
    private static volatile Settings instance;
    private static readonly object lockObj = new object();
    public static Settings Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                    }
                }
            }

            return instance;
        }
    }

    private string savePath;

    public bool MusicEnabled { get; set; } = true;

    private Settings()
    {
        savePath = Application.dataPath;

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
                savePath = Path.Combine(Application.dataPath, "settings.xml");
                break;
            case RuntimePlatform.WindowsEditor:
                savePath = Path.Combine(Application.dataPath, "Data", "settings.xml");
                break;
        }
    }
    
    public void Load()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("Settings xml not created yet.");
            return;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(Settings));

        using (StreamReader reader = new StreamReader(savePath))
        {
            var settings = serializer.Deserialize(reader) as Settings;
            this.MusicEnabled = settings.MusicEnabled;
        }
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(Settings));

        using(StreamWriter writer = new StreamWriter(savePath)){
            serializer.Serialize(writer, this);
        }
    }
}
