﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class MissionUI {

	public SpriteRenderer[] mission;
	private float time = -1f;

	void Start () {
	}

	public void SetSprite(int iPart, CharacterPart part) {
		mission[iPart].sprite = part.sprite;
		switch (part.category) {
		case (CharacterPart.Category.HAT):
			mission[iPart].transform.localPosition = new Vector3(mission[iPart].transform.localPosition.x, mission[iPart].transform.localPosition.y - 42f / part.sprite.pixelsPerUnit, 0);
			break;

		case (CharacterPart.Category.HEAD):
			mission[iPart].transform.localPosition = new Vector3(mission[iPart].transform.localPosition.x, mission[iPart].transform.localPosition.y - 34f / part.sprite.pixelsPerUnit, 0);
			break;

		case (CharacterPart.Category.BODY):
			mission[iPart].transform.localPosition = new Vector3(mission[iPart].transform.localPosition.x, mission[iPart].transform.localPosition.y - 20f / part.sprite.pixelsPerUnit, 0);
			break;

		case (CharacterPart.Category.PANT):
			mission[iPart].transform.localPosition = new Vector3(mission[iPart].transform.localPosition.x, mission[iPart].transform.localPosition.y - 7f / part.sprite.pixelsPerUnit, 0);
			break;
		}
	}
	
	public void Update() {
		if (time > 0f) {
			time -= Time.deltaTime;
			Color c = mission[0].color;
			c.a = Mathf.Lerp(0f, 1f, time);
			if (time < 0f)
				c.a = 0;
			for (int i = 0; i < mission.Length; i++) {
				mission[i].color = c;
			}
		}
	}

	public void fade() {
		time = 1f;
	}
}
