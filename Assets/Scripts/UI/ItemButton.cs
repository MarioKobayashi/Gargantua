using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテムボタンのON、OFFを管理するコンポーネント
public class ItemButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panel = null;

    [SerializeField]
    private GameObject BackButton = null;

    [SerializeField]
    private GameObject ItemList = null;

    CameraCon came;

    //アイテムボタンON
    public void ItemButtonOn()
    {

        if (came == null)
        {
            //この記述で最初の一度だけこの処理を行える
            came = GameObject.Find("MainCamera").GetComponent<CameraCon>();
        }
        //カメラシェイクが入っている時cameraConがfalseになっているので強制的にtrueにする
        came.enabled = true;
        came.ZoomIn(64, 0.2f);

       
        panel.SetActive(true);
        BackButton.SetActive(true);
        //アイテムリストのグリッドレイアウトが最初のフレームで座標がずれるので1フレーム遅延させて表示させる
        StartCoroutine(AdjustTransInTheEndOfFrame());
    }

    //アイテムボタンOFF
    public void ItemButtonOFF()
    {
        if(came == null)
        {
            came = GameObject.Find("MainCamera").GetComponent<CameraCon>();
        }
        panel.SetActive(false);
        BackButton.SetActive(false);
        ItemList.SetActive(false);
        came.ZoomOut();
        
    }

    private IEnumerator AdjustTransInTheEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        ItemList.SetActive(true);
    }
}
