using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    //ui script for text, plane and button
   
    public static UIManager instance;
    public Text crystal; 
    public Image[] live;
    public Sprite delet;
    public GameObject UIPlane, winPlane;
    
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
   

    public void Crystal()
    {
        crystal.text = "x" + Player.instance.crystal;

    }

    public void LoseLive()
    {
        if (Player.instance.livePlayer == 2)
        {
            live[0].GetComponent<Image>().sprite = delet;
        }

        if (Player.instance.livePlayer == 1)
        {
            live[1].GetComponent<Image>().sprite = delet;
        }

        if (Player.instance.livePlayer == 0)
        {
            live[2].GetComponent<Image>().sprite = delet;
        }
    }

    //set plane show or hide
    public void SetPlaneShow()
    {
        winPlane.SetActive(true);
        UIPlane.SetActive(false);

    }

    //reload scene
    public void ReplayLevel(string name)
    {
       
        SceneManager.LoadScene(name);
     
    }
}
