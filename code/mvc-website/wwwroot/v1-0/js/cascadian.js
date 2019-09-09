"use strict";

(function ($) {

	/*-------------------------------------
		Loader
	-------------------------------------*/
    $(window).load(function () {

        if (window.webPSupport === false) {
            var count = 0;
            $('.nowebpsupport').each(function () {

                var fallBackImage = $(this).attr('fallback-image');
                

                if (fallBackImage) {
                    $(this).css('background-image', 'url(' + window.legacyImagesUrl + fallBackImage + ')');
                    count++;
                }
            });

            console.log('A total of ' + count + 'substitutions where made.');
        }
    });
})(jQuery);
