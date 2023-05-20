$(document).ready(function () {


    $(document).on("click", ".show-more-btn", function () {
        let parent = $("#parent-elem")

        let skipCount = $(parent).children().length;

        let productsCount = $("#products").attr("data-count")

        $.ajax({
            url: `shop/showmore?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                $(parent).append(res)
            }
        })
    })


})