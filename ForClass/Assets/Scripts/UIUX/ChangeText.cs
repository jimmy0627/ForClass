using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    private TMP_Text textarea;
    private GameObject Speakername;
    public void onclicktext()
    {
        textarea=transform.Find("TextArea").GetComponentInChildren<TextMeshProUGUI>();
        Speakername=transform.Find("NameTag").gameObject;
        string raw_script=transform.GetComponent<Scripts_storge>().GetNextMove();

        try
        {
            List<string> script=raw_script.Split(" ").ToList();//將原始指令轉換成list
            foreach (var item in script)
            {
                Debug.Log(item);
            }
            Color newcolor;
            Image temp;
            switch (int.Parse(script[0])) //設定誰在說話
            {
                case 0:
                    
                    Speakername.GetComponentInChildren<TextMeshProUGUI>().text="嵐夢";//設定名子
                    ColorUtility.TryParseHtmlString("#00064F", out newcolor);
                    Speakername.GetComponentInChildren<TextMeshProUGUI>().color=newcolor;

                    ColorUtility.TryParseHtmlString("#B5BDC3", out newcolor);//設定名牌顏色
                    Speakername.GetComponent<Image>().color=newcolor;
                    temp = Speakername.transform.Find("halo").GetComponent<Image>();
                    newcolor.a=0.16f;
                    temp.color=newcolor;

                    
                    break;
                case 1:
                    Speakername.GetComponentInChildren<TextMeshProUGUI>().text="凜";//設定名子
                    ColorUtility.TryParseHtmlString("#CC0000", out newcolor);
                    Speakername.GetComponentInChildren<TextMeshProUGUI>().color=newcolor;

                    ColorUtility.TryParseHtmlString("#FFD7E0", out newcolor); //設定名牌顏色
                    Speakername.GetComponent<Image>().color=newcolor;
                    temp = Speakername.transform.Find("halo").GetComponent<Image>();
                    newcolor.a=0.16f;
                    temp.color=newcolor;


                    break;
                default:
                    Speakername.GetComponentInChildren<TextMeshProUGUI>().text=" ";

                    ColorUtility.TryParseHtmlString("#ffffff", out newcolor);
                    Speakername.GetComponent<Image>().color=newcolor;
                    temp = Speakername.transform.Find("halo").GetComponent<Image>();
                    temp.color=newcolor;
                    break;
            }
            
            textarea.text=script[1];//設定劇情文字

            Image backgroundimage=GetComponent<Image>();
            backgroundimage.sprite=transform.GetComponent<Scripts_storge>().GetImage(int.Parse(script[2]));
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
            return;
        }
    }
    void Start()
    {
        onclicktext();
    }
}
