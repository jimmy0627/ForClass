using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public TMP_Text buttontext;
    public void onclicktext()
    {
        buttontext=transform.GetComponentInChildren<TMP_Text>();
        buttontext.text="123565";         
    }
}
