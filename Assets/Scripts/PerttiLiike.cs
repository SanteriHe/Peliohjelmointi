using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerttiLiike : MonoBehaviour
{

    CharacterController perttikontrolleri;
    Animation perttianimaatiot;

    Vector3 pelaajanmaanvetovoima;
    float maanvetovoima = -9.81f;
    float hyppyvoima = 1.0f;
    bool pelaajaonmaassa;

    // Start is called before the first frame update
    void Start()
    {
        perttikontrolleri = GetComponent<CharacterController>();
        perttianimaatiot = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float sivuttaisliike = Input.GetAxis("Horizontal");
        transform.Rotate( 0f, sivuttaisliike*0.2f, 0f );


        pelaajaonmaassa = perttikontrolleri.isGrounded;
        if ( pelaajaonmaassa && pelaajanmaanvetovoima.y < 0 )
            {
                pelaajanmaanvetovoima.y = 0f;
            }
        float eteenpainliike = Input.GetAxis("Vertical");

        if ( eteenpainliike == 0f )
        {
        perttianimaatiot.Play("Hengailu1");
        }
        else
        {
        perttianimaatiot.Play("Juoksu");
        }

       // transform.position = transform.position+(transform.forward*0.01f*eteenpainliike);
       perttikontrolleri.Move(transform.forward*0.01f*eteenpainliike);

       if ( Input.GetButtonDown("Jump"))
       {
        pelaajanmaanvetovoima.y = Mathf.Sqrt( hyppyvoima * -3.0f * maanvetovoima );
       }

       pelaajanmaanvetovoima.y += maanvetovoima*Time.deltaTime;
       perttikontrolleri.Move( pelaajanmaanvetovoima*Time.deltaTime );
    }
}
