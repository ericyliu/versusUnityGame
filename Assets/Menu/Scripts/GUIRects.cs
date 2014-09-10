using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIRects {

	Dictionary<string,float[]> menuSizes = new Dictionary<string,float[]>(){
		//Main Menu
		{"mainMenuSinglePlayer",new float[] {1920f/2f-400/2f, 1080f/2f - 100f, 400f, 100f}},
		{"mainMenuUseVersus", new float[] {1920f/2f-400f/2f, 1080f/2f + 40f, 400f, 100f}},
		{"mainMenuExit", new float[] {1920f - 110f, 10f, 100f, 50f}},
		//Versus Menu
		{"versusWebViewFrame", new float[] {1920f/2f - 1820/2f, 1080f/2f - 980/2f, 1080f, 980f}},
		//Game Menu
		{"gameActiveWeapon", new float[] {0,0,0,0}},
		{"gameHealth", new float[] {0,0,0,0}},
		{"gameEscapeButton", new float[] {1920f - 110f, 10f, 100f, 50f}}
	};

	public Dictionary<string,Rect> menuRects = new Dictionary<string,Rect>();
	
	//----------------------------------------------------------
	
	public GUIRects () {
	
		resize();
		buildRects();
	
	}
	
	//-----------------------------------------------------------
	
	void resize () {
	
		Dictionary<string, float[]> tempMenuSizes = new Dictionary<string,float[]>();
	
		float widthRatio = Screen.width/1920f;
		float heightRatio = Screen.height/1080f;
	
		foreach (KeyValuePair<string,float[]> entry in menuSizes) {
			tempMenuSizes.Add(entry.Key, new float[] {entry.Value[0]*widthRatio,
													  entry.Value[1]*heightRatio,
													  entry.Value[2]*widthRatio,
													  entry.Value[3]*heightRatio});
		}
		
		menuSizes = tempMenuSizes;
	}
	
	//---------------------------------------------------------
	
	void buildRects() {
	
		Dictionary<string,Rect> tempMenuRects = new Dictionary<string,Rect>();
	
		foreach (KeyValuePair<string,float[]> entry in menuSizes) {
			tempMenuRects.Add(entry.Key,new Rect(entry.Value[0],
											 entry.Value[1],
											 entry.Value[2],
											 entry.Value[3]));
		}
		
		menuRects = tempMenuRects;
	
	}
	
	
	
}
