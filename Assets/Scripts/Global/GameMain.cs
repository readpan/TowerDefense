using UnityEngine;
using System.Collections;
using DevelopEngine;//配置文件读取所用

public class GameMain : MonoSingleton<GameMain>
{
    public readonly string configPath = "/config.txt";
    private AsyncOperation async;
    // Use this for initialization
    IEnumerator Start()
    {
        //限制帧数，控制性能（格斗、竞速 55帧）
        Application.targetFrameRate = 45;
        //切换场景时不销毁物体
        DontDestroyOnLoad(this.gameObject);
        //读取配置文件
        Configuration.LoadConfig(configPath);
        while (!Configuration.IsDone)
            yield return null;
        //加载游戏开始场景
        string uiscene = Configuration.GetContent("Scene", "LoadGameStart");

        StartCoroutine(LoadScene(uiscene));
    }

    //加载进度条场景
    IEnumerator Load()
    {
        async = Application.LoadLevelAsync("Loading");
        yield return async;
    }
    //加载场景
    public IEnumerator LoadScene(string uiScene)
    {
        //判断有没有3D场景（没有）
        Global.Contain3DScene = false;
        //传入UI场景名称
        Global.LoadUIName = uiScene;
        //开启另外一个进度条场景协成
        yield return StartCoroutine(Load());
    }
}
