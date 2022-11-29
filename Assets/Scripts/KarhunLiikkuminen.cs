using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarhunLiikkuminen : MonoBehaviour
{
    public GameObject m_lakkaprefab;

    [SerializeField]
    float m_karhunNopeus = 200f;
    [SerializeField]
    float m_karhunkaantyminen = 200f;

    Rigidbody m_karhunliikkuminen;

    float m_xakseli = 0f;
    float m_yakseli = 0f;

    [SerializeField]
    int kaikkipisteet = 0;

    [SerializeField]
    int kaikkimarjat = 0;

    [SerializeField]
    int kaikkisienet = 0;

    [SerializeField]
    float aikapisteet = 0f;

    // Start is called before the first frame update
    void Start()
    {
       m_karhunliikkuminen = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y"))
            {
            GameObject luotulakka = (GameObject)Instantiate(m_lakkaprefab);
            Vector3 lakanpaikkakarhunetupuolella = transform.position+(transform.forward*5f);

            RaycastHit rh = new RaycastHit();
            Vector3 raynalkupiste = lakanpaikkakarhunetupuolella + (Vector3.up*100f);
            if ( Physics,Raycast( raynalkupiste, Vector3.down, out rh, 300f ))
                {
                    lakanpaikkakarhunetupuolella = rh.point;
                }

            luotulakka.transform.position = lakanpaikkakarhunetupuolella;
            }
            
        if (Input.GetKeyDown("q"))
        {
            kaikkimarjat = kaikkimarjat+1;
        }
        if (Input.GetKeyDown("e"))
        {
            kaikkisienet += 1;
        }
        if ( Input.GetKeyDown("r"))
        {
            aikapisteet = 3.7f;
        }
        kaikkipisteet = kaikkisienet + kaikkimarjat;
        kaikkipisteet = kaikkipisteet + (int)aikapisteet;

        m_xakseli = Input.GetAxis("Horizontal");
        m_yakseli = Input.GetAxis("Vertical");

    }
    void FixedUpdate()
    {
        m_karhunliikkuminen.AddRelativeForce( Vector3.forward*m_yakseli*m_karhunNopeus);
        m_karhunliikkuminen.AddRelativeTorque( Vector3.up*m_xakseli*m_karhunkaantyminen);
    }
}
