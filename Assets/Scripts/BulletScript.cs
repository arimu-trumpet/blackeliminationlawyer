using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float timer = 3f;
    public Vector3 direction;
    public GameObject player;
    public float speed = 60f;
    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.Find("Player").transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        timer -=  Time.deltaTime;
        this.transform.position += direction * speed * Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(this.gameObject);
            timer += 3f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            EnemyController.EnemyHP -= 20;
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

    }
}
