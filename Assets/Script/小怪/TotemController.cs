using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class TotemController : MonoBehaviour
{
    float TopAttackCD = 3f;
    float MiddleAttackCD = 9f;
    float BottomAtttackCD = 6f;
    float time=0f;
    float top, middle, bottom;
    float CD = 10f;
    float x,y;
    public GameObject bulletPrefab; // 子彈 Prefab
    public GameObject bulletPrefabR;
    GameObject TotemTop;
    GameObject TotemBottom;
    GameObject TotemMiddle;
    Animator TotemTopAnimator;
    Animator TotemMiddleAnimator;
    Animator TotemBottomAnimator;
        
    void Start()
    {
        TotemTop = GameObject.Find("Top");
        TotemMiddle = GameObject.Find("Middle");
        TotemBottom = GameObject.Find("Bottom");
        TotemTopAnimator = TotemTop.GetComponent<Animator>();
        TotemMiddleAnimator = TotemMiddle.GetComponent<Animator>();
        TotemBottomAnimator = TotemBottom.GetComponent<Animator>();
        top = TopAttackCD + 0.4f;
        middle = MiddleAttackCD + 0.5f;
        bottom = BottomAtttackCD + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log("time"+time);
        if (time > TopAttackCD)
        {
            x = TotemTop.transform.position.x;
            y = TotemTop.transform.position.y;
            TotemTopAnimator.SetTrigger("Attack");
            TopAttackCD = CD;

        }
        if (time > top)
        {
            top = 10f;
            FireBullet(new Vector2(x, y - 0.5f));
        }
        if (time > MiddleAttackCD)
        {
            x = TotemMiddle.transform.position.x;
            y = TotemMiddle.transform.position.y;
            TotemMiddleAnimator.SetTrigger("Attack");
            TopAttackCD = 3f;
            BottomAtttackCD = 6f;
            top = TopAttackCD + 0.5f;
            bottom = BottomAtttackCD + 0.5f;
            time = 0f;
            GameObject bullet = Instantiate(bulletPrefabR, new Vector2(x, y - 0.5f), Quaternion.identity); ;

        }
        if (time > BottomAtttackCD)
        {
            x = TotemBottom.transform.position.x;
            y = TotemBottom.transform.position.y;
            TotemBottomAnimator.SetTrigger("Attack");
            BottomAtttackCD = CD;
            
        }
        if (time > bottom)
        {
            bottom = 10f;
            FireBullet(new Vector2(x, y - 0.5f));
        }
    }
    void FireBullet(Vector2 pos)
    {
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("發生碰撞");
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
            Debug.Log("攻擊敵人");
        }
    }
}
