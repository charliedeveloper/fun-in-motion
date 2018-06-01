$.fn.FunInMotion = function () {
    function GifImages(
        categoryId,
        thumbnailSizeImageUrl,
        largeSizeImageUrl,
        SourceId) {

        this.CategoryId = categoryId;
        this.ThumbnailSizeImageUrl = thumbnailSizeImageUrl;
        this.LargeSizeImageUrl = largeSizeImageUrl;
    }

    var addtofavourite = function (imageId, categoryId, thumbnailSizeImageUrl, largeSizeImageUrl) {
        var imageModel = new GifImages(categoryId, thumbnailSizeImageUrl, largeSizeImageUrl);

        var that = document.getElementById(imageId);
        var thumbnailUrl = thumbnailSizeImageUrl;
        var largeImageUrl = largeSizeImageUrl;
        var sourceid = $(that).data('id');
        var adddtofav = !$(that).hasClass('addedtofav');

        $.ajax({
            url: "Giphy/AddToFavourites",
            dataType: 'json',
            type: "POST",
            contentType: 'application/json; charset-utf-8',
            data: '{"image":' + JSON.stringify(imageModel) + '}',
            success: function (data) {
                if (data.success) {
                    if (data.message === "add") {
                        $(that).addClass("addedtofav");
                        $(that).find('i').removeClass('heart-color-gray').addClass('heart-color-red');
                    } else {
                        $(that).removeClass("addedtofav");
                        $(that).find('i').removeClass('heart-color-red').addClass('heart-color-gray');
                    };
                } else {
                    alert('Failed');
                }
            }
        });
    }

    var addtogallery = function (imageId, categoryId, thumbnailSizeImageUrl, largeSizeImageUrl) {
        var imageModel = new GifImages(categoryId, thumbnailSizeImageUrl, largeSizeImageUrl);

        var thumbnailUrl = $(that).data('thumbnailurl');
        var largeImageUrl = $(that).data('largesizeurl');
        var sourceid = $(that).data('id');
        var adddtofav = !$(that).hasClass('addedtofav');
        $.ajax({
            url: "Giphy/AddToGallery",
            contentType: 'application/json',
            type: "POST",
            data: "{selectedImage:" + JSON.stringify(imageModel) + "}",
            success: function (data) {
                if (data.success) {
                    if (data.message === "add") {
                        $(that).addClass("addedtofav");
                        $(that).find('i').removeClass('heart-color-gray').addClass('heart-color-red');
                    } else {
                        $(that).removeClass("addedtofav");
                        $(that).find('i').removeClass('heart-color-red').addClass('heart-color-gray');
                    };
                } else {
                    alert('Failed');
                }
            }
        });
    }

    var movenextpage = function (pagenumber) {

    }

    var movepreviouspage = function (pagenumber) {

    }

    var searchgif = function (searchterm) {
        var searchterm = $('#search_term_entry').val();

        $.ajax({
            url: "Giphy/Search",
            dataType: 'html',
            type: "POST",
            data: { "searchterm": searchterm },
            success: function (data) {
                $('.searchresult').html(data);
            },
            error: function (xhr, status, error) {
                alert('mali: ' + error);
            }
        });
    }

    return {
        addtofavourite: addtofavourite,
        addtogallery: addtogallery,
        movenextpage: movenextpage,
        movepreviouspage: movepreviouspage,
        searchgif: searchgif
    }
}