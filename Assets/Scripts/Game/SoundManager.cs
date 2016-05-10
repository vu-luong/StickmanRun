using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
	public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
	public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
	public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

	public AudioClip phitieuAudio;
	public AudioClip playerInjuredAudio;
	public AudioClip PlayerDeadAudio;
	public AudioClip chemAudio;
	public AudioClip buttonClickAudio;

	Dictionary <string, AudioClip> map;

	void Awake (){
		
		if (instance == null) {
			map = new Dictionary<string, AudioClip>();
			map.Add(GameConst.PHI_TIEU_AUDIO, phitieuAudio);
			map.Add(GameConst.PLAYER_INJURE_AUDIO, playerInjuredAudio);
			map.Add(GameConst.PLAYER_DEAD_AUDIO, PlayerDeadAudio);
			map.Add(GameConst.PLAYER_CHEM_AUDIO, chemAudio);
			map.Add(GameConst.BUTTON_CLICK_AUDIO, buttonClickAudio);

			instance = this;
		}
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}

	//Used to play single sound clips.
	public void PlaySingleByName(string name)
	{
		if (DataPref.getNumData(GameConst.SOUND_KEY) == 1) return;
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = map[name];

		//Play the clip.
		efxSource.Play ();
	}

	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip)
	{
		if (DataPref.getNumData(GameConst.SOUND_KEY) == 1) return;
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = clip;

		//Play the clip.
		efxSource.Play ();
	}


	//RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
	public void RandomizeSfx (params AudioClip[] clips) {
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);

		//Choose a random pitch to play back our clip at between our high and low pitch ranges.
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = randomPitch;

		//Set the clip to the clip at our randomly chosen index.
		efxSource.clip = clips[randomIndex];

		//Play the clip.
		efxSource.Play();
	}

	public void Vibrate() {
		if (DataPref.getNumData(GameConst.VIBRATE_KEY) == 1) return;
//		Handheld.Vibrate();
		Vibration.Vibrate(50);
	}
}
