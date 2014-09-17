using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class MenuController {

	public static void changeMenuTo(string menu) {
		ApplicationController app = GameObject.Find ("Application").GetComponent<ApplicationController>();
		foreach (KeyValuePair<string,Component> entry in app.menus) {
			if (entry.Key == menu) (entry.Value as Menu).on = true;
			else (entry.Value as Menu).on = false;
		}
	}
	
}
