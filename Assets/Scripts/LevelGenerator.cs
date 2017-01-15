using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public static LevelGenerator instance;

    //모든 레벨 조각을 보존
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    //최초레벨조각의 시작포인트
    public Transform levelStartPoint;
    //현재 게임중에 표시되는 레벨조각
    public List<LevelPiece> pieces = new List<LevelPiece>();

    void Awake()
    {
        instance = this;
    }
    
    public void AddPiece()
    {
        //랜덤넘버선택
        int randomindex = Random.Range(0, levelPrefabs.Count);

        //랜덤레벨프리팹의 복사본을 pieces변수에 대입
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomindex]);
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        //위치
        if(pieces.Count == 0)
        {
            //첫번째 조각
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            //마지막 조각의 exit를 새로운 조각의 스폰포인트로
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);
    }
    
    // Use this for initialization
	void Start () {
        GenerateInitialPieces();	
	}
	
    public void GenerateInitialPieces()
    {
        for(int i = 0; i < 2; i++)
        {
            AddPiece();
        }
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
