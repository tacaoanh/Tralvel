

//menu
$(function () {
    $('.animated > li').hover(function () {
        $(this).find('div[class^="container-"]').stop().slideDown('fast');
    },
	function () {
	    $(this).find('div[class^="container-"]').stop().slideUp('slow');
	});
});

//end menu
//slide
$(document).ready(function () {

    var time = 7; // time in seconds

    var $progressBar,
        $bar,
        $elem,
        isPause,
        tick,
        percentTime;

    //Init the carousel
    $(".owl-travel-slide").owlCarousel({
        slideSpeed: 500,
        paginationSpeed: 500,
        singleItem: true,
        afterInit: progressBar,
        afterMove: moved,
        startDragging: pauseOnDragging
    });
    function progressBar(elem) {
        $elem = elem;
        //build progress bar elements
        buildProgressBar();
        //start counting
        start();
    }

    function buildProgressBar() {
        $progressBar = $("<div>", {
            id: "progressBar"
        });
        $bar = $("<div>", {
            id: "bar"
        });
        $progressBar.append($bar).prependTo($elem);
    }

    function start() {
        //reset timer
        percentTime = 0;
        isPause = false;
        //run interval every 0.01 second
        tick = setInterval(interval, 10);
    };

    function interval() {
        if (isPause === false) {
            percentTime += 1 / time;
            $bar.css({
                width: percentTime + "%"
            });
            //if percentTime is equal or greater than 100
            if (percentTime >= 100) {
                //slide to next item 
                $elem.trigger('owl.next')
            }
        }
    }

    //pause while dragging 
    function pauseOnDragging() {
        isPause = true;
    }

    //moved callback
    function moved() {
        //clear interval
        clearTimeout(tick);
        //start again
        start();
    }
});

//về top
$(function () {
    $(document).on('scroll', function () {
        if ($(window).scrollTop() > 100) {
            $('.smoothscroll-top').addClass('show');
        } else {
            $('.smoothscroll-top').removeClass('show');
        }
    });
    $('.smoothscroll-top').on('click', scrollToTop);
});
function scrollToTop() {
    verticalOffset = typeof (verticalOffset) != 'undefined' ? verticalOffset : 0;
    element = $('body');
    offset = element.offset();
    offsetTop = offset.top;
    $('html, body').animate({ scrollTop: offsetTop }, 600, 'linear').animate({ scrollTop: 25 }, 200).animate({ scrollTop: 0 }, 150).animate({ scrollTop: 0 }, 50);
}
//begin rating
    $(document).on('ready', function () {
       
        $('.rating-usd').rating({
            containerClass: 'is-heart',
            defaultCaption: '{rating} hearts',
            starCaptions: function (rating) {
                return rating == 1 ? 'One usd' : rating + ' usd';
            },
            filledStar: '<i class="glyphicon glyphicon-usd"></i>',
            emptyStar: '<i class="glyphicon glyphicon-usd"></i>'
        });      

        $('.rating,.rating-usd').on(
            'change', function () {
             console.log('Rating selected: ' + $(this).val());
        });
    });

//end

    var wow = new WOW(
      {
          boxClass: 'wow',  
          animateClass: 'animated', 
          offset: 0,         
          mobile: true,      
          live: true,   
          callback: function (box) {          
          },
          scrollContainer: null 
      }
    );
    wow.init();

