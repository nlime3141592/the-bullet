//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DieParticle : MonoBehaviour
//{
//    void Start()
//    {
//        float px = Random.Range(-4f, 4f);
//        float py = Random.Range(2f, 10f);
//        float pz = Random.Range(-4f, 4f);

//        GetComponent<MeshRenderer>().material = new DataGet().Get_OneNowThemeMaterial(CustomVariable.PlayerDieParticle);

//        transform.localScale *= 0.5f;

//        tag = "Particle";

//        GetComponent<Rigidbody>().AddForce(new Vector3(px, py, pz), ForceMode.Impulse);
//    }

//    public void OnCollisionEnter(Collision collision)
//    {
//        Destroy(gameObject);
//    }
//}
