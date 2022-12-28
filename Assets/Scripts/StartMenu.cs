using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] AudioSource startMenuMusicPlayer;//��Ϸ��ʼ�˵�����
    [SerializeField] AudioSource gameMusicAudioSource;//��Ϸ��������
    [SerializeField] AudioSource changeAudioSource;//�л�ʱ����Ч

    //UI
    [SerializeField] AnimationCurve showCurve;
    [SerializeField] AnimationCurve hideCurve;
    [SerializeField] GameObject startMenuUI;
    [SerializeField] float showSpeed;

    //��Ч
    [SerializeField] AudioClip changeSFX;
    private void Awake()
    {
        startMenuUI.SetActive(true);
        StartCoroutine(nameof(StartMenuAnimationShow));
    }

    public void StartGame()
    {
        StartCoroutine(nameof(StartMenuAnimationHide));
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    IEnumerator StartMenuAnimationShow()
    {
        float timer = 0f;
        while(timer <= 1f)
        {
            startMenuUI.transform.localScale = Vector3.one * showCurve.Evaluate(timer);
            timer += Time.deltaTime * showSpeed;
            yield return null;
        }
    }
    IEnumerator StartMenuAnimationHide()
    {
        startMenuMusicPlayer.Stop();
        changeAudioSource.PlayOneShot(changeSFX);
        float timer = 0f;
        while(timer <= 1f)
        {
            startMenuUI.transform.localScale = Vector3.one * hideCurve.Evaluate(timer);
            timer += Time.deltaTime * showSpeed;
            yield return null;
        }
        gameMusicAudioSource.Play();
        startMenuUI.SetActive(false);
    }

}
