using TMPro;
using UnityEngine;

public class PlayingTimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TimeManager timeManager;
    void Update()
    {
        text.text = "PlayingTime: "+(int)timeManager.GetPlayingTime()+"(s)";
    }
}
