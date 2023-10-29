using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gm;
    public int playcout = 0;
    public List<Toggle> toggles;
    public Toggle[] Group1toggles;
    public Toggle[] Group2toggles;
    public Toggle[] Group3toggles;
    public Toggle[] Group4toggles;
    public List<Toggle> selectedtoggles = new List<Toggle>();
    bool right;
    bool wrong;
    public Image[] LIFEARRAY;
    int lifecount = 3;
    public GameObject[] groupbox;
    string currentboxtag;
    public Transform[] Spawnpoints;
    List<String>[] words = new List<string>[4];
    public Transform canvas;
    int currentspawnpoint = 0;
    public GameObject SCOREPANEL;
    int score;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI endscoretext;
    List<String> TAKENTAGLIST = new List<string>();
    




    private void Awake()
    {

    }

    void Start()
    {
        words[0] = new List<string> { "DEN", "HIVE", "LAIR", "NEST", };                              //GROUP1
        words[1] = new List<string> { "CLOUD", "METAVERSE", "NET", "WEB", };                         //GROUP2
        words[2] = new List<string> { "EQUAL", "EVEN", "FAIR", "JUST", };                            //GROUP3
        words[3] = new List<string> { "GOOD", "IMPOSSIBLE", "NOTHING", "WARREN" };       //GROUP4

        Assigntoggletext();

        Invoke("shuffletoggles", 0.1f);




    }
    public void Assigntoggletext()
    {
        for (int i = 0; i < Group1toggles.Length; i++)
        {
            Group1toggles[i].GetComponentInChildren<TextMeshProUGUI>().text = words[0][i];
        }
        for (int i = 0; i < Group2toggles.Length; i++)
        {
            Group2toggles[i].GetComponentInChildren<TextMeshProUGUI>().text = words[1][i];
        }
        for (int i = 0; i < Group3toggles.Length; i++)
        {
            Group3toggles[i].GetComponentInChildren<TextMeshProUGUI>().text = words[2][i];
        }
        for (int i = 0; i < Group4toggles.Length; i++)
        {
            Group4toggles[i].GetComponentInChildren<TextMeshProUGUI>().text = words[3][i];
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void onbuttonpress()
    {
        if (playcout < 4)
        {

            Toggle curentselectedtoggle = EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>();
            if (curentselectedtoggle != null)
            {
                if (curentselectedtoggle.isOn)
                {
                    playcout++;
                    //Debug.Log("playcount" + playcout);
                    CheckWinandLose(curentselectedtoggle.tag, curentselectedtoggle);

                }
                if (!curentselectedtoggle.isOn)
                {
                    playcout--;
                    //Debug.Log("playcount" + playcout);
                    selectedtoggles.RemoveAt(selectedtoggles.Count - 1);
                    //Debug.Log("slctdtogglecount="+selectedtoggles.Count);

                }

                if (playcout == 4)
                {

                    foreach (Toggle toggle in toggles)
                    {

                        toggle.interactable = false;

                    }
                }
            }
        }


    }

    public void OnSubmit()
    {

        if (right)
        {

            foreach (Toggle toggle in selectedtoggles)
            {
                Destroy(toggle.gameObject);
                if (toggles.Contains(toggle))
                {
                    toggles.Remove(toggle);


                }

            }
            playcout = 0;
            score += 25;
            scoretext.text = "Score: " + score;
            selectedtoggles.Clear();
            //Debug.Log("count=" + selectedtoggles.Count);
            right = false;
            combinedfunction();

        }
        if (wrong && lifecount >= 0)
        {


            Destroy(LIFEARRAY[lifecount].gameObject);
            lifecount--;
            Deselectbutton();
            wrong = false;
        }
        if (lifecount < 0)
        {
            if (currentspawnpoint != Spawnpoints.Length)
            {

            }

            StartCoroutine(Gameover());
        }
    }

    public void CheckWinandLose(string currentag, Toggle currenttoggle)
    {
        selectedtoggles.Add(currenttoggle);

        if (selectedtoggles.Count == 4)
        {

            if (selectedtoggles[0].tag == currentag && selectedtoggles[1].tag == currentag && selectedtoggles[2].tag == currentag && selectedtoggles[3].tag == currentag)
            {
                currentboxtag = currentag;
                right = true;


            }
            else
            {

                wrong = true;
            }
        }

    }
    public void CheckGroupbox()
    {
        foreach (GameObject box in groupbox)
        {
            if (box.tag == currentboxtag)
            {
                if (currentspawnpoint <= Spawnpoints.Length)
                {
                    Transform currentpoint = Spawnpoints[currentspawnpoint];
                    GameObject Box = Instantiate(box, currentpoint.position, Quaternion.identity);
                    Box.transform.SetParent(canvas);
                    Box.transform.localScale = new Vector3(7.7f, 6.9f, 1.0f);
                    currentspawnpoint++;
                    TAKENTAGLIST.Add(currentboxtag);
                    Debug.Log(currentspawnpoint);


                    break;
                }
            }
        }
        Deselectbutton();

    }
    public void shuffletoggles()
    {



        System.Random RNG = new System.Random();
        List<Toggle> togglescopy = new List<Toggle>(toggles);
        int n = togglescopy.Count;
        while (n > 1)
        {
            n--;
            int k = RNG.Next(n + 1);


            Transform kTransform = togglescopy[k].transform;
            Transform nTransform = togglescopy[n].transform;
            Vector3 tempPosition = kTransform.localPosition;
            kTransform.localPosition = nTransform.localPosition;
            nTransform.localPosition = tempPosition;




        }




    }
    public void Deselectbutton()
    {
        playcout = 0;

        foreach (Toggle TOGGLE in toggles)
        {
            TOGGLE.isOn = false;
            TOGGLE.interactable = true;
            selectedtoggles.Clear();

        }
    }
    IEnumerator Gameover()
    {
        Debug.Log("infirst" + currentspawnpoint);


        foreach (GameObject eachgroup in groupbox)
        {
            if (!TAKENTAGLIST.Contains(eachgroup.tag))
            {
                Debug.Log("current" + currentspawnpoint);
                Transform currentpoint = Spawnpoints[currentspawnpoint];
                GameObject Box = Instantiate(eachgroup, currentpoint.position, Quaternion.identity);
                Box.transform.SetParent(canvas);
                Box.transform.localScale = new Vector3(7.7f, 6.9f, 1.0f);
                TAKENTAGLIST.Add(eachgroup.tag);
                Debug.Log("iwwwt" + currentspawnpoint);
                yield return new WaitForSeconds(1f);
                currentspawnpoint++;

            }

        }
        currentspawnpoint++;



        Invoke("Setgameoverpanel", 1f);



    }
    public void Setgameoverpanel()
    {
        GameObject scorepanel = Instantiate(SCOREPANEL,canvas.position,Quaternion.identity);
        scorepanel.transform.SetParent(canvas);
        scorepanel.transform.localScale = new Vector3(1f, 1f, 1f);

            


        endscoretext.text = "SCORE: " + score;
    }
    public void combinedfunction()
    {
        CheckGroupbox();
        shuffletoggles();
    } }
    

   