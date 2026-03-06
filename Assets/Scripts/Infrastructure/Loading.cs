using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Infrastructure
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private Image m_loading;
        
        private string m_nameScene;
        
        public void LoadScene(string nameScene)
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadSceneAsync(nameScene));
        }

        private IEnumerator LoadSceneAsync(string nameScene)
        {
            m_loading.fillAmount = 0;
            
            AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
            yield return operation;
            
            m_loading.fillAmount = 0.5f;

            const int steps = 10;
            var delta = 1 - m_loading.fillAmount;

            for (var i = 0; i < steps; i++)
            {
                yield return new WaitForSeconds(0.5f);
                m_loading.fillAmount += delta / steps;
            }
            
            gameObject.SetActive(false);
        }
    }
}