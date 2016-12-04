using UnityEngine;
using System.Collections;

public class npc : MonoBehaviour
{
	public TextMesh objectText;
	public TextAsset textFile;
	private string[] dialogLines;
	int dialogCounter;
	private float fireRate = 0.2F;
	private float nextFire = 0.0F;

	void Start ()
	{
		dialogCounter = 0;
		objectText = transform.FindChild ("Text").gameObject.GetComponent<TextMesh> ();
		if (textFile != null) {
			dialogLines = (textFile.text.Split ('\n'));
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		objectText.text = dialogLines [0];
	}

	void OnTriggerExit2D (Collider2D other)
	{
		objectText.text = dialogLines [dialogLines.Length - 1];
		StartCoroutine (waitTilVanish ());
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			print ("yes");
			nextFire = Time.time + fireRate;
			if (dialogCounter < dialogLines.Length) {
				string dialog = dialogLines [dialogCounter];
				objectText.text = dialog;
				dialogCounter++;
			}
		}
	}

	public IEnumerator waitTilVanish ()
	{
		yield return new WaitForSeconds (2);
		objectText.text = " ";
	}
}
