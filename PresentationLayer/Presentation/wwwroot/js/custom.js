	
    // light box js
    		
		$('.portfolio_img_text').magnificPopup({
			delegate: '.img-link',
			type: 'image',
			tLoading: 'Loading image #%curr%...',
			mainClass: 'mfp-img-mobile',
			gallery: {
				enabled: true,
				navigateByImgClick: true,
				preload: [0,1]
			},
			image: {
				tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
				titleSrc: function(item) {
					return item.el.attr('title') + '<small></small>';
				}
			}
		});
    
    
    
    // Preloader 
    jQuery(window).on('load', function() {
        jQuery("#status").fadeOut();
        jQuery("#preloader").delay(450).fadeOut("slow");
    });
    
    
    
    // ===== Scroll to Top ==== //
    $(window).scroll(function() {
        if ($(this).scrollTop() >= 100) {
            $('#return-to-top').fadeIn(200);
        } else {
            $('#return-to-top').fadeOut(200);
        }
    });
    $('#return-to-top').click(function() {
        $('body,html').animate({
            scrollTop: 0
        }, 500);
    });	


    // index1 profile

    $(document).ready(function(){
      $(".login-btn").click(function(){
        $(".user-text").slideToggle();
      });
      $('body').on('click', function (e) {
            if (!$('.login-btn').is(e.target)
                && $('.login-btn').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.user-text').slideUp();
            }
        });
    });

    // post job


    $(document).ready(function(){
      $(".post-drop").click(function(){
        $(".post-page-wrapper").slideToggle();
      });
      $('body').on('click', function (e) {
            if (!$('.post-drop').is(e.target)
                && $('.post-drop').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.post-page-wrapper').slideUp();
            }
        });
    });


// index1 memnu

    $(document).ready(function(){
      $(".menu-click").click(function(){
        $(".menu-open").slideToggle();
      });
        $('body').on('click', function (e) {
            if (!$('.menu-click').is(e.target)
                && $('.menu-click').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.menu-open').slideUp();
            }
        });
    });


    $(document).ready(function(){
      $(".menu-click1").click(function(){
        $(".menu-open1").slideToggle();
      });
        $('body').on('click', function (e) {
            if (!$('.menu-click1').is(e.target)
                && $('.menu-click1').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.menu-open1').slideUp();
            }
        });
    });


    $(document).ready(function(){
      $(".menu-click2").click(function(){
        $(".menu-open2").slideToggle();
      });
     $('body').on('click', function (e) {
            if (!$('.menu-click2').is(e.target)
                && $('.menu-click2').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.menu-open2').slideUp();
            }
        });
    });



    $(document).ready(function(){
      $(".menu-click3").click(function(){
        $(".menu-open3").slideToggle();
      });
     $('body').on('click', function (e) {
            if (!$('.menu-click3').is(e.target)
                && $('.menu-click3').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.menu-open3').slideUp();
            }
        });
    });



    $(document).ready(function(){
      $(".menu-click4").click(function(){
        $(".menu-open4").slideToggle();
      });
     $('body').on('click', function (e) {
            if (!$('.menu-click4').is(e.target)
                && $('.menu-click4').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.menu-open4').slideUp();
            }
        });
    });



    $(document).ready(function(){
      $(".menu-click5").click(function(){
        $(".menu-open5").slideToggle();
      });
     $('body').on('click', function (e) {
            if (!$('.menu-click5').is(e.target)
                && $('.menu-click5').has(e.target).length === 0
                && $('.open').has(e.target).length === 0
            ) {
                $('.menu-open5').slideUp();
            }
        });
    });



    // 

    $('.frrelncer-slider .owl-carousel').owlCarousel({
        loop:true,
        margin:20,
        nav:true,
        autoplay: true,
        navText: ['<i class="fa fa-chevron-left" aria-hidden="true"></i>', '<i class="fa fa-chevron-right" aria-hidden="true"></i>'],
        smartSpeed: 1200,
        responsive:{
           0:{
                items:1
            },
            350:{
                items:1
            },
            600:{
                items:2
            },
            767:{
                items:3
            },
            1200:{
                items:4
            },
            1300:{
                items:5
            }
            
     
        }
    })



    $('.awesome-slider .owl-carousel').owlCarousel({
        loop:true,
        margin:30,
        nav:true,
        // autoplay: true,
        navText: ['<i class="fa fa-chevron-left" aria-hidden="true"></i>', '<i class="fa fa-chevron-right" aria-hidden="true"></i>'],
       
        smartSpeed: 1200,
        responsive:{
           0:{
                items:1
            },
            350:{
                items:1
            },
            600:{
                items:2
            },
            767:{
                items:2
            },
            1200:{
                items:2
            }
            
     
        }
    })





