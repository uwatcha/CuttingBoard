using TMPro;
using UnityEngine;

public class PlayingTimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    void Update()
    {
        text.text = "PlayingTime: "+Timer.GetPlayingTime().ToString("F2")+"(s)";
    }
}
