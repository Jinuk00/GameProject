using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
