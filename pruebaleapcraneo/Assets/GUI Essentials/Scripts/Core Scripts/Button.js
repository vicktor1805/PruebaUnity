// Button.js
// Used for making a GUITexture function like a button

// Requires a GUITexture
@script RequireComponent(GUITexture)

var defaultTexture : Texture;
var hoverTexture : Texture;
var clickedTexture : Texture;
var receiver : GameObject;
var functionName : String = "";
var parameter : String = "";

private var mouseOver : boolean = false;
 
// Updates the texture when the mouse goes over the GUITexture
function OnMouseEnter() {
    guiTexture.texture = hoverTexture;
    mouseOver = true;
}

// Updates the texture when the mouse leaves the GUITexture
function OnMouseExit() {
    guiTexture.texture = defaultTexture;
    mouseOver = false;
}
 
// Updates the texture when the texture is clicked
function OnMouseDown() {
    guiTexture.texture = clickedTexture;
    
    if(receiver) {
        var name = gameObject.name;
        receiver.SendMessage(functionName, name);
    }
    
}
function setParameter(param) {
    this.parameter = param;
}
// Updates the texture when the mouse button is released and sends a message to the receiver
function OnMouseUp() {
    if (mouseOver) {
        guiTexture.texture = hoverTexture;
    } else {
        guiTexture.texture = defaultTexture;
    }
    
}

// Resets the button when it is disabled
function OnDisable() {
    guiTexture.texture = defaultTexture;
}

// Function to programmatically simulate pressing a button
function PressButton() {
    guiTexture.texture = clickedTexture;
    if (mouseOver) {
        guiTexture.texture = hoverTexture;
    } else {
        guiTexture.texture = defaultTexture;
    }
}


function setDefaultTexture(pDefaultTexture) {
    defaultTexture = pDefaultTexture;
}

function setHoverTexture(pHoverTexture) {
    hoverTexture = pHoverTexture;
}

function setClickedTexture(pClickedTexture) {
    clickedTexture = pClickedTexture;
}