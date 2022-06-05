using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public Transform Player;

    public Transform Boss;

    public GameObject Bullet;

    float timer;
    int wait;
    // public GameObject CicleShot_goto_shot;
    void Start()
    {
        timer= 0F;
        wait=3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        print(timer);
        if (timer > wait)
        {
            int a=Random.Range(0,10);
            print(a);
            if (a==0)
            {
                Circleshot();
                Circle_goto_shot();
                timer=0;
            }
        }
    }

    public void Circleshot()
    {
        Vector2 pos;
        pos = Boss.transform.position;
        //360번 반복
        for (int i = 0; i < 360; i += 13)
        {
            //총알 생성
            GameObject temp = Instantiate(Bullet);

            //2초마다 삭제
            Destroy(temp, 10f);

            //총알 생성 위치를 (0,0) 좌표로 한다.
            temp.transform.position = pos;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }
    void Circle_goto_shot()
    {
        Vector2 pos;
        pos = Boss.transform.position;
        //Target방향으로 발사될 오브젝트 수록
        var bl = new List<Transform>();
            for (int i = 0; i < 360; i += 13)
            {
                //총알 생성
                var temp = Instantiate(Bullet);
                //2초후 삭제
                Destroy(temp, 10f);
                //총알 생성 위치를 (0,0) 좌표로 한다.
                temp.transform.position = pos;
                //?초후에 Target에게 날아갈 오브젝트 수록
                bl.Add(temp.transform);
                //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
                temp.transform.rotation = Quaternion.Euler(0, 0, i);
            }
            //총알을 Target 방향으로 이동시킨다.
            StartCoroutine(BulletToTarget(bl));
    
        IEnumerator BulletToTarget(List<Transform> bl)
        {
            //0.5초 후에 시작
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < bl.Count; i++)
            {
                //현재 총알의 위치에서 플레이의 위치의 벡터값을 뻴셈하여 방향을 구함
                var target_dir = Player.transform.position - bl[i].position;
                //x,y의 값을 조합하여 Z방향 값으로 변형함. -> ~도 단위로 변형
                var angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;
                //Target 방향으로 이동
                bl[i].rotation = Quaternion.Euler(0, 0, angle);
            }
            //데이터 해제
            bl.Clear();
        }
    }
}



