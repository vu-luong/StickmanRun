
var targetMaterialSlot:int=0;
//var scrollThis:Material;
var speedY:float=0.5;
var speedX:float=0.0;
private var timeWentX:float=0;
private var timeWentY:float=0;

//var renderer:SpriteRenderer;
function Start () {
//	renderer = gameObject.GetComponent(HingeJoint)
}

function Update () {
timeWentY += Time.deltaTime*speedY;
timeWentX += Time.deltaTime*speedX;


//renderer.materials[targetMaterialSlot].SetTextureOffset ("_MainTex", Vector2(timeWentX, timeWentY));


}

function OnEnable(){

//	renderer.materials[targetMaterialSlot].SetTextureOffset ("_MainTex", Vector2(0, 0));
	timeWentX = 0;
	timeWentY = 0;
}