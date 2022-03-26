
using System.Reflection;
using System;
//获取到标记特性的类型
public class InitCustomAttributes { 
   public void Init()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(BindPrefab));//获取BindPrefab所在的程序集
        Type[] types = assembly.GetExportedTypes();//获取程序集中所有公有类型
        foreach(Type type in types)
        {
            foreach (Attribute attribute in Attribute.GetCustomAttributes(type,true))//遍历每个type类型所拥有的特性
            {
                if(attribute is BindPrefab)
                {
                    BindPrefab data = attribute as BindPrefab;

                    Bindutil.Bind(data.Path,type);
                }
            }
        }
    }
}
