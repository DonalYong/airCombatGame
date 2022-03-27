using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //脚本挂载初始化
        InitCustomAttributes initAtt = new InitCustomAttributes();
        initAtt.Init();

        UIManager.Single.Show(Paths.START_VIEW);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
