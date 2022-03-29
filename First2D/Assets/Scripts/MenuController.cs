using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Slider volumeSlider;
    Button startButton;
    AudioSource backgroundMusic;
    float previousState;
    void Awake()
    {
        DestroyAllDontDestroyOnLoadObjects();
    }
    void Start()
    {
        startButton = GameObject.Find("StartGame").GetComponent<Button>();
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        backgroundMusic = GameObject.Find("Music").GetComponent<AudioSource>();
        backgroundMusic.volume = volumeSlider.value;
        if(volumeSlider.value != 0f) {
            previousState = 0f;
        }
        else
        {
            previousState = 0.1f;
        }
    }

    public void StartGame() {
        DontDestroyOnLoad(backgroundMusic);
        SceneManager.LoadScene("Level1");
    }

    public void SetVolume(float newVolume) {
        backgroundMusic.volume = newVolume;
    }

    public void SetVolumeOnOff() {
        var temp = volumeSlider.value;
        volumeSlider.value = previousState;
        previousState = temp;
    }

    public void DestroyAllDontDestroyOnLoadObjects() {
        var go = new GameObject("Temp");
        DontDestroyOnLoad(go);
        foreach(var root in go.scene.GetRootGameObjects()) {
            if(root.tag == "Music" || root.tag == "Temp") {
                Destroy(root);
            }
        }
    }
}
