using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletinController : MonoBehaviour
{
    static bool oneWasSelected = false;

    public void display(){
        if(oneWasSelected == false)
        {
            gameObject.SetActive(true);
            oneWasSelected = true;
        }
    }
    public void hide(){
        gameObject.SetActive(false);
        oneWasSelected = false;
    }
}
