using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 界面控件基类
/// </summary>
public class UISceneWidget : MonoBehaviour 
{
	DateTime OnClickTime;
	public float Throughtime = 0.5f;
	/// - OnHover (isOver) is sent when the mouse hovers over a collider or moves away.
	public delegate void onMouseHover (UISceneWidget eventObj, bool isOver);
	public onMouseHover OnMouseHover = null;
	void OnHover (bool isOver)
	{
		if (OnMouseHover != null) OnMouseHover(this, isOver);
	}
	/// - OnPress (isDown) is sent when a mouse button gets pressed on the collider.
	public delegate void onMousePress (UISceneWidget eventObj, bool isDown);
	public onMousePress OnMousePress = null;
	void OnPress (bool isDown)
	{
		if (OnMousePress != null) OnMousePress(this, isDown); 
	}
	/// - OnSelect (selected) is sent when a mouse button is released on the same object as it was pressed on.
	public delegate void onMouseSelect (UISceneWidget eventObj, bool selected);
	public onMouseSelect OnMouseSelect = null;
	void OnSelect (bool selected)
	{
		if (OnMouseSelect != null) OnMouseSelect(this, selected); 
	}
	/// - OnClick (int button) is sent with the same conditions as OnSelect, with the added check to see if the mouse has not moved much.
	public delegate void onMouseClick (UISceneWidget eventObj);
	public onMouseClick OnMouseClick = null;
	void OnClick ()
	{
		if (Throughtime > (float)(DateTime.UtcNow - OnClickTime).TotalSeconds)
		{
			return;
		}
		OnClickTime = DateTime.UtcNow;

		if (OnMouseClick != null)	OnMouseClick(this);
	}
	public delegate void onMouseDoubleClick(UISceneWidget eventObj);
	public onMouseDoubleClick OnMouseDoubleClick = null;
	void OnDoubleClick ()
	{
		if (OnMouseDoubleClick != null) OnMouseDoubleClick(this);
	}
	/// - OnDrag (delta) is sent when a mouse or touch gets pressed on a collider and starts dragging it.
	public delegate void onMouseDrag (UISceneWidget eventObj, Vector2 delta);
	public onMouseDrag OnMouseDrag = null;
	void OnDrag (Vector2 delta)
	{
		if (OnMouseDrag != null) OnMouseDrag(this, delta); 
	}
	/// - OnDrop (gameObject) is sent when the mouse or touch get released on a different collider than the one that was being dragged.
	public delegate void onMouseDrop (UISceneWidget eventObj, GameObject dropObject);
	public onMouseDrop OnMouseDrop = null;
	void OnDrop (GameObject dropObject)
	{
		if (OnMouseDrop != null) OnMouseDrop(this, dropObject); 
	}
	/// - OnInput (text) is sent when typing (after selecting a collider by clicking on it).
	/// - OnTooltip (show) is sent when the mouse hovers over a collider for some time without moving.
	/// - OnScroll (float delta) is sent out when the mouse scroll wheel is moved.
	/// - OnKey (KeyCode key) is sent when keyboard or controller input is used.
}
