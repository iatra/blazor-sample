var bullshitContainer = {
    isBullshit : "absolutely!"
}

window.RegisterKeyDown = (instance) => {
    bullshitContainer.bullshit = (e) => invokeKeyPressed(instance, e);
    document.addEventListener("keydown", bullshitContainer.bullshit, false);
}

window.DeRegisterKeyDown = () => {
    document.removeEventListener("keydown", bullshitContainer.bullshit, false);
}

function invokeKeyPressed(instance, event) {
    instance.invokeMethodAsync("KeyPressed", serializeKeyboardEvent(event));
}

var serializeKeyboardEvent = function (e) {
    if (e) {
        var o = {
            Code: e.code
        };
        return o;
    }
};