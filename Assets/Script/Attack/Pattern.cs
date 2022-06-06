using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public GameObject Player;

    public Transform Boss;

    public GameObject Bullet;

    float timer;
    int wait;
    // public GameObject CicleShot_goto_shot;
    void Start()
    {
        Player=GameObject.FindWithTag("Player");
        timer= 0F;
        wait=5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > wait)
        {
            int a=Random.Range(0,3);
            print(a);
            if (a==0)
            {
                Circleshot();
                Circle_goto_shot();
                timer=0;
            }
            if (a==1)
            {
                heart_shot();
                timer=0;
            }
            if (a==2)
            {
                Target_goto_Shot();
                Invoke("Target_goto_Shot",0.5f);
                Invoke("Target_goto_Shot",1);
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
    public void Circle_goto_shot()
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

    public void heart_shot() 
    {
        //초기 중심 : 회전 되는 방향
        float rot = 0f;

        float[] speeds = new float[34];
        float[] dir = new float[34];
        HeartDataInit();
        Vector2 pos;
        pos = Boss.transform.position;
        //34개의 게임오브젝트 생성
        for (int i = 0; i < 34; i += 1)
        {
            //오브젝트 생성
            GameObject temp = Instantiate(Bullet);
            //2초후 삭제
            Destroy(temp, 10f);
            //총알 생성 위치를 (0,0) 좌표로 한다.
            temp.transform.position = pos;
            //정밀한 회전 처리로 모양을 만들어 낸다.
            temp.transform.rotation = Quaternion.Euler(0, 0, dir[i] + rot);
            //정밀한 속도 처리로 모양을 만들어 낸다.
            temp.GetComponent<Bullet_Move>().speed = (speeds[i] / 50)+10f;
        }

        void HeartDataInit()
        {
            speeds[0] = 111.00f;
            dir[0] = 90.00f;
            speeds[1] = 133.10f;
            dir[1] = 98.70f;
            speeds[2] = 152.04f;
            dir[2] = 107.37f;
            speeds[3] = 166.88f;
            dir[3] = 116.18f;
            speeds[4] = 176.00f;
            dir[4] = 125.28f;
            speeds[5] = 181.88f;
            dir[5] = 134.29f;
            speeds[6] = 181.50f;
            dir[6] = 143.31f;
            speeds[7] = 175.54f;
            dir[7] = 152.33f; 
            speeds[8] = 165.63f;
            dir[8] = 161.38f;
            speeds[9] = 151.50f;
            dir[9] = 170.43f;
            speeds[10] = 136.35f;
            dir[10] = 180.18f;
            speeds[11] = 120.40f;
            dir[11] = 190.90f;
            speeds[12] = 106.45f;
            dir[12] = 203.68f;
            speeds[13] = 98.56f;
            dir[13] = 219.22f;
            speeds[14] = 99.10f;
            dir[14] = 235.97f;
            speeds[15] = 107.97f;
            dir[15] = 251.19f;
            speeds[16] = 124.58f;
            dir[16] = 262.83f;
            speeds[17] = 133.10f;
            dir[17] = 81.30f;
            speeds[18] = 152.04f;
            dir[18] = 72.63f;
            speeds[19] = 166.88f;
            dir[19] = 63.82f;
            speeds[20] = 176.00f;
            dir[20] = 54.72f;
            speeds[21] = 181.88f;
            dir[21] = 45.71f;
            speeds[22] = 181.50f;
            dir[22] = 36.69f;
            speeds[23] = 175.54f;
            dir[23] = 27.67f;
            speeds[24] = 165.63f;
            dir[24] = 18.62f;
            speeds[25] = 151.50f;
            dir[25] = 9.57f;
            speeds[26] = 136.35f;
            dir[26] = 359.82f;
            speeds[27] = 120.40f;
            dir[27] = 349.10f;
            speeds[28] = 106.45f;
            dir[28] = 336.32f;
            speeds[29] = 98.56f;
            dir[29] = 320.78f;
            speeds[30] = 99.10f;
            dir[30] = 304.03f;
            speeds[31] = 107.97f;
            dir[31] = 288.81f;
            speeds[32] = 124.58f;
            dir[32] = 277.17f;
            speeds[33] = 147.85f;
            dir[33] = 270.05f;
        }
    }
    public void Target_goto_Shot ()
    {
        //방향 -> Center가 Target을 바라보고 있으므로, Rotation은 방향으로 처리함
        // public Transform Center;
        var bl = new List<Transform>();
        Vector2 pos;
        pos = Boss.transform.position;
        for (int i = 0; i < 10; i += 2)
        {
            var temp = Instantiate(Bullet);
            //총알 생성 위치를 머즐 입구로 한다.
            Destroy(temp, 10f);
            temp.transform.position = pos;
            bl.Add(temp.transform);
            //총알의 방향을 Center의 방향으로 한다.
            //->참조된 Center오브젝트가 Target을 바라보고 있으므로, Rotation이 방향이 됨.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
            temp.GetComponent<Bullet_Move>().speed = temp.GetComponent<Bullet_Move>().speed+10f;


        }
        StartCoroutine(BulletToTarget(bl));
    
        IEnumerator BulletToTarget(List<Transform> bl)
        {
            //0.5초 후에 시작
            yield return new WaitForSeconds(0);
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



