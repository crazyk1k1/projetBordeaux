using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Herbier : MonoBehaviour
{
    
    public GameObject carte;
    [SerializeField]
    public GameObject Panel;
    
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
        carte.gameObject.SetActive(true);
        
       
    }
    public void CloseHerbier()
    {
        carte.gameObject.SetActive(false);
    }
}
