using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance; // instance의 값을 공유

    public string currentMapName; // 이동할 맵 이름 저장

    // BoxCollider 컴포넌트를 가져오기 위해 선언
    private BoxCollider2D boxCollider;

    // 통과불가능한 레이어를 설정해주기 위해 선언
    public LayerMask layerMask;

    public float speed; // 움직이는 속도 정의
    private Vector3 vector; // 움직이는 방향 정의

    public float runSpeed; // Shift키 입력시 증가하는 속도
    private float applyRunSpeed; // Shift키 입력시 연산되는 증가 속도
    private bool applyRunFlag = false; // Shift키 입력여부

    public int walkCount; // 방향키 입력시 이동값을 정하기 위한 값
    private int currentWalkCount; // 이동값 리셋을 위한 값

    private bool canMove = true; // 방향키 이동 반복실행 방지를 위한 값

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지

            // 애니메이터 컴포넌트 가져오기
            boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
            instance = this;
        }
         else
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
