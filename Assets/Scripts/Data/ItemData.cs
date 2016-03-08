using UnityEngine;
using System.Collections;

public class ItemData : MonoBehaviour {

	private static int surikenCount;
	private static int dragonCount;
	private static int chuongCount;
	private static int upCount;
	private static float timeMagnetCount;
	private static bool isUpgradedSlash;

	public static bool IsUpgradedSlash {
		get {
			return isUpgradedSlash;
		}
		set {
			isUpgradedSlash = value;
		}
	}

	public static float TimeMagnetCount {
		get {
			return timeMagnetCount;
		}
		set {
			timeMagnetCount = value;
		}
	}

	public static int UpCount {
		get {
			return upCount;
		}
		set {
			upCount = value;
		}
	}

	public static int ChuongCount {
		get {
			return chuongCount;
		}
		set {
			chuongCount = value;
		}
	}

	public static int DragonCount {
		get {
			return dragonCount;
		}
		set {
			dragonCount = value;
		}
	}

	public static int SurikenCount {
		get {
			return surikenCount;
		}
		set {
			surikenCount = value;
		}
	}

	public static void AddSuriken(int num) {
		surikenCount += num;
	}

	public static void AddDragon(int num) {
		dragonCount += num;
	}

	public static void AddChuong(int num) {
		chuongCount += num;
	}

	public static void AddUp(int num) {
		upCount += num;
	}

	public static void AddTimeMagnet(float num) {
		timeMagnetCount += num;
		if (timeMagnetCount < 0)timeMagnetCount = 0;
	}

	public static void ResetCount() {
		surikenCount = 0;
		dragonCount = 0;
		chuongCount = 0;
		upCount = 0;
		timeMagnetCount = 0;
		isUpgradedSlash = false;
	}
}
