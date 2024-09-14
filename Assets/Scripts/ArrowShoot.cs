using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 12.0f;
    public float shootDelay = 0.25f;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    bool inAttack = false; //공격 중 여부
    GameObject bowObj;

    void Start()
    {
        //활을 플레이어 캐릭터에 배치
        Vector3 pos = transform.position;
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("Fire3")))
        {//공격키가 눌림
            Attack();
        }
        //활의 회전과 우선순위
        float bowZ = -1; //활의 Z 값 (캐릭터보다 앞으로 설정)
        PlayerController plmv = GetComponent<PlayerController>();
        if (plmv.angleZ > 30 && plmv.angleZ < 150)
        {
            //위 방향
            bowZ = 1; //활의 Z 값 (캐릭터보다 뒤로 설정)
        }
        //활의 회전
        bowObj.transform.rotation = Quaternion.Euler(0, 0, plmv.angleZ);
        //활의 우선순위
        bowObj.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }
    //공격
    public void Attack()
    {

        //호ㅓㅏ살을 가지고 있음 & 공격 중이 아님
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows -= 1; //화살을 소모
            inAttack = true; //공격 중으로 설정
            //화살발사
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ; //회전 각도
            //화살의 게임 오브젝트 만들기(진행 방향으로 회전)
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);
            //화살을 발사할 벡터 생성
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector3 v = new Vector3(x, y) * shootSpeed;
            //화살에 힘을 가하기
            Rigidbody2D body = arrowObj.GetComponent<Rigidbody2D> ();
            body.AddForce (v,ForceMode2D.Impulse);
            //공격 중이 아님으로 설정
            Invoke("StopAttack", shootDelay);
        }
    }
    //공격 중지
    public void StopAttack()
    {
        inAttack = false; //공격 중이 아님으로 설정
    }



}
