using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float BulletTimer = 0.6f;
    public int ACount = 0;
    public int DCount = 0;
    public int WCount = 0;
    public int SCount = 0;
    public float timer = 0f;
    [SerializeField] float NearAttacktimer = 0f;
    public GameObject Barrier;
    public GameObject panel;
    public static int Maxhp = 100;
    static public int hp = Maxhp;
    public GameObject bullet;
    [SerializeField] private GameObject playerHPUI;
    private Slider playerhpSlider;
    [SerializeField] private GameObject HeartObject;
    public enum PlayerState
    {
        ATTACK,//攻撃中
        DEFENCE,//防御中
        NOTHING,//何もしていない
        ESCAPE,//逃走中
    }
    private PlayerState playerState;
    public int speed = 10;
    // x軸方向の移動範囲の最小値
    [SerializeField] private float _minX;

    // x軸方向の移動範囲の最大値
    [SerializeField] private float _maxX;

    // z軸方向の移動範囲の最小値
    [SerializeField] private float _minZ;

    // z軸方向の移動範囲の最大値
    [SerializeField] private float _maxZ;
    [SerializeField] private GameObject NearAttack;
    // Start is called before the first frame update
    void Start()
    {
        playerhpSlider = playerHPUI.transform.Find("HPBar").GetComponent<Slider>();
        playerhpSlider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -2)
        {
            this.transform.position = new Vector3(470, 0, 525);
        }
        SetHp(hp);
        if (hp > 0)
        {
            if (BulletTimer >= 0)
            {
                BulletTimer -= Time.deltaTime;
            }
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            if (NearAttacktimer >= 0)
            {
                NearAttacktimer -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                var pos = new Vector3(Mathf.Clamp(this.transform.position.x + (transform.forward * speed * Time.deltaTime).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp(this.transform.position.z + (transform.forward * speed * Time.deltaTime).z, _minZ, _maxZ)));
                this.transform.position = pos;
                playerState = PlayerState.ESCAPE;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (WCount <= 0)
                {
                    WCount = 30;
                }
                else
                {
                    var pos = new Vector3(Mathf.Clamp((this.transform.position += transform.forward * 3).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp((this.transform.position += transform.forward * 3).z, _minZ, _maxZ)));
                    this.transform.position = pos;
                    playerState = PlayerState.ESCAPE;
                }
            }
            if (WCount > 0)
            {
                WCount--; // ←毎フレームごとにカウンターを減らす
            }
            if (Input.GetKey(KeyCode.A))
            {
                var pos = new Vector3(Mathf.Clamp(this.transform.position.x + (-transform.right * speed * Time.deltaTime).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp(this.transform.position.z + (-transform.right * speed * Time.deltaTime).z, _minZ, _maxZ)));
                this.transform.position = pos;
                playerState = PlayerState.ESCAPE;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (ACount <= 0)
                {
                    ACount = 30;
                }
                else
                {
                    var pos = new Vector3(Mathf.Clamp((this.transform.position += -transform.right * 3).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp((this.transform.position += -transform.right * 3).z, _minZ, _maxZ)));
                    this.transform.position = pos;
                    playerState = PlayerState.ESCAPE;
                }

            }
            if (ACount > 0)
            {
                ACount--; // ←毎フレームごとにカウンターを減らす
            }
            if (Input.GetKey(KeyCode.S))
            {
                var pos = new Vector3(Mathf.Clamp(this.transform.position.x + (-transform.forward * speed * Time.deltaTime).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp(this.transform.position.z + (-transform.forward * speed * Time.deltaTime).z, _minZ, _maxZ)));
                this.transform.position = pos;
                playerState = PlayerState.ESCAPE;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (SCount <= 0)
                {
                    SCount = 30;
                }
                else
                {
                    var pos = new Vector3(Mathf.Clamp((this.transform.position += -transform.forward * 3).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp((this.transform.position += -transform.forward * 3).z, _minZ, _maxZ)));
                    this.transform.position = pos;
                    playerState = PlayerState.ESCAPE;
                }

            }
            if (SCount > 0)
            {
                SCount--; // ←毎フレームごとにカウンターを減らす
            }
            if (Input.GetKey(KeyCode.D))
            {
                var pos = new Vector3(Mathf.Clamp(this.transform.position.x + (transform.right * speed * Time.deltaTime).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp(this.transform.position.z + (transform.right * speed * Time.deltaTime).z, _minZ, _maxZ)));
                this.transform.position = pos;
                playerState = PlayerState.ESCAPE;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (DCount <= 0)
                {
                    DCount = 30;
                }
                else
                {
                    var pos = new Vector3(Mathf.Clamp((this.transform.position += transform.right * 3).x, _minX, _maxX), this.transform.position.y, (Mathf.Clamp((this.transform.position += transform.right * 3).z, _minZ, _maxZ)));
                    this.transform.position = pos;
                    playerState = PlayerState.ESCAPE;
                }

            }
            if (DCount > 0)
            {
                DCount--; // ←毎フレームごとにカウンターを減らす
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.eulerAngles += new Vector3(0f, -120f * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.eulerAngles += new Vector3(0f, 120f * Time.deltaTime, 0);
            }

            if (this.transform.position.y <= -3)
            {
                this.transform.position = new Vector3(450, 10, 560);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (BulletTimer <= 0f)
                {
                    GameObject Bullet = Instantiate(bullet, this.gameObject.transform.position + this.transform.forward, Quaternion.identity);
                    playerState = PlayerState.ATTACK;
                    BulletTimer = 0.6f;
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (timer <= 0f)
                {
                    Barrier.GetComponent<Barrier>().player = this.gameObject;
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    GameObject realbarrier = Instantiate(Barrier, this.gameObject.transform.position, Quaternion.identity);
                    realbarrier.transform.SetParent(this.gameObject.transform);
                    timer += 20;
                    playerState = PlayerState.DEFENCE;
                }

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (NearAttacktimer <= 0f)
                {
                    StartCoroutine(nameof(NearAttackmaker));
                    NearAttacktimer += 7;
                }
            }


        }
        if (hp <= 0)
        {
            panel.SetActive(true);
        }
    }
    public void SetHp(int _hp)
    {
        hp = _hp;

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
        return hp;
    }
    public int GetMaxHp()
    {
        return Maxhp;
    }
    public void UpdateHPValue()
    {
        playerhpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }
    public void HideStatusUI()
    {
        playerHPUI.SetActive(false);
    }
    IEnumerator NearAttackmaker()
    {
        GameObject Near_Attack = Instantiate(NearAttack, this.gameObject.transform.position + this.transform.forward, Quaternion.identity);
        Near_Attack.transform.SetParent(this.gameObject.transform);
        yield return new WaitForSeconds(0.7f);
        Destroy(Near_Attack);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Heart")
        {
            hp += 20;
            Destroy(other.gameObject);
        }
    }

}

