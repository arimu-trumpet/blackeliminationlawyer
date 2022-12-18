using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("追いかける対象")]
    private GameObject player;
    private NavMeshAgent agent;
    public static int EnemyHP = 100;
    public int MaxEnemyHP = 100;
    public GameObject bullet;
    public float timer = 1f;
    [SerializeField]
    private float NearAttackTimer = 0f;
    [SerializeField]
    private GameObject EnemyHPUI;
    private Slider EnemyhpSlider;
    [SerializeField]
    private GameObject NearAttack;
    [SerializeField]
    private GameObject Warning;
    // Start is called before the first frame update
    void Start()
    {
        // NavMeshAgentを保持しておく
        agent = GetComponent<NavMeshAgent>();
        EnemyhpSlider = EnemyHPUI.transform.Find("EnemyHPBar").GetComponent<Slider>();
        EnemyhpSlider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = player.transform.position;
        Vector3 Enemypos = this.gameObject.transform.position;
        float dis = Vector3.Distance(Enemypos, playerpos);
        SetHp(EnemyHP);

        if (EnemyHP >= 0)
        {
            // プレイヤーを目指して進む
            agent.destination = player.transform.position;
        }
        if (EnemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
        if (dis <= 50)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameObject Bullet = Instantiate(bullet, this.gameObject.transform.position + this.transform.forward, Quaternion.identity);
                timer = 1f;
            }
        }
        if (dis <= 4.5)
        {
            NearAttackTimer -= Time.deltaTime;
            if (NearAttackTimer <= 0f)
            {
                StartCoroutine(nameof(WaringtoAttack));
                NearAttackTimer = 5f;
            }
        }

    }
    IEnumerator WaringtoAttack()
    {
        var Warningofchild = Instantiate(Warning, this.gameObject.transform.position + this.transform.forward, Quaternion.identity);
        Warningofchild.transform.SetParent(this.gameObject.transform);
        yield return new WaitForSeconds(1.5f);
        Destroy(Warningofchild);
        yield return new WaitForSeconds(0.05f);
        GameObject Near_Attack = Instantiate(NearAttack, this.gameObject.transform.position + this.transform.forward, Quaternion.identity);
        Near_Attack.transform.SetParent(this.gameObject.transform);
        yield return new WaitForSeconds(1.5f);
        Destroy(Near_Attack);
        NearAttackTimer = 5f;
    }
    public void SetHp(int _hp)
    {
        EnemyHP = _hp;

        //　HP表示用UIのアップデート
        UpdateHPValue();

        if (_hp <= 0)
        {
            //　HP表示用UIを非表示にする
            HideStatusUI();
        }
    }
    public int GetHp()
    {
        return EnemyHP;
    }
    public int GetMaxHp()
    {
        return MaxEnemyHP;
    }
    public void UpdateHPValue()
    {
        EnemyhpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }
    public void HideStatusUI()
    {
        EnemyHPUI.SetActive(false);
    }
}