
let toggle = function() {
    let popup = document.getElementById(`popup`);

    if(popup.className == `settings-popup`) {
        popup.className = `popup-none`;
    } else if(popup.className == `popup-none`) {
        popup.className = `settings-popup`;
    }
};


function initializeEventListeners() {
    let settingsButton = document.getElementById(`settings-button`);
    settingsButton.onclick = toggle;
}

initializeEventListeners();