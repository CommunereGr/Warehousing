(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            const logo = document.getElementsByClassName('link'); //For Changing The Link On The Logo Image
            logo[0].innerHTML = logo[0].innerHTML + "<i style='padding: 0 10px'>Communere</i>";
            logo[0].href = "https://communere.com/";
            logo[0].target = "_blank";
            logo[0].children[0].alt = "Communere";
            logo[0].children[0].src = "/swagger-ui/favicon.jpg"; //For Changing The Logo Image
            logo[0].children[0].height = "80"
            logo[0].children[0].classList.add("rounded");
        });
    });
})();