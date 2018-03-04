using UnityEngine;

public class Rotate : MonoBehaviour {
	public Vector3 axisSpeed;

	enum Handle{localSpace, worldSpace}
	[SerializeField] Handle handle;

	void Update () {
		if (handle == Handle.localSpace) {
		transform.Rotate(-axisSpeed * 10 * Time.deltaTime, Space.Self);	
		}
		else if (handle == Handle.worldSpace) {
		transform.Rotate(-axisSpeed * 10 * Time.deltaTime, Space.World);
		}
	}
}