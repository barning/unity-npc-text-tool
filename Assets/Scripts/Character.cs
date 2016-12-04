using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float speed =1.0f;
	public string axisHorizontal = "Horizontal";
	public string axisVertical = "Vertical";
	//public Animator anim;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.right *Input.GetAxis(axisHorizontal)* speed * Time.deltaTime;
		transform.position += transform.up *Input.GetAxis(axisVertical)* speed * Time.deltaTime;

	}
}
