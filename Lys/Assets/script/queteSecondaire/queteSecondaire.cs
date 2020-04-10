using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queteSecondaire : MonoBehaviour
{

    public enum jeu { course, cacheCache, Soleil, cabanne, labyrinthe, loupToucheTouche}; //sert uniquement a se reperer
    public jeu minijeu;

    public bool activeQuest = false;
    public bool endQuest = false;

    public void ActiveQuest()//demarre la quete
    {
        if(endQuest == false)
        {
            activeQuest = true;
        }
        
    }
    public void DesactiveQuest()//stop la quete
    {
        activeQuest = false;
    }

    public void EndQuest()//termine la quete et ne peut plus la rejouer
    {
        endQuest = true;
    }
}
