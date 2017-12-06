//menu battons
var Play = false;
var Info = false;
var Exit = false;

//cameras
var camera1:Camera;
var camera2:Camera;

function OnMouseUp() {
    
    if (Play == true) {
        Application.LoadLevel(1);
    }
    if (Info == true) {
        camera1.enabled = false;
        camera2.enabled = true;
    }
    if (Exit == true) {
        Application.Quit();
    }
}