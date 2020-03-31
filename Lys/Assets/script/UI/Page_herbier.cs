using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_herbier : MonoBehaviour
{
    
   // public GameObject _page_herbier;
    [SerializeField]
    public int IDpage;
    [SerializeField]
    private GameObject[] page_herbier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (IDpage)
            {
                case 0 :
                 Destroy(this.gameObject);
                  page_herbier[0].gameObject.SetActive(true);
                    break;
             }
           
        }
    }
}
