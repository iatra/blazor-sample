const handlersReferenceContainer = {
    isBullshit: "absolutely!"
};

window.RegisterCsHandlers = (instance) => {
    handlersReferenceContainer.keyDown = (e) => invokeKeyPressed(instance, e);
    handlersReferenceContainer.touchStart = (e) => invokeTouchStart(instance, e);
    handlersReferenceContainer.touchEnd = (e) => invokeTouchEnd(instance, e);
    
    document.addEventListener("keydown", handlersReferenceContainer.keyDown, false);
    document.addEventListener("touchmove", handleTouchMove, false);
    
    const doc = document.getElementById("game-board");
    doc.addEventListener("touchstart", handlersReferenceContainer.touchStart, false);
    doc.addEventListener("touchend", handlersReferenceContainer.touchEnd, false);
};

function handleTouchMove(event) {
    const className = event.target.className;
    if (className.includes('square')) {
        event.preventDefault();
    }
}

window.DeregisterCsHandlers = () => {
    document.removeEventListener("keydown", handlersReferenceContainer.keyDown, false);
    document.removeEventListener("touchmove", handleTouchMove, false);
    
    const doc = document.getElementById("game-board");
    doc.removeEventListener("touchstart", handlersReferenceContainer.touchStart, false);
    doc.removeEventListener("touchend", handlersReferenceContainer.touchEnd, false);

    handlersReferenceContainer.keyDown = null;
    handlersReferenceContainer.touchStart = null;
    handlersReferenceContainer.touchEnd = null;
};

function invokeKeyPressed(instance, event) {
    if (event) {
        // noinspection JSUnresolvedFunction
        instance.invokeMethodAsync("KeyDown", event.code);
    }
}

function invokeTouchStart(instance, event) {
    if (event) {
        let touch = event.touches[0];

        // noinspection JSUnresolvedFunction
        instance.invokeMethodAsync("TouchStart", touch.clientX, touch.clientY);
    }
}

function invokeTouchEnd(instance, event) {
    if (event) {
        if (event) {
            let touch = event.touches[0];

            // noinspection JSUnresolvedFunction
            instance.invokeMethodAsync("TouchEnd", touch.clientX, touch.clientY);
        }
    }
}