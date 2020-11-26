var elements = document.getElementsByClassName("section-item-none");

let toggleColors = function() {

    var item = this;
    if(item.className == `section-item-blue`) {
        item.className = `section-item-none`;
    } else if(item.className == `section-item-none`) {
        item.className = `section-item-blue`;
    }
};


function initializeEventListeners() {

    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = toggleColors;
    }

}

initializeEventListeners();