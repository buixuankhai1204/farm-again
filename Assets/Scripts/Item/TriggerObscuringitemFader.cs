using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObscuringitemFader : MonoBehaviour
{
    // Start is called before the first frame update
    private ObscuringItemFader[] obscuringItemFader;
    private void OnTriggerEnter2D(Collider2D col)
    {
        obscuringItemFader = col.GetComponents<ObscuringItemFader>();

        if (obscuringItemFader.Length > 0)
        {
            for (int i = 0; i < obscuringItemFader.Length; i++)
            {
                obscuringItemFader[i].FadeOut();
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        obscuringItemFader = col.GetComponents<ObscuringItemFader>();

        if (obscuringItemFader.Length > 0)
        {
            for (int i = 0; i < obscuringItemFader.Length; i++)
            {
                obscuringItemFader[i].FadeIn();
            }
        }
    }
}
