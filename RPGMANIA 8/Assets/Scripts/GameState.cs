using Playable.Entities.Battle;
using UnityEngine;


namespace Playable
{
    using Playable.Entities;
    using Stats;
    using UnityEngine.SceneManagement;

    public class GameState : MonoBehaviour
    {
        public static GameState instance;
        public GameObject BattleCanvas, PauseCanvas, DefeatCanvas;
        public AudioManager AudioManager; 
        private bool inBattle; 
        public bool InBattle { get { return inBattle; }
            set 
            {
                try
                {
                    if (BattleManager.instance?.CurrentActor != null)
                        BattleCanvas.SetActive(value && BattleManager.instance.CurrentActor.tag == "Player");
                    if (!value)
                        CameraControls.instance.OnOW();
                }
                catch { }

                inBattle = value;
            } 
        }
        public bool InCutscene { get; set; }
        public bool IsPaused { get; set; }
        

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            InBattle = false; 

            try
            {
                BattleManager.instance.zone = FindObjectOfType<BattleZone>();
            }
            catch { }
            try
            {
                AudioManager.PlaySound(arg0.name);
            }
            catch 
            {
                AudioManager.PlaySound("");
            }
        }

        public void Pause()
        {
            bool pause = Time.timeScale > 0;

            Time.timeScale = pause ? 0 : 1;
            PauseCanvas.SetActive(pause);
        }

        public void LoadOverWorld()
        {
            SceneManager.LoadScene("OverWorld");
        }

        public void LoadLevel(string  level)
        {
            SceneManager.LoadScene(level); 
        }

        public void ReloadLevel()
        {
            PlayerRef.instance.Stats.Rest(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
        }

        public void Quit()
        {
            PlayerRef.instance.Stats.Rest();
            Application.Quit();
        }

    }
}
