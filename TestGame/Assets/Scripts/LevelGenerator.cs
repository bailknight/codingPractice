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

	private Vector3 spawnPosition = Vector3.zero;

    void Awake()
    {
        instance = this;
    }
    
    public void AddPiece()
    {
		
		//위치와 랜덤넘버선택
		//첫번째 조각은 0번 프리팹으로 고정
        if(pieces.Count == 0)
        {
         	spawnPosition =  levelStartPoint.position;
			//랜덤레벨프리팹의 복사본을 pieces변수에 대입
			LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[0]);
			piece.transform.SetParent(this.transform, false);
			piece.transform.position = spawnPosition;
			pieces.Add(piece);
        }
		//첫번째 조각을 제외한 리트에서 랜덤으로 선택
        else
        {
			CreatPiece ();
        }
    }

	public void CreatPiece()
	{			
		int randomindex = Random.Range(1, levelPrefabs.Count);
		//마지막 조각의 exit를 새로운 조각의 스폰포인트로
		spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
		//랜덤레벨프리팹의 복사본을 pieces변수에 대입
		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomindex]);
		piece.transform.SetParent(this.transform, false);
		piece.transform.position = spawnPosition;
		pieces.Add(piece);
	}

	public void Restart ()
	{
		//화면상의 모든 pieces를 삭제후 리스트를 초기화
		for(int i =0; i< (pieces.Count);i++)
			Destroy(pieces[i].gameObject);
		pieces.Clear();
		GenerateInitialPieces();
	}
	
    public void GenerateInitialPieces()
    {
        for(int i = 0; i < 3; i++)
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
