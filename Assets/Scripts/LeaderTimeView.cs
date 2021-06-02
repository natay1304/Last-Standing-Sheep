using UnityEngine;
using UnityEngine.UI;

public class LeaderTimeView : MonoBehaviour
{
    [SerializeField]
    private Text _leaderName;
    [SerializeField]
    private Text _leaderTime;

    public void Initialize(LeaderboardItem leaderboardItem)
    {
        _leaderName.text = leaderboardItem.name;
        _leaderTime.text = leaderboardItem.time.ToString();
    }

}