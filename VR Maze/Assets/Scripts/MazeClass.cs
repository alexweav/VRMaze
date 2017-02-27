using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MazeGenerate  {

	List<mazeCell> mazeCellList = new List<mazeCell> ();
		
	//	
	private int MazeSizeX;
	private int MazeSizeZ;


	//Constructor: 0 arguments
	public Maze(){
		MazeSizeX = 0; //Sets maze size x
		MazeSizeZ = 0; //Sets maze size z
	}

	//Maze Constructor: 2 arguments
	public Maze(int mazeSizeX, int mazeSizeZ){
		MazeSizeX =mazeSizeX; //Set maze dimision x 
		MazeSizeZ =mazeSizeZ; //Set maze dimision z
	} 

	//Creates and adds a maze cell to a list of mazeCells  
	public void addMazeCell(int x, int z, bool eastPath, bool southPath ){
		mazeCell currentCell = new mazeCell (x, z, southPath, eastPath);  //Creates new mazeCell
		mazeCellList.Add (currentCell);									  //Adds mazeCell to list
	}

	public void generateMaze(){
		generateInnerOfMaze (); //Method Call to generate the inside of a maze
		generateBorderOfMaze(); //Method Call to generate the border of a maze
	}

	private void generateInnerOfMaze(){
		GameObject cell;
		for (int count = 0; count < mazeCellList.Count; count++) {
			cell = new GameObject ("Maze Cell (" + mazeCellList[count].cellLocationX.ToString() + "," + mazeCellList[count].cellLocationZ.ToString() + ")");
			positionWall (mazeCellList [count].cellLocationX, mazeCellList [count].cellLocationZ, true, mazeCellList [count].EastPath, mazeCellList [count].SouthPath, true, cell);
			generateFloor ((mazeCellList[count].cellLocationX * 10) -25, 25 - (mazeCellList[count].cellLocationZ * 10), cell);
		}
	}

	private void generateBorderOfMaze(){
		int xCell, zCell =0;
		GameObject border;
		border = new GameObject ("Maze Border") ;

		for(xCell = 0; xCell < MazeSizeX; xCell++){
			positionWall(xCell,zCell,false,true,true,true, border);
		}

		for(zCell = 0; zCell< MazeSizeZ; zCell++){
			positionWall(xCell-1,zCell,true,false,true, true,border);	
		}

		for( xCell = MazeSizeX-1; xCell >= 0; xCell--){
			positionWall(xCell,zCell-1,true,true,false,true,border);
		}

		for(zCell = MazeSizeZ-1; zCell>= 0; zCell--){
			positionWall(xCell+1,zCell,true,true,true,false,border);
		}
	}


	private void positionWall(float x ,float z,bool northPath, bool eastPath, bool southPath, bool westPath, GameObject cell ){
		
		Vector3 scaleV = new Vector3(0,0,0);
		Vector3 posV = new Vector3(0,0,0);

		x = ((x * 10) - 25);//(gameObject.transform.lossyScale).x);
		z = (25 - (z * 10)); //(gameObject.transform.lossyScale).z);  

		if (northPath == false) {
			scaleV = new Vector3 (11f, 2, 1);
			posV = new Vector3 (x + 5,1,z);
			generateWall (posV, scaleV, cell, "North Wall");

		}

		if (eastPath == false) {
			scaleV = new Vector3 (1, 2, 11f);
			posV = new Vector3 (x + 10f, 1, z - 5f);
			generateWall (posV, scaleV, cell, "East Wall");
		}

		if (southPath == false) {
			scaleV = new Vector3 (11f, 2, 1);
			posV = new Vector3 (x + 5f, 1, z - 10);
			generateWall (posV, scaleV, cell, "South Wall");
		}

		if (westPath == false) {
			scaleV = new Vector3 (1, 2, 11f);
			posV = new Vector3 (x,1,z - 5);
			generateWall (posV, scaleV, cell, "West Wall");
		}	


}

	public void generateWall(Vector3 position, Vector3 scale, GameObject cell, string wallName){
		GameObject wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		wall.name = wallName;
		wall.SetActive (true);
		wall.transform.position = position;
		wall.transform.localScale = scale;
		wall.transform.parent = cell.transform; 
	}

	public void generateFloor(float x, float z, GameObject cell){
		GameObject mazeFloor = GameObject.CreatePrimitive (PrimitiveType.Plane);
		mazeFloor.name = "Cell Floor";
		mazeFloor.SetActive(true);
		mazeFloor.transform.position = new Vector3 (x + 5, 0, z - 5);
		mazeFloor.transform.localScale = new Vector3 (1, 1, 1);
		mazeFloor.transform.parent = cell.transform;
	}
}







class mazeCell : Maze{
	
	private bool startCell;
	private bool finishCell;
	private bool southPath;
	private bool eastPath;
	private int[] cellLocation = new int[2];


	public mazeCell(){
		startCell = false;
		finishCell = false;
		cellLocation = null;
	}

	public mazeCell(int x, int z){
		cellLocation[0] = x;
		cellLocation[1] = z;
		startCell = false;
		finishCell = false;
	}

	public mazeCell(int x, int z, bool EastPath, bool SouthPath){
		southPath = SouthPath;
		eastPath = EastPath;
		cellLocation[0] = x;
		cellLocation[1] = z;
		startCell = false;
		finishCell = false;
	}

	public int cellLocationX {
		get { 
			return cellLocation [0];
		}
		set {
			cellLocation [0] = cellLocationX; 
		}
	}

	public int cellLocationZ {
		get {
			return cellLocation [1];
		}
		set {
			cellLocation [1] = cellLocationZ; 
		}
	}

	public bool StartCell {
		get {
			return startCell;
		}
		set {
			startCell = StartCell;
		}


	}

	public bool FinishCell {
		get {
			return startCell;
		}
		set {
			finishCell = FinishCell;
		}

	}

	public bool SouthPath {
		get {
			return southPath;
		}
		set {
			southPath = SouthPath;
		}

	}

	public bool EastPath {
		get {
			return eastPath;
		}
		set {
			eastPath = EastPath;
		}

	}
}
