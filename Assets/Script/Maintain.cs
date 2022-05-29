using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maintain : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지

        // 애니메이터 컴포넌트 가져오기
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