// index1 toggle


$(document).ready(function () {
    $(".sidebar-toggle , .sidebar-close").click(function () {
        $("#right-sidebar").toggleClass("open")
    });
});












   // ---------------Counter js index01 and index 02 page
      var isAlreadyRun = false;

      $(window).scroll( function(){
      
          $('.counter-main-wrapper, .about-main-wrapper').each( function(i){
      
              var bottom_of_object = $(this).position().top + $(this).outerHeight() / 2;
              var bottom_of_window = $(window).scrollTop() + $(window).height();
      
      
                  if( bottom_of_window > ( bottom_of_object + 20 )  ){
              if (!isAlreadyRun) {
                $('.counter-count').each(function () {
                      
                        $(this).prop('con counter-right-border', 0).animate({
                            Counter: $(this).text()
                        }, {
                                duration: 3500,
                                easing: 'swing',
                                step: function (now) {
                                    $(this).text(Math.ceil(now));
                                }
                            });
                      });
              }
                      isAlreadyRun = true;
                  }
          }); 
      
      });      
         /*--- Responsive Menu Start ----*/
		//  $(".toggle-main-wrapper , #toggle_close").on("click", function () {
        //     var w = $('#sidebar').width();
        //     var pos = $('#sidebar').offset().right;

        //     if (pos === 0) {
        //         $("#sidebar").animate({ "right": -w }, "slow");
        //     }
        //     else {
        //         $("#sidebar").animate({ "right": "0" }, "slow");
        //     }

        // });
		// responsive sab menu
		(function ($) {
            $(document).ready(function () {

                $('#cssmenu li.active').addClass('open').children('ul').show();
                $('#cssmenu li.has-sub>a').on('click', function () {
                    $(this).removeAttr('href');
                    var element = $(this).parent('li');
                    if (element.hasClass('open')) {
                        element.removeClass('open');
                        element.find('li').removeClass('open');
                        element.find('ul').slideUp(200);
                    }
                    else {
                        element.addClass('open');
                        element.children('ul').slideDown(200);
                        element.siblings('li').children('ul').slideUp(200);
                        element.siblings('li').removeClass('open');
                        element.siblings('li').find('li').removeClass('open');
                        element.siblings('li').find('ul').slideUp(200);
                    }
                });

            });
        })(jQuery);
// menu fixed
$(window).scroll(function () {
    var window_top = $(window).scrollTop() + 1;
    if (window_top > 100) {
      $('.menu-items-wrapper').addClass('menu-fixed animated fadeInDown');
    } else {
      $('.menu-items-wrapper').removeClass('menu-fixed animated fadeInDown');
    }
  });
  
// toggle cross btn js
$(".toggle-main-wrapper , #toggle_close").on("click", function () {
    $("#sidebar").toggleClass("open")
});


  	// ---------------Counter js index01 and index 02 page
      var isAlreadyRun = false;

      $(window).scroll( function(){
      
          $('.counter-main-wrapper, .about-main-wrapper').each( function(i){
      
              var bottom_of_object = $(this).position().top + $(this).outerHeight() / 2;
              var bottom_of_window = $(window).scrollTop() + $(window).height();
      
      
                  if( bottom_of_window > ( bottom_of_object + 20 )  ){
              if (!isAlreadyRun) {
                $('.counter-count').each(function () {
                      
                        $(this).prop('con counter-right-border', 0).animate({
                            Counter: $(this).text()
                        }, {
                                duration: 3500,
                                easing: 'swing',
                                step: function (now) {
                                    $(this).text(Math.ceil(now));
                                }
                            });
                      });
              }
                      isAlreadyRun = true;
                  }
          }); 
      
      });




// index 1 testi

$('.testi-slider .owl-carousel').owlCarousel({
    loop:true,
    margin:20,
    nav:true,
    autoplay: false,
    smartSpeed: 1200,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:2
        }
    }
})





$('.img-icon .owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
})


















// share fixed button js

function actionToggleOne() {
    let action = document.querySelector('.contact-action');
    action.classList.toggle('open1');
}
function actionToggleTwo() {
    let action = document.querySelector('.action-1');
    action.classList.toggle('open2');
}
function actionToggleThree() {
    let action = document.querySelector('.action-2');
    action.classList.toggle('open3');
}
function actionToggleFour() {
    let action = document.querySelector('.action-3');
    action.classList.toggle('open4');
}


 
  
// counter js
