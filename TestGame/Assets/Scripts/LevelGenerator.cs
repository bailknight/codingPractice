using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public static LevelGenerator instance;

	public float bonusLevelPoint;


    //모든 레벨 조각을 보존
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    //최초레벨조각의 시작포인트
    public Transform levelStartPoint;
    //현재 게임중에 표시되는 레벨조각
    public List<LevelPiece> pieces = new List<LevelPiece>();

	private Vector3 spawnPosition = Vector3.zero;
	private float startBonusLevelPoint;

    void Awake()
    {
        instance = this;
    }

	void Start()
	{
		startBonusLevelPoint = bonusLevelPoint;
	}

    public void AddPiece()
    {
		int randomindex = Random.Range(2, levelPrefabs.Count);
		//위치와 랜덤넘버선택
		//첫번째 조각은 0번 프리팹으로 고정
		if (pieces.Count == 0) 
		{
			//마지막 조각의 exit를 새로운 조각의 스폰포인트로
			spawnPosition = levelStartPoint.position;
			//랜덤레벨프리팹의 복사본을 pieces변수에 대입
			CreatPiece (0, spawnPosition);
		}

		//보너스 점수 도달시 현 조각을 보너스 조각으로 교채
		else if (PlayerController.instance.GetDistance () >= bonusLevelPoint) 
		{	
			//마지막 조각의 exit를 새로운 조각의 스폰포인트로
			spawnPosition = pieces [0].exitPoint.position;
			Destroy(pieces[1].gameObject);
			CreatBonusPiece (spawnPosition);
			spawnPosition = pieces [pieces.Count - 1].exitPoint.position;
			CreatPiece (randomindex, spawnPosition);
			bonusLevelPoint += startBonusLevelPoint;
		} 

		//첫번째 조각을 제외한 리스트에서 랜덤으로 선택
		else 
		{
			spawnPosition = pieces [pieces.Count - 1].exitPoint.position;
			CreatPiece (randomindex, spawnPosition);
		}
    }

	public void CreatPiece(int seed, Vector3 position)
	{			
		//랜덤레벨프리팹의 복사본을 pieces변수에 대입
		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[seed]);
		piece.transform.SetParent(this.transform, false);
		piece.transform.position = position;
		pieces.Add(piece);
		Debug.Log (spawnPosition);
	}

	public void CreatBonusPiece(Vector3 position)
	{			
		//랜덤레벨프리팹의 복사본을 pieces변수에 대입
		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[1]);
		piece.transform.SetParent(this.transform, false);
		piece.transform.position = position;
		pieces [1] = piece;
		Debug.Log (spawnPosition);
	}

	public void Restart ()
	{
		//화면상의 모든 pieces를 삭제후 리스트를 초기화
		for(int i =0; i< (pieces.Count);i++)
			Destroy(pieces[i].gameObject);
		pieces.Clear();
		GenerateInitialPieces();
		bonusLevelPoint = startBonusLevelPoint;
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
