using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TOGGLECONTROLLER : MonoBehaviour
{
    //// Start is called before the first frame update
    //public List<Toggle> toggles;
    //string[] words = new string[16];
    //public float shuffleduration = 0f;




    //void Start()
    //{

    //    words = new string[]{ "DEN", "HIVE", "LAIR", "NEST",                  //GROUP1
    //                        "CLOUD", "METAVERSE", "NET", "WEB",               //GROUP2
    //                        "EQUAL", "EVEN", "FAIR", "JUST",                  //GROUP3
    //                        "GOOD", "IMPOSSIBLE", "NOTHING", "WARREN"};       //GROUP4



    //    Assigntoggletext();






    //}
    //public void Assigntoggletext()
    //{

    //    for (int i = 0; i < toggles.Count; i++)
    //    {
    //        toggles[i].GetComponentInChildren<TextMeshProUGUI>().text = words[i];
    //    }
    //    shuffletoggles();

    //}
    //public void  shuffletoggles()
    //{

    //    if (GameManager.gm != null)
    //    {


    //        System.Random RNG = new System.Random();
    //        int n = GameManager.gm.toggles.Count;
    //        while (n > 1)
    //        {
    //            n--;
    //            int k = RNG.Next(n + 1);
    //            Vector3 temppos = GameManager.gm.toggles[k].transform.position;
    //            GameManager.gm.toggles[k].transform.position = GameManager.gm.toggles[n].transform.position;
    //            GameManager.gm.toggles[n].transform.position = temppos;

    //        }

    //    }
    //    else
    //    {
    //        Debug.Log("called");
    //    }

    //}
    //public void onshufflebuttonprss()
    //{
    //    shuffletoggles();
    //}

    //private void Update()
    //{

    //    if (GameManager.gm!= null && GameManager.gm.shuffle )
    //    {
    //        onshufflebuttonprss();
    //        GameManager.gm.shuffle = false;
    //    }
    //    if (GameManager.gm != null && GameManager.gm.deselect)
    //    {
    //        Deselectbutton();
    //        GameManager.gm.deselect = false;
    //    }
    //}
    //public void Deselectbutton()
    //{
    //    GameManager.gm.playcout = 0;

    //    foreach (Toggle TOGGLE in GameManager.gm.toggles)
    //    {
    //        TOGGLE.isOn = false;
    //        TOGGLE.interactable = true;
    //      GameManager.gm. selectedtoggles.Clear();

    //    }
    //}

    //public void RESIZEIMAG()
    //{
    //    //boximage.transform.localScale += Vector3.up *  imagescale;
    //    //////float currenthieght = boximage.rectTransform.rect.height;
    //    //////RectTransform RectTransform = boximage.rectTransform;
    //    ////float scale = currenthieght + imagescale;
    //    ////RectTransform.sizeDelta = new Vector2(RectTransform.sizeDelta.x, scale);
    //    ////Debug.Log(boximage.rectTransform.rect.height);
    //}
    //public void nuller()
    //{
    //    gm = this;

    //    foreach (GameObject point in spawnpoints)
    //    {
    //        point = null;
    //    }
    //}
}
