using UnityEngine;
using System.Collections;
using DevelopEngine;

public class HUDEffect : MonoSingleton<HUDEffect> {

	public GameObject prefab;	//HUD预设
	public Transform target;	//头顶爆字位置
	
	HUDText mText = null;		//爆字内容

	void Start ()
	{
		if (HUDRoot.go == null)
		{
			GameObject.Destroy(this);
			return;
		}
		
		GameObject child = NGUITools.AddChild(HUDRoot.go, prefab);
		mText = child.GetComponentInChildren<HUDText>();

		child.AddComponent<UIFollowTarget>().target = target;
	}
	
	public void Hurt (float damage)
	{
		if (mText != null)
		{
			mText.Add(-damage, Color.red, 0f);
		}
	}
}
