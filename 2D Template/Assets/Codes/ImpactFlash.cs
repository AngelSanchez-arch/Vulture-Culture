using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactFlash : MonoBehaviour
{
	public void Flash(SpriteRenderer spriteRend, float duration, Color flashcolor)
	{
		StartCoroutine(DoFlash(spriteRend, duration, flashcolor));
	}
	private IEnumerator DoFlash(SpriteRenderer spriteRend, float duration, Color flashcolor)
	{
		Color originalColor = spriteRend.color;
		spriteRend.color = flashcolor;

		yield return new WaitForSeconds(duration);

		spriteRend.color = originalColor;
	}
}
