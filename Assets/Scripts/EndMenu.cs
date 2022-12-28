using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] VoidEventChannel gameOverEventChannel;//��Ϸ����

    [SerializeField] AudioSource endMusicAudioSource;//�����������

    //UI
    [SerializeField] GameObject endMenuUI;//����˵�
    [SerializeField] Text scoreText;//������¼UI
    [SerializeField] Text resultScoreText;//�������

    [SerializeField] AnimationCurve showCurve;
    [SerializeField] AnimationCurve hideCurve;
    public float animationSpeed;


    private void OnEnable()
    {
        gameOverEventChannel.AddListener(GameEndMenuStartCoroutine);
    }
    private void OnDisable()
    {
        gameOverEventChannel.RemoveListener(GameEndMenuStartCoroutine);
    }
    public void GameEndMenuStartCoroutine()
    {
        StartCoroutine(nameof(GameEndMenuShow));
    }
    public IEnumerator GameEndMenuShow()
    {
        endMenuUI.SetActive(true);
        endMusicAudioSource.Play();
        resultScoreText.text = scoreText.text;
        float timer = 0f;
        while(timer <= 1f)
        {
            endMenuUI.transform.localScale = Vector3.one * showCurve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }
    }
    public void RestartGame()
    {
        StartCoroutine(nameof(GameEndMenuHide));
    }
    public IEnumerator GameEndMenuHide()
    {
        float timer = 0f;
        while(timer <= 1f)
        {
            endMenuUI.transform.localScale = Vector3.one * hideCurve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }
        endMenuUI.SetActive(false);
        endMusicAudioSource.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
