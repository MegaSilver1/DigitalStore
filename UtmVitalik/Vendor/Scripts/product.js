document.addEventListener("DOMContentLoaded", function() {
    const screenshots = document.querySelectorAll(".screenshot-gallery img");

    screenshots.forEach(function(img) {
        img.addEventListener("click", function() {
            enlargeImage(img);
        });
    });

    function enlargeImage(img) {
        const overlay = document.createElement("div");
        overlay.classList.add("overlay");

        const enlargedImg = new Image();
        enlargedImg.src = img.src;
        enlargedImg.classList.add("enlarged-img");

        overlay.appendChild(enlargedImg);
        document.body.appendChild(overlay);

        overlay.addEventListener("click", function() {
            overlay.remove();
        });
    }document.addEventListener("DOMContentLoaded", function() {
        const screenshots = document.querySelectorAll(".screenshot-gallery img");

        screenshots.forEach(function(img) {
            img.addEventListener("click", function() {
                enlargeImage(img);
            });
        });

        function enlargeImage(img) {
            const overlay = document.createElement("div");
            overlay.classList.add("overlay");

            const enlargedImg = new Image();
            enlargedImg.src = img.src;
            enlargedImg.classList.add("enlarged-img");

            overlay.appendChild(enlargedImg);
            document.body.appendChild(overlay);

            overlay.addEventListener("click", function() {
                overlay.remove();
            });
        }
    });

});
