$(document).ready(function () {



    //Get value from textbox to its radio button
    $('.the_answer').keyup(function () {
        $(this).parent().find('input[type=radio]').val($(this).val());
    });
});