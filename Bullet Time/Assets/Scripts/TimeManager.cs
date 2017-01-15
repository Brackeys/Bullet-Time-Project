using UnityEngine;
using UnityEngine.Audio;

public class TimeManager : MonoBehaviour {

	public float slowdownFactor = 0.05f;
	public float slowdownLength = 2f;

    public AudioMixer MasterMixer;

	void Update ()
	{
		Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        float pitch = Mathf.Clamp(75 + (25 * Time.timeScale), 0, 100) / 100;
        MasterMixer.SetFloat("MusicPitch", pitch);
	}

	public void DoSlowmotion ()
	{
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}

}
