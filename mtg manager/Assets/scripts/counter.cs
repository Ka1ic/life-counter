using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class counter : MonoBehaviour
{
    public string nameOfAnimation;
    public Animator animator;
    public int lifeTotal = 20;
    public TMP_Text t;
    public TMP_Text ValueExchaged;
    int waitSet;
    int waitSet1;
    // Start is called before the first frame update
    private void Awake()
    {
        lifeTotal = DataHolder.numLifes;
    }

    void Start()
    {
        Color color = ValueExchaged.color;
        color.a = 0;
        ValueExchaged.color = color;
        t.text = "" + lifeTotal;
    }
     public void plusTap()
    {
        StopCoroutine("Visible");
        if(ValueExchaged.color.a <= 0)
        {
            animator.Play(nameOfAnimation);
        }
        waitSet++;
        waitSet1++;
        if (waitSet1 > 0)
        {
            ValueExchaged.text = "+" + waitSet1;
        }
        else
        {
            ValueExchaged.text = "" + waitSet1;
        }
        lifeTotal++;
        t.text = "" + lifeTotal;
        StartCoroutine("Visible");
    }

    public void SubtractTap()
    {
        StopCoroutine("Visible");
        if (ValueExchaged.color.a <= 0)
        {
            animator.Play(nameOfAnimation);
        }
        waitSet--;
        waitSet1--;
        if (waitSet1 > 0)
        {
            ValueExchaged.text = "+" + waitSet1;
        }
        else
        {
            ValueExchaged.text = "" + waitSet1;
        }
        lifeTotal--;
        t.text = "" + lifeTotal;
        StartCoroutine("Visible");
    }

    public IEnumerator pinchingSubtract()
    {
        while(true)
        {
            //waitSet--;
            if (waitSet >= -4)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else if (waitSet >= -14)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                yield return new WaitForSeconds(0.06f);
            }
            SubtractTap();
            //print("in procces");
        }
    }

    public IEnumerator pinchingPlus()
    {
        while (true)
        {
            //waitSet++;
            if (waitSet <= 4)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else if (waitSet <= 14)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                yield return new WaitForSeconds(0.06f);
            }
            plusTap();
            //print("in procces");
        }
    }

    public void startPinchingSubtract()
    {
        StartCoroutine("pinchingSubtract");
    }

    public void startPinchingPlus()
    {
        StartCoroutine("pinchingPlus");
    }
    
    public void buttonUp(string nameOfCoroutine)
    {
        StopCoroutine(nameOfCoroutine);
        waitSet = 0;
    }

    public IEnumerator Visible()
    {
        for(float i = ValueExchaged.color.a; i <= 1; i+= 0.1f)
        {
            Color color = ValueExchaged.color;
            color.a = i;
            ValueExchaged.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        for (float i = ValueExchaged.color.a; i >= -0.05f; i -= 0.05f)
        {
            Color color = ValueExchaged.color;
            color.a = i;
            ValueExchaged.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        waitSet1 = 0;
    }
}
