using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerate : MonoBehaviour {




	// Use this for initialization
	void Start () {

		Maze maze1 = new Maze (3, 3);
		maze1.addMazeCell (0, 0, true, true);
		maze1.addMazeCell (1, 0, false, false);
		maze1.addMazeCell (2, 0, true, true);

		maze1.addMazeCell (0, 1, true, true);
		maze1.addMazeCell (1, 1, true, true);
		maze1.addMazeCell (2, 1, true, true);

		maze1.addMazeCell (0, 2, true, false);
		maze1.addMazeCell (1, 2, true, false);
		maze1.addMazeCell (2, 2, true, true);

		maze1.generateMaze ();
	}
	// Update is called once per frame
	void Update () {

	}
		
	class Maze{

		List<mazeCell> mazeCellList = new List<mazeCell> ();
		private int MazeSizeX;
		private int MazeSizeZ;

		public Maze(){

		}
		public Maze(int mazeSizeX, int mazeSizeZ){
			MazeSizeX =mazeSizeX;
			MazeSizeZ =mazeSizeZ;
		} 

		public void addMazeCell(int x, int z, bool southPath, bool eastPath )
		{
			mazeCell currentCell = new mazeCell (x, z, southPath, eastPath);
			mazeCellList.Add (currentCell);
		}

		public void generateMaze(){
			generateInnerOfMaze ();
			generateBorderOfMaze();
		}

		private void generateInnerOfMaze(){
			for (int count = 0; count < mazeCellList.Count; count++) {
				positionWall (mazeCellList [count].cellLocationX, mazeCellList [count].cellLocationZ, true, mazeCellList [count].EastPath, mazeCellList [count].SouthPath, true);
			}
		}

		private void generateBorderOfMaze(){
			int x, z =0;
			for(x = 0; x < MazeSizeX; x++){
				positionWall(x,z,false,true,true,true);

			}

			for(z = 0; z< MazeSizeZ; z++){
				positionWall(x-1,z,true,false,true, true);	
			}

			for( x=MazeSizeX-1; x >= 0; x--){
				positionWall(x,z-1,true,true,false,true);
			}

			for(z=MazeSizeZ-1; z >= 0; z--){
			positionWall(x+1,z,true,true,true,false);
			}
		}

		private void positionWall(float x ,float z,bool northPath, bool eastPath, bool southPath, bool westPath ){
			Vector3 scaleV = new Vector3(0,0,0);
			Vector3 posV = new Vector3(0,0,0);



			Debug.Log("EastPath Value =" + eastPath.ToString());
			Debug.Log("SouthPath Value =" + southPath.ToString());

			x = ((x * 10) - 15);//(gameObject.transform.lossyScale).x);
			z = (15 - (z * 10)); //(gameObject.transform.lossyScale).z);  

			if (northPath == false) {
				scaleV = new Vector3 (10f, 2, 1);
				posV = new Vector3 (x + 5,1,z);
				generateWall (posV, scaleV);
			}

			if (eastPath == false) {
				scaleV = new Vector3 (1, 2, 10f);
				posV = new Vector3 (x + 10f, 1, z - 5f);
				generateWall (posV, scaleV);
			}

			if (southPath == false) {
				scaleV = new Vector3 (10f, 2, 1);
				posV = new Vector3 (x + 5f, 1, z - 10);
				generateWall (posV, scaleV);
			}

			if (westPath == false) {
				scaleV = new Vector3 (1, 2, 10f);
				posV = new Vector3 (x,1,z - 5);
				generateWall (posV, scaleV);
			}	


		}

		public void generateWall(Vector3 position, Vector3 scale){
			GameObject wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
			wall.SetActive (true);
			wall.transform.position = position;
			wall.transform.localScale = scale;
		}
			
	}



	class mazeCell : Maze
	{
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

		public mazeCell(int x, int z, bool SouthPath, bool EastPath){
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
}