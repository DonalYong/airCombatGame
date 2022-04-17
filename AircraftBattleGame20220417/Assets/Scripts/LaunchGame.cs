using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaunchGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConfigMgr.Single.Init();
        //脚本挂载初始化
        InitCustomAttributes initAtt = new InitCustomAttributes();
        initAtt.Init();

        UIManager.Single.Show(Paths.START_VIEW);

        //测试
        //keyqueue queue = new keyqueue();
        //key key = new key();
        //key.set(1);
        //queue.enqueue(key);
        //key = new key();
        //key.set("ssss");
        //queue.enqueue(key);
        //foreach (object item in queue)
        //{
        //    debug.log(item);
        //}
        //var reader = ReaderMgr.Single.GetReader(Paths.INIT_PLABE_CONFIG);
        //reader["planes"][0]["attackTime"].Get<float>((value) => Debug.Log(value));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
