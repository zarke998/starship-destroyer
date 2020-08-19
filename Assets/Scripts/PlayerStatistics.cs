using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public sealed class PlayerStatistics
{
    private static volatile PlayerStatistics instance;
    private static readonly object lockObj = new object();
    public static PlayerStatistics Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new PlayerStatistics();
                    }
                }
            }

            return instance;
        }
    }

    private string savePath;

    public int HighScore { get; set; }

    private PlayerStatistics()
    {
        savePath = Application.dataPath;

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
                savePath = Path.Combine(Application.dataPath, "player_stats.xml");
                break;
            case RuntimePlatform.WindowsEditor:
                savePath = Path.Combine(Application.dataPath, "Data", "player_stats.xml");
                break;
        }
    }
    
    public void Load()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("Player statistics xml not created yet.");
            return;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerStatistics));

        using (StreamReader reader = new StreamReader(savePath))
        {
            var statistics = serializer.Deserialize(reader) as PlayerStatistics;
            this.HighScore = statistics.HighScore;
        }
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(PlayerStatistics));

        using(StreamWriter writer = new StreamWriter(savePath)){
            serializer.Serialize(writer, this);
        }
    }
}
