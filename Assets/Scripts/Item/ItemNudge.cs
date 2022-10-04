using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNudge : MonoBehaviour
{
    private WaitForSeconds pause;
    private bool isAnimaning = false;

    private void Awake()
    {
        pause= new WaitForSeconds(0.04f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isAnimaning == false)
        {
            if (gameObject.transform.position.x < col.transform.position.x)
            {
                StartCoroutine(RotateClock());
            }
            else
            {
                StartCoroutine(RotateAntiClock());
            }
        }
    }

    IEnumerator RotateClock()
    {
        isAnimaning = true;
        for (int i = 0; i < 8; i++)
        {
            transform.transform.Rotate(0f, 0f, 2f);
        }

        yield return pause;

        for (int i = 0; i < 9; i++)
        {
            transform.transform.Rotate(0f, 0f, -2f);
        }

        transform.transform.Rotate(0f, 0f, 2f);

        yield return pause;
        isAnimaning = false;
    }

    IEnumerator RotateAntiClock()
    {
        isAnimaning = true;
        for (int i = 0; i < 8; i++)
        {
            transform.transform.Rotate(0f, 0f, -2f);
        }

        yield return pause;

        for (int i = 0; i < 9; i++)
        {
            transform.transform.Rotate(0f, 0f, 2f);
        }

        yield return pause;
        transform.transform.Rotate(0f, 0f, -2f);

        isAnimaning = false;
    }
}