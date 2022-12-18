using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject player;
    public float timer;
    public static int BarrierHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        BarrierHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            BarrierHP -= 100;
            timer += 15f;
        }
        if (BarrierHP <= 0)
        {
            player.GetComponent<CapsuleCollider>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
