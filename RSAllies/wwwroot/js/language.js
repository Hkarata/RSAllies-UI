$(document).ready(function() {
    // Check the language setting in local storage
    let isEnglish = localStorage.getItem('isEnglish');

    if (isEnglish === null) {
        // Default to English if no language setting is found
        isEnglish = 'true';
        localStorage.setItem('isEnglish', isEnglish);
    }

    // Show/hide divs based on the language setting
    showHideDivs(isEnglish);

    $(".language").click(function() {
        let language = $(this).text();

        // Set isEnglish to 'true' if English is selected, 'false' otherwise
        isEnglish = (language === 'English') ? 'true' : 'false';

        // Save the language setting in local storage
        localStorage.setItem('isEnglish', isEnglish);

        // Show/hide divs based on the language setting
        showHideDivs(isEnglish);
    });
});

function showHideDivs(isEnglish) {
    if (isEnglish === 'true') {
        $('.english').show();
        $('.swahili').hide();
    } else {
        $('.english').hide();
        $('.swahili').show();
    }
}
