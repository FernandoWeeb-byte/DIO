$('.owl-one').owlCarousel({
    loop:true,
    margin:10,
    center:true,
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
    },

})

$('.owl-two').owlCarousel({
    loop:true,
    margin: 20,
    responsive:{
        0:{
            items:2
        },
        600:{
            items:3
        },
        1000:{
            items:6
        }
    },

})


var owl = $('.owl-one')
function changeCarousel(id){
    owl.trigger('to.owl.carousel',id);
    
}

