using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float timer = 2f;
    public Vector3 direction;
    public float speed = 40f;
    // Start is called before the first frame update
    void Start()
    {
        direction = (GameObject.Find("Player").transform.position - this.gameObject.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(this.gameObject);
            timer += 2f;
        }
        this.transform.position += direction * speed * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            PlayerController.hp -= 20;
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Barrier")
        {
            Barrier.BarrierHP -= 50;
            Destroy(this.gameObject);
        }
    }
}
