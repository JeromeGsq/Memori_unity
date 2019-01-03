using UnityEngine;

public class FollowAnchor : MonoBehaviour
{
	private Vector3 MoveVelocity;
	private Quaternion RotationVelocity;
	private Vector3 ScaleVelocity;

	public Transform Target;

	public Vector3 DeltaPos;
	public Vector3 DeltaScale;
	public float DampTimePos = 0.2f;
	public float DampTimeRotation = 0.2f;
	public float DampTimeScale = 0.2f;

	private void FixedUpdate()
	{
		if(DampTimePos != -1)
		{
			this.transform.position = Vector3.SmoothDamp(
				this.transform.position,
				this.Target.position + this.DeltaPos,
				ref this.MoveVelocity,
				this.DampTimePos
			);
		}

		if(DampTimeRotation != -1)
		{
			this.transform.rotation = Quaternion.Lerp(
				this.transform.rotation,
				this.Target.rotation,
				Time.deltaTime * this.DampTimeRotation);
		}

		if(DampTimeScale != -1)
		{
			this.transform.localScale = Vector3.SmoothDamp(this.transform.localScale,
				this.Target.localScale + this.DeltaScale,
				ref this.ScaleVelocity,
				this.DampTimeScale
			);
		}
	}
}
