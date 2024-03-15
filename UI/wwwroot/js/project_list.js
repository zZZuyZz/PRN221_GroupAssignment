document.addEventListener('DOMContentLoaded', function () {
    $(".show-more a").on("click", function (e) {
        e.preventDefault();
        var $this = $(this);
        var $content = $("div#mainContent");
        var linkText = $this.text();

        if (linkText === "Xem thêm") {
            
            $content.switchClass("hideContent", "showContent", 400);
            setTimeout(function () {
                $(".gradient").addClass("d-none");
                $this.text("Rút gọn");
            }, 500);
        } else {
            $content.switchClass("showContent", "hideContent", 400);
            $(".gradient").removeClass("d-none");
            $this.text("Xem thêm");
        };

    })
});