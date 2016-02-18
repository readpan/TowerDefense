//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This is a script used to keep the game object scaled to 2/(Screen.height).
/// If you use it, be sure to NOT use UIOrthoCamera at the same time.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Root")]
public class UIRoot : MonoBehaviour
{
	#region fixwidth
	public float ResolutionScale = 1.5f;
	public int manualWidth = 800;
	public int minimumWidth = 320;
	public int maximumWidth = 1536;
	#endregion
	static public List<UIRoot> list = new List<UIRoot>();

	/// <summary>
	/// List of all UIRoots present in the scene.
	/// </summary>

	public enum Scaling
	{
		PixelPerfect,
		FixedSize,
		FixedSizeOnMobiles,
		FixedWidth,
	}

	/// <summary>
	/// Type of scaling used by the UIRoot.
	/// </summary>

	public Scaling scalingStyle = Scaling.PixelPerfect;

	/// <summary>
	/// Height of the screen when the scaling style is set to FixedSize.
	/// </summary>

	public int manualHeight = 720;

	/// <summary>
	/// If the screen height goes below this value, it will be as if the scaling style
	/// is set to FixedSize with manualHeight of this value.
	/// </summary>

	public int minimumHeight = 320;

	/// <summary>
	/// If the screen height goes above this value, it will be as if the scaling style
	/// is set to FixedSize with manualHeight of this value.
	/// </summary>

	public int maximumHeight = 1536;

	/// <summary>
	/// UI Root's active height, based on the size of the screen.
	/// </summary>

	public int activeHeight
	{
		get
		{
			int height = Mathf.Max(2, Screen.height);
			if (scalingStyle == Scaling.FixedSize) return manualHeight;

#if UNITY_IPHONE || UNITY_ANDROID
			if (scalingStyle == Scaling.FixedSizeOnMobiles)
				return manualHeight;
#endif
			if (height < minimumHeight) return minimumHeight;
			if (height > maximumHeight) return maximumHeight;
			return height;
		}
	}

	public int activeWidth
	{
		get
		{
			int width = Mathf.Max(2,Screen.height);
			if (scalingStyle == Scaling.FixedSize) return manualWidth;

#if UNITY_IPHONE || UNITY_ANDROID
			if (scalingStyle == Scaling.FixedSizeOnMobiles)
				return manualWidth;
#endif
			if (width < minimumWidth) return minimumWidth;
			if (width > maximumWidth) return maximumWidth;
			return width;
		}
	}
	/// <summary>
	/// Pixel size adjustment. Most of the time it's at 1, unless the scaling style is set to FixedSize.
	/// </summary>

	public float pixelSizeAdjustment { get { return GetPixelSizeAdjustment(Screen.height); } }

	/// <summary>
	/// Helper function that figures out the pixel size adjustment for the specified game object.
	/// </summary>

	static public float GetPixelSizeAdjustment (GameObject go)
	{
		UIRoot root = NGUITools.FindInParents<UIRoot>(go);
		return (root != null) ? root.pixelSizeAdjustment : 1f;
	}

	/// <summary>
	/// Calculate the pixel size adjustment at the specified screen height value.
	/// </summary>

	public float GetPixelSizeAdjustment (int height)
	{
		height = Mathf.Max(2, height);

		if (scalingStyle == Scaling.FixedSize)
			return (float)manualHeight / height;

#if UNITY_IPHONE || UNITY_ANDROID
		if (scalingStyle == Scaling.FixedSizeOnMobiles)
			return (float)manualHeight / height;
#endif
		if (height < minimumHeight) return (float)minimumHeight / height;
		if (height > maximumHeight) return (float)maximumHeight / height;
		return 1f;
	}

	Transform mTrans;

	protected virtual void Awake () { mTrans = transform; }
	protected virtual void OnEnable () { list.Add(this); }
	protected virtual void OnDisable () { list.Remove(this); }

	protected virtual void Start ()
	{
		UIOrthoCamera oc = GetComponentInChildren<UIOrthoCamera>();

		if (oc != null)
		{
			Debug.LogWarning("UIRoot should not be active at the same time as UIOrthoCamera. Disabling UIOrthoCamera.", oc);
			Camera cam = oc.gameObject.GetComponent<Camera>();
			oc.enabled = false;
			if (cam != null) cam.orthographicSize = 1f;
		}
		else Update();
	}

	void Update ()
	{
#if UNITY_EDITOR
		if (!Application.isPlaying && gameObject.layer != 0)
			UnityEditor.EditorPrefs.SetInt("NGUI Layer", gameObject.layer);
#endif
		if (mTrans != null)
		{
			float size = 0f;
			if ((float)Screen.height/Screen.width > ResolutionScale && scalingStyle == Scaling.FixedWidth)
			{
				float calcActiveWidth = activeWidth;
				if (calcActiveWidth > 0f)
				{
					size = ((float)Screen.width*2/Screen.height )/ calcActiveWidth;
				}
			}
			else
			{
				float calcActiveHeight = activeHeight;

				if (calcActiveHeight > 0f )
				{
					size = 2f / calcActiveHeight;
				}
			}
			if (activeHeight > 0f || activeWidth > 0f)
			{
				Vector3 ls = mTrans.localScale;
				
				if (!(Mathf.Abs(ls.x - size) <= float.Epsilon) ||
				    !(Mathf.Abs(ls.y - size) <= float.Epsilon) ||
				    !(Mathf.Abs(ls.z - size) <= float.Epsilon))
				{
					mTrans.localScale = new Vector3(size, size, size);
				}
			}
		}
	}

	/// <summary>
	/// Broadcast the specified message to the entire UI.
	/// </summary>

	static public void Broadcast (string funcName)
	{
		for (int i = 0, imax = list.Count; i < imax; ++i)
		{
			UIRoot root = list[i];
			if (root != null) root.BroadcastMessage(funcName, SendMessageOptions.DontRequireReceiver);
		}
	}

	/// <summary>
	/// Broadcast the specified message to the entire UI.
	/// </summary>

	static public void Broadcast (string funcName, object param)
	{
		if (param == null)
		{
			// More on this: http://answers.unity3d.com/questions/55194/suggested-workaround-for-sendmessage-bug.html
			Debug.LogError("SendMessage is bugged when you try to pass 'null' in the parameter field. It behaves as if no parameter was specified.");
		}
		else
		{
			for (int i = 0, imax = list.Count; i < imax; ++i)
			{
				UIRoot root = list[i];
				if (root != null) root.BroadcastMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
