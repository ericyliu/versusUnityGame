using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class MenuController {

	public static void changeMenuTo(string menu) {
		GameMaster game = GameObject.Find ("GameMaster").GetComponent("GameMaster") as GameMaster;
		foreach (KeyValuePair<string,Component> entry in game.menus) {
			if (entry.Key == menu) (entry.Value as Menu).on = true;
			else (entry.Value as Menu).on = false;
		}
	}
	
}
