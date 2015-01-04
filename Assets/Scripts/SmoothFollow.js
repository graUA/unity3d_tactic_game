/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
var target : Transform;
// The distance in the x-z plane to the target
var distance = 10.0;
// the height we want the camera to be above the target
var height = 5.0;
// How much we 
var heightDamping = 2.0;

// Place the script in the Camera-Control group in the component menu
@script AddComponentMenu("Camera-Control/Smooth Follow")


function LateUpdate () {
	// Early out if we don't have a target
	if (!target)
		return;
	
	// Calculate the current rotation angles
	var wantedHeight = target.position.y + height;
	
	var currentHeight = transform.position.y;

	// Damp the height
	currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
	
	// Set the position of the camera on the x-z plane to:
	// distance meters behind the target
	transform.position = target.position;
	transform.position -= Vector3.forward * distance;

	// Set the height of the camera
	transform.position.y = currentHeight;
	
	// Always look at the target
	transform.LookAt (target);
}