using UnityEngine;
using System.Collections;

public class AnchorGizmo : MonoBehaviour
{
	public e_AnchorType AnchorType = e_AnchorType.Sphere;
	public float SizeGizmo = 0.02f;
	public Vector3 SizeRectangleGizmo;
	public Color ColorGizmo = Color.white;

	[Space(20)]

	public bool ArrowDirection;
	public float SizeArrow = 0.2f;

	void OnDrawGizmos()
	{
		Gizmos.color = ColorGizmo;
		switch(AnchorType)
		{
			case e_AnchorType.Cube:
				Gizmos.DrawCube(transform.position, new Vector3(SizeGizmo, SizeGizmo, SizeGizmo));
				break;

			case e_AnchorType.Rectangle:
				Gizmos.DrawCube(transform.position, new Vector3(SizeRectangleGizmo.x, SizeRectangleGizmo.y, SizeRectangleGizmo.z));
				break;

			case e_AnchorType.Sphere:
				Gizmos.DrawSphere(transform.position, SizeGizmo);
				break;

			case e_AnchorType.Cone:
				DebugExtension.DrawCone(transform.position - transform.forward * SizeRectangleGizmo.x, transform.forward * 2 * SizeRectangleGizmo.y, ColorGizmo, SizeRectangleGizmo.z * 100);
				break;

			case e_AnchorType.ConeUp:
				DebugExtension.DrawCone(transform.position + transform.up * SizeRectangleGizmo.x, -transform.up * 2 * SizeRectangleGizmo.y, ColorGizmo, SizeRectangleGizmo.z * 100);
				break;
		}

		if(ArrowDirection)
		{
			Gizmos.color = ColorGizmo;
			Gizmos.DrawLine(transform.position, (transform.position - transform.forward * SizeArrow));
			Gizmos.DrawLine((transform.position - transform.forward * SizeArrow), transform.position - (transform.right * SizeArrow / 2));
			Gizmos.DrawLine((transform.position - transform.forward * SizeArrow), transform.position + (transform.right * SizeArrow / 2));
		}
	}
}

public enum e_AnchorType
{
	Cube,
	Rectangle,
	Sphere,
	Cone,
	ConeUp,
}
