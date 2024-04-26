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
        public GameObject BattleCanvas, PauseCanvas;
        private bool inBattle; 
        public bool InBattle { get { return inBattle; }
            set 
            {
                if (BattleManager.instance?.CurrentActor != null)
                    BattleCanvas.SetActive(value && BattleManager.instance.CurrentActor.tag == "Player");
                if (!value)
                    CameraControls.instance.OnOW(); 

                inBattle = value;
            } 
        }
        public bool InCutscene { get; set; }
        public bool IsPaused { get; set; }
        

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
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
