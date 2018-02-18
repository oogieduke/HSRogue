using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetedAttack : MonoBehaviour {

	public GameObject target;
	private GameObject _target;
	private float _targetZPos;
	public GameObject hitTarget;

	private void OnMouseDown() {
		_target = Instantiate(target, transform.position, transform.rotation);
		_target.GetComponent<SpriteRenderer>().enabled = false;
		_targetZPos = Vector3.Distance(_target.transform.position, Camera.main.transform.position); 
}

	private void OnMouseDrag() {
		Cursor.visible = false;
		_target.GetComponent<SpriteRenderer>().enabled = true;
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = _targetZPos;
		Vector3 _mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		_target.transform.position = _mousePos;
	}

	private void OnMouseUp() {
		Cursor.visible = true;
		Destroy(_target);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit, 100f);
		if (hit.transform == null) { return; };
		hitTarget = hit.transform.gameObject;

		if (hitTarget.tag == "Enemy") {
			var _hitTarget = hitTarget.GetComponent<EnemyMinionScript>();
			_hitTarget.currentHealth = _hitTarget.currentHealth - GetComponent<MinionScript>().currentAttack;
			_hitTarget.UpdateStats();

			GetComponent<MinionScript>().currentHealth = GetComponent<MinionScript>().currentHealth - _hitTarget.currentAttack;
			GetComponent<MinionScript>().UpdateStats();
		}
	}
}