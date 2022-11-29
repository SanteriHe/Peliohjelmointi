using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalloLiike : MonoBehaviour
{
    [SerializeField]
    bool testimuuttuja1;
    [SerializeField]
    int testimuuttuja2;
    [SerializeField]
    float testimuuttuja3;
    [SerializeField]
    string testimuuttuja4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown("y") )

            {

            Debug.Log("Nappi y painettu"); 

            Rigidbody fysiikka = GetComponent<Rigidbody>();

            fysiikka.AddForce( Vector3.up*400f );

            }
    }
}
