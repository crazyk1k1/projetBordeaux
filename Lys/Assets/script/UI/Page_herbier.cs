using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_herbier : MonoBehaviour
{
    
   // public GameObject _page_herbier;
    [SerializeField]
    private GameObject[] page_herbier;
    public int IDpage;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
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
