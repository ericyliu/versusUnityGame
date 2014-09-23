using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AIDefinitions {

	public static Dictionary<string, string[]> behaviors = new Dictionary <string, string[]>() {
		{"BackAndForth",new string[] {"Face:Player","Fire:True","GoTo:10,8","GoTo:-10,8"}}
	};
	
	
	
}
