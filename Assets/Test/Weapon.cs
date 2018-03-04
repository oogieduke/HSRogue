using UnityEngine;

public class Weapon : MonoBehaviour {

	Vector3 mousePos;
	public Transform weapon;
	public GameObject bullet;
	public float force = 500f;

	void Update ()
    {
        RotateWeapon();
		if (Input.GetMouseButtonDown(0)) {
			FireWeapon();
		}
    }

    private void FireWeapon() {
		var obj = Instantiate(bullet, weapon.position, weapon.rotation);
		var rb = obj.GetComponent<Rigidbody>();

		rb.AddForce(transform.forward * force);
		Destroy(obj, 10f);
    }

    private void RotateWeapon()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

		int mask = LayerMask.GetMask("Ground");
        Physics.Raycast(ray, out hit, 100f, mask);

        var mousePos = new Vector3(hit.point.x, weapon.position.y, hit.point.z);
        transform.LookAt(mousePos);
    }
}