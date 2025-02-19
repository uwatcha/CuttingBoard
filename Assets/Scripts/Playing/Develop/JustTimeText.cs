using TMPro;
using UnityEngine;

public class JustTimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private Note note;
    public Note Note
    {
        set
        {
            note = value;
        }
    }

    void Update()
    {
        if (note!=null)
        {
            text.text = (int)note.JustTime+"(s)";
        }
    }
}
