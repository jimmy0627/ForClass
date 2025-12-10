using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scripts_storge : MonoBehaviour
{
    //儲存劇情推進需要的參數，第一個int代表誰在說話 第二組是一段String，代表台詞 第三組是一個int代表要使用哪張圖片
    //圖片庫
    public List<Sprite> BackgroundImages=new List<Sprite>();
    public DialogueNode StartingNode;
    private DialogueNode currentNode;
    private int currentpos=0;
    void Start()
    {
        // 初始化時設定為起始節點
        currentNode = StartingNode;
    }
    
    public string GetNextMove()
    {
        try
        {
            if (currentpos<currentNode.DialogueTexts.Count){
                return currentNode.DialogueTexts[currentpos++];
            }
            else if(currentNode.Options.Count>0)
            {
                
                GameObject panel=transform.Find("OptionPanel").gameObject;
                panel.SetActive(true);
                Debug.Log(currentNode.Options[0].OptionText);
                panel.transform.Find("Option 1").GetComponentInChildren<TextMeshProUGUI>().text=currentNode.Options[0].OptionText;
                panel.transform.Find("Option 2").GetComponentInChildren<TextMeshProUGUI>().text=currentNode.Options[1].OptionText;
                return null;
            }
            else
            {
                return null;
            }
        }
        catch (System.Exception)
        {
            throw;
        }


    }

    public void setcurrentnode(DialogueNode node)
    {
        currentNode=node;
    }
    public DialogueNode GetDialogueNode()
    {
        return currentNode;
    }
    public void Resetpos()
    {
        currentpos=0;
    }
    public Sprite GetImage(int indexofimage)
    {
        return BackgroundImages[indexofimage];
    }


}



// 允許創建單獨的節點資產
[CreateAssetMenu(fileName = "Node_", menuName = "Dialogue Node")]
public class DialogueNode : ScriptableObject
{
    public List<string> DialogueTexts=new List<string>();
    public DialogueNode NextNode; // 線性推進的下一個節點
    // 分支選項列表
    public List<DialogueOption> Options = new List<DialogueOption>();
}
[System.Serializable]
public class DialogueOption
{
    // 選項按鈕上顯示的文字
    public string OptionText;

    // 玩家選擇此選項後，要跳轉到的下一個節點的索引
    public DialogueNode TargetNode;
}
