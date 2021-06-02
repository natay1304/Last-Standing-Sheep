using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu]
public class GameRecordsLoader : ScriptableObject
{
    private string Path => Application.streamingAssetsPath + "/LevelInfo.json";
    private string PathAndroid => Application.persistentDataPath + "/LevelInfo.json";

    [System.NonSerialized]
    private Level _level;

    public Level LevelInfo
    {
        get
        {
            if(_level == null)
            {
#if !UNITY_EDITOR
                if(!File.Exists(PathAndroid))
                {
                    WWW www = new WWW(Path);
                    while(!www.isDone) { }
                    File.WriteAllBytes(PathAndroid, www.bytes);
                }
                _level = JsonUtility.FromJson<Level>(File.ReadAllText(PathAndroid));
#else
                _level = JsonUtility.FromJson<Level>(File.ReadAllText(Path));
#endif
            }
            Debug.Log(_level);
            Debug.Log(_level.leaderboard[0].name);
            return _level;
        }
    }

    public void AddPlayerResult(string userName, float time)
    {
        var leaderboard = LevelInfo.leaderboard;
        for (int i = 0; i < leaderboard.Count;)
        {
            if(userName == leaderboard[i].name)
            {
                leaderboard.RemoveAt(i);
                continue;
            }
            i++;
        }

        int index = 0;
        for (int i = 0; i < leaderboard.Count; i++, index++)
        {
            if (leaderboard[i].time > time)
                break;
        }

        var userResult = new LeaderboardItem() { name = userName, time = time };
        leaderboard.Insert(index, userResult);

        string newPlayerResults = JsonUtility.ToJson(_level);

#if !UNITY_EDITOR
        File.WriteAllText(PathAndroid, newPlayerResults);
#else
        File.WriteAllText(Path, newPlayerResults);
#endif
    }
}
