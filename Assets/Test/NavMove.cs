using UnityEngine;
using UnityEngine.AI;


public class NavMove : MonoBehaviour {
	
	NavMeshAgent nav;
	public GameObject target;
	GameObject _target;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit, 100f);		

		if (!nav.pathPending && nav.remainingDistance < 0.5f) {
			Destroy(_target);
		}

		if (hit.transform == null || hit.transform.gameObject.tag != "Ground") {
			target.SetActive(false);
			Cursor.visible = true;
			return;}

		target.transform.position = hit.point;
		Cursor.visible = false;
		target.SetActive(true);

		if (Input.GetMouseButton(1)) {
			nav.destination = hit.point;
		}

		if (Input.GetMouseButtonUp(1)) {
			Destroy(_target);
			_target = Instantiate(target, hit.point, Quaternion.identity);
		}

		if (Input.GetMouseButtonDown(1) && _target != null) {
			Destroy(_target);
		}
	}
}