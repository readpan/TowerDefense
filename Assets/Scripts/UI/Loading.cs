using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
    //进度条
    public UIProgressBar mProgress;
    //异步加载对象 0-1
    AsyncOperation async;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        //判断加在场景是否有3D场景
        if (Global.Contain3DScene)
        {
            //先读取3D场景
            async = Application.LoadLevelAsync(Global.LoadSceneName);
            //异步追加，追加UI部分
            async = Application.LoadLevelAdditiveAsync(Global.LoadUIName);
        }
        else
        {
            async = Application.LoadLevelAsync(Global.LoadUIName);
        }
        yield return async;
    }
    // Update is called once per frame
    void Update()
    {
        //时时同步显示
        mProgress.value = async.progress;
    }
}
