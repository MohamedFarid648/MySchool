/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


$(document).ready(function () {

    $(".delete_answer").click(function () {
       // e.preventdefault;

        // $(".answer_div").remove();
      //  $(this).parents('.answer_div').remove();
        $(this).closest(".answer_div").remove();

    });
    
});