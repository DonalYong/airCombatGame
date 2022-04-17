using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMgr : NormalSingleton<ConfigMgr>
{
    public void Init()
    {
        InitPlaneCofig();

    }
   private void InitPlaneCofig()
    {
        var config = ReaderMgr.Single.GetReader(Paths.INIT_PLABE_CONFIG);
        config["planes"].Get<JsonData>(data=>
        {
            //遍历JSON数组数据
            foreach (JsonData item in data)
            {
                foreach (string key in item.Keys)
                {
                    if (key == "planeId")
                        continue;

                    string newKey = KeysUtil.GetPropertyKeys(int.Parse(item["planeId"].ToJson()), key);//id + name

                    if (!DataMgr.Single.Contains(newKey))
                    {
                        DataMgr.Single.SetJsonData(newKey,item[key]);
                    }


                }
            }
        });
    }

}
