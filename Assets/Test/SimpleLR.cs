using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SimpleLR : MonoBehaviour {

	LineRenderer lr;
	public List<Transform> transforms = new List<Transform>();
	public bool update;
	public Vector3[] vectors;

	void Start ()
    {
        lr = GetComponent<LineRenderer>();
        UpdateLR();
    }

    void UpdateVectors()
    {
        for (int i = 0; i < transforms.Count; i++)
        {
            vectors[i] = transforms[i].position;
        }
    }

	public void UpdateLR() {
        vectors = new Vector3[transforms.Count];
		UpdateVectors();
        lr.positionCount = vectors.Length;
		lr.SetPositions(vectors);
	}

    void Update () {
		if (update) { UpdateLR(); }
	}
}