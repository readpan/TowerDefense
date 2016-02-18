using UnityEngine;
using System.Collections;
using DevelopEngine;

public class UIScene_SingleGame_Input : UIScene
{
    public UISceneWidget Button_Input_Enter;

    protected override void Start()
    {
        base.Start();
        Button_Input_Enter = GetWidget("Button_Input_Enter");
        if (Button_Input_Enter != null)
            Button_Input_Enter.OnMouseClick = ButtonInputEnter;
    }

    private void ButtonInputEnter(UISceneWidget eventObj)
    {
        string uiscene = Configuration.GetContent("Scene", "LoadCharacterSelect");
        print(uiscene);
        StartCoroutine(GameMain.Instance.LoadScene(uiscene));
        print("ButtonInputEnter");
    }
}
