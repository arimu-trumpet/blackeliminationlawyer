using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    Vector3 Distance;
    GameObject Player;
    [SerializeField] GameObject HeartObject;
    float timer = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        { 
            StartCoroutine(nameof(Heal));
            timer += 20f;
        }
    }
    IEnumerator Heal()
    {
        Player = GameObject.Find("Player");
        Distance = new Vector3(Player.transform.position.x + Random.Range(10, 21), Player.transform.position.y, Player.transform.position.z + Random.Range(30, 51));
        GameObject Heart_Object = Instantiate(HeartObject, Distance, Quaternion.identity);
        yield return new WaitForSeconds(11f);
        Destroy(Heart_Object);
    }

}
