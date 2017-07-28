/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


$(document).ready(function () {


    $(".add_another_answer").click(function () {

        $(".container_answer").append("<div class='row answer_div'>  <div class='col-lg-2'> <input type='radio' name='right_answer' /> </div><div class='col-lg-6'> <input type='text' placeholder='Answer' name='the_answer' /> </div> <div class='col-lg-2'>  <input type='number' width='20' placeholder='Score' name='Score' /> </div><div class='col-lg-2'> <input type='button' class='btn delete_answer' value='Delete' />  </div> </div><br>");



    });

});