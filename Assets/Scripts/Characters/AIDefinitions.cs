using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AIDefinitions {

	public static Dictionary<string, string[]> behaviors = new Dictionary <string, string[]>() {
		{"BackAndForth",new string[] {"GoLeft ToEdge", "Shoot", "GoRight ToEdge"}}
	};
	
	
	
}
