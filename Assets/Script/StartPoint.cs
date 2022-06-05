using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; // 이동되어온 맵이름을 체크하기 위한 변수
    private Player thePlayer; // 캐릭터 객체 가져오기 위한 변수
    Animator anim;

    // private CamaraManager theCamera; // 자연스러운 카메라 이동을 위해 가져온 카메라 변수

    // Start is called before the first frame update
    void Start()
    {
        // theCamera = FindObjectOfType<CamaraManager>(); // 카메라 변수에 카메라 객체를 할당
        // thePlayer = FindObjectOfType<MovingObject>(); // 캐릭터 변수에 현재 캐릭터 객체를 할당


        // if(startPoint == thePlayer.currentMapName)
        // {
        //     // 카메라 이동
        //     theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
        //     // 캐릭터 이동
        //     thePlayer.transform.position = this.transform.position;
        // }
				anim = GetComponent<Animator>();
        if (thePlayer == null)
            thePlayer = FindObjectOfType<Player>();
        if(startPoint == thePlayer.currentMapName)
        {
          thePlayer.transform.position = transform.position;
          anim.SetBool("DoubleJump",false);
          anim.SetBool("isJumping",false);
				}
    }

    // Update is called once per frame
    void Update()
    {

    }
}