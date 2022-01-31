using System.Collections;
using Game;
using Player;
using UnityEngine;

namespace Bits
{
    public class BitsManager : MonoBehaviour
    {
        [SerializeField] private BitsCollection bitsCollection;
        [Space] 
        [SerializeField] private GameObject bitPrefab;
        [SerializeField] private Transform bitContainer;
        [SerializeField] private float timeBeforeSpawn;
        private void Awake()
        {
            Init();
        }
        
        private void Init()
        {
            bitsCollection.Init(bitPrefab, bitContainer);
            bitsCollection.UpdatePlayerScore += OnUpdatePlayerScore;
            GameState.GameStatusChanged += OnGameStatusChanged;
        }
        
        private void OnUpdatePlayerScore(int newPoints)
        {
            PlayerInfo.UpdateScore(newPoints);
        }
        
        private void OnGameStatusChanged(GameState.GameStatus status)
        {
            switch (status)
            {
                case GameState.GameStatus.GameStarted:
                {
                    StartSpawn();
                    break;
                }
                case GameState.GameStatus.GameFinished:
                {
                    StopSpawn();
                    break;
                }
            }
        }

        private void StartSpawn()
        {
            StartCoroutine(GenerateBits());
        }

        private void StopSpawn()
        {
            StopAllCoroutines();
            bitsCollection.StopAll();
        }

        IEnumerator GenerateBits()
        {
            while (true)
            {
                bitsCollection.CreateNewBit();
                yield return new WaitForSeconds(timeBeforeSpawn);
            }
        }
    }
}