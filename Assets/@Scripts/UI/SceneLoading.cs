using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CatLive.UI
{
    public class SceneLoading : MonoBehaviour
    {
        [SerializeField] private Image _loadingImage;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _progressText;

        [Range(0.1f, 3f)] [SerializeField] private float _speed = 1;
        [Range(0.1f, 3f)] [SerializeField] private float _fadeSpeed = 1;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            StartCoroutine(AsyncLoad(1));
        }

        private IEnumerator AsyncLoad(int index)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(index);
            while (_loadingImage.fillAmount != 1 || !operation.isDone)
            {
                ProgressUI(operation.progress);
                yield return new WaitForEndOfFrame();
            }
            float alpha = 1;
            while (alpha > 0.1f)
            {
                _canvasGroup.alpha = alpha;
                alpha -= Time.deltaTime * _fadeSpeed;
                yield return new WaitForEndOfFrame();
            }
            Destroy(gameObject);
        }

        private void ProgressUI(float progress)
        {
            _loadingImage.fillAmount = Mathf.Min(progress / 0.9f, _loadingImage.fillAmount + (Time.deltaTime * _speed));
            _progressText.text = string.Format("{0:0}%", _loadingImage.fillAmount * 100);
        }
    }
}