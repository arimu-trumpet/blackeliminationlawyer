using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            Barrier.BarrierHP -= 100;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            PlayerController.hp -= 50;
            Destroy(this.gameObject);
        }

    }
}
