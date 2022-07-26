using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Sprite sp1, sp2;
    public GameObject setbut;
    public float col;
    public GameObject[] but;
    public Text[] text;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = setbut.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void visible()
    {
        this.gameObject.GetComponent<Image>().enabled = !this.gameObject.GetComponent<Image>().enabled;
        for (int i = 0; i < but.Length; i++)
        {
            but[i].GetComponent<Image>().enabled = !but[i].GetComponent<Image>().enabled;
            text[i].GetComponent<Text>().enabled = !text[i].GetComponent<Text>().enabled;
        }
        if (setbut.GetComponent<Image>().sprite == sp1)
        {
            setbut.GetComponent<Image>().color = new Color(col, col, col, 1f);
            setbut.GetComponent<Image>().sprite = sp2;
        }
        else
        {
            setbut.GetComponent<Image>().color = color;
            setbut.GetComponent<Image>().sprite = sp1;
        }
    }
}
