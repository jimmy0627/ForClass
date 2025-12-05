using System;
using System.Collections.Generic;
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
            return currentNode.DialogueTexts[currentpos++];
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log(e);
            return null;
        }
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
