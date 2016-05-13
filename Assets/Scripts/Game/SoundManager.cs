using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
	public AudioSource homeMusicSource;                 //Drag a reference to the audio source which will play the music.
	public AudioSource storyMusicSource;
	public AudioSource playMusicSource;

	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
	public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
	public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

	public AudioClip phitieuAudio;
	public AudioClip playerInjuredAudio;
	public AudioClip PlayerDeadAudio;
	public AudioClip chemAudio;
	public AudioClip buttonClickAudio;
	public AudioClip collectAudio;
	public AudioClip buyCompletedAudio;
	public AudioClip chuongAudio;
	public AudioClip dragonAudio;

	private BannerView bannerView;
	private InterstitialAd interstitial;
	private AdRequest request;
	string adUnitId = "ca-app-pub-7554197261759205/9339882577";
	string adUnitIdFull = "ca-app-pub-7554197261759205/1816615773";

	Dictionary <string, AudioClip> map;

	void Awake (){
		
		if (instance == null) {
			map = new Dictionary<string, AudioClip>();
			map.Add(GameConst.PHI_TIEU_AUDIO, phitieuAudio);
			map.Add(GameConst.PLAYER_INJURE_AUDIO, playerInjuredAudio);
			map.Add(GameConst.PLAYER_DEAD_AUDIO, PlayerDeadAudio);
			map.Add(GameConst.PLAYER_CHEM_AUDIO, chemAudio);
			map.Add(GameConst.BUTTON_CLICK_AUDIO, buttonClickAudio);
			map.Add(GameConst.COLLECT_AUDIO, collectAudio);
			map.Add(GameConst.BUY_AUDIO, buyCompletedAudio);
			map.Add(GameConst.CHUONG_AUDIO, chuongAudio);
			map.Add(GameConst.DRAGON_AUDIO, dragonAudio);

			if (!GameConst.IS_TEST) {
				
				bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
				request = new AdRequest.Builder()
					.AddTestDevice("4FDE60316E3C4F65861816F42229CBE9")  // My test device.
					.Build();;
				bannerView.LoadAd(request);


				// Initialize an InterstitialAd.
				interstitial = new InterstitialAd(adUnitIdFull);
				// Create an empty ad request.
				// Load the interstitial with the request.
				interstitial.LoadAd(request);

				interstitial.OnAdClosed += HandleOnAdClosed;

				//			Admob.Instance().initAdmob("ca-app-pub-7554197261759205/9339882577", "ca-app-pub-7554197261759205/1816615773");
				Debug.Log("init admob");
				//			Admob.Instance().setTesting(true);
				//			Admob.Instance().setForChildren(true);
				//			Admob.Instance().loadInterstitial(); 

				PlayGamesPlatform.Activate ();

				Authen();
			}


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

	public void PlayMusic(string musicName) {
		if (DataPref.getNumData(GameConst.MUSIC_KEY) == 1) return;

		homeMusicSource.Stop();
		playMusicSource.Stop();
		storyMusicSource.Stop();

		if (musicName == GameConst.HOME_MUSIC) {
			homeMusicSource.Play();
		} else if (musicName == GameConst.STORY_MUSIC) {
			storyMusicSource.Play();
		} else if (musicName == GameConst.PLAY_MUSIC) {
			playMusicSource.Play();
		}
	}

	public void StopMusic() {
		homeMusicSource.Stop();
		playMusicSource.Stop();
		storyMusicSource.Stop();
	}


	public void ShowLeaderBoard() {
		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (GPGSIds.leaderboard_stickman_quest_leaderboard);
	}

	public void Authen() {
		if (!GameConst.IS_TEST) {
			// authenticate user:
			Social.localUser.Authenticate((bool success) => {
				// handle success or failure
				Debug.Log("status authen: " + success);
//				if (success)
//					((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (GPGSIds.leaderboard_stickman_quest_leaderboard);
			});
		}
	}

	public void ShowBanner() {
		bannerView.Show();
	}

	public void ShowBanner2() {
		bannerView = new BannerView(adUnitId, new AdSize(415, 55), AdPosition.BottomLeft);
		bannerView.LoadAd(request);
		bannerView.Show();
	}

	public void HideBanner() {
		if (!GameConst.IS_TEST) {
			bannerView.Hide();
			bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
			bannerView.LoadAd(request);
			bannerView.Hide();	
		}
	}


	public void ShowFullAd() {
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
	}

	public void HandleOnAdClosed(object sender, System.EventArgs args)
	{
		print("OnAdLoaded event received.");
		// Handle the ad loaded event.
		interstitial.LoadAd(request);
	}
}
