using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Herbier : MonoBehaviour
{
    public GameObject herbier, inventaire, carte;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenHerbier()
    {
        
        inventaire.gameObject.SetActive(true);
        herbier.gameObject.SetActive(true);
       
    }
    public void CloseHerbier()
    {
        carte.gameObject.SetActive(false);
        inventaire.gameObject.SetActive(false);
        herbier.gameObject.SetActive(false);
    }
    public void OpenCarte()
    {
        carte.gameObject.SetActive(true);
    }
    public void CloseCarte()
    {
        carte.gameObject.SetActive(false);
    }

}
