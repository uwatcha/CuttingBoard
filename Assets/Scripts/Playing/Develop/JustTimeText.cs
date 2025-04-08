using TMPro;
using UnityEngine;

public class JustTimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private INote note;
    public INote Note
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
