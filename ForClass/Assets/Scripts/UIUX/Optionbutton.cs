using UnityEngine;

public class Optionbutton : MonoBehaviour
{
    [SerializeField] private int optionid;
    public void optionclicked()
    {
        Transform backgroundTransform = transform.parent.parent; 

        Scripts_storge scriptsStorge = backgroundTransform.GetComponent<Scripts_storge>();

        ChangeText changeText = backgroundTransform.GetComponent<ChangeText>();
        
        // 檢查是否成功獲取組件
        if (scriptsStorge == null || changeText == null)
        {
            Debug.LogError("Optionbutton 無法在 Background 物件上找到 Scripts_storge 或 ChangeText 腳本，請檢查物件階層！");
            return;
        }

        DialogueNode temp = scriptsStorge.GetDialogueNode();
        
        Debug.Log(temp.Options[optionid].TargetNode.DialogueTexts);
        scriptsStorge.setcurrentnode(temp.Options[optionid].TargetNode);
        scriptsStorge.Resetpos();
        changeText.onclicktext();

        backgroundTransform.Find("OptionPanel").gameObject.SetActive(false);
    }
}
