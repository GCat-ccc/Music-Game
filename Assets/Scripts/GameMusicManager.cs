using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    private AudioSource gameMusic;
    [SerializeField] VoidEventChannel gameOverEventChannel;

    private bool IsStart = false;
    private void Start()
    {
        gameMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(gameMusic.isPlaying && !IsStart)
        {
            Debug.Log("��Ϸ��ʼ");
            IsStart = true;
            StartCoroutine(AudioPlayFinished(gameMusic.clip.length));
        }
    }
    IEnumerator AudioPlayFinished(float time)
    {
        yield return new WaitForSeconds(time);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("��Ϸ����");
        gameMusic.Stop();
        gameOverEventChannel.Broadcast();
    }
}
