using UnityEngine;
using DG.Tweening;

public class Resize : MonoBehaviour {

	public Vector3 startSize;
	public Vector3 endSize;
	public float speed;

	void Start () {
		transform.localScale = startSize;
		transform.DOScale(endSize, speed);
	}
}