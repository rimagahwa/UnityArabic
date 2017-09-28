using UnityEngine;
using System.Collections;
using ArabicSupport;
using UnityEngine.UI;

public class SetArabicTextUI : MonoBehaviour
{

    private Text attachedTextObject;
    [TextArea]
    private string text;
    public bool ShowTashkeel = false;
    public bool UseHinduNumbers = true;

    // Use this for initialization
    void Start()
    {
        attachedTextObject = gameObject.GetComponent<Text>();
        attachedTextObject.text = ArabicFixer.Fix(attachedTextObject.text);
        Debug.Log(attachedTextObject.text);

    }

}
