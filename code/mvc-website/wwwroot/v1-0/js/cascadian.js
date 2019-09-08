"use strict";

(function ($) {

	/*-------------------------------------
		Loader
	-------------------------------------*/
    $(window).load(function () {
        console.log('Entering cascadian.Load function');
        if (window.webPSupport===false) {
            $('.nowebpsupport').each(function () {

                var fallBackImage = $(this).attr('fallback-image');
                alert("Substituing with " + window.legacyImagesUrl + fallBackImage);

                if (fallBackImage) {
                    $(this).css('background-image', 'url(' + window.legacyImagesUrl + fallBackImage + ')');
                }
            });
        }

       

    });
})(jQuery);
