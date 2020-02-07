var pnl = document.getElementById("pnlOut");
var btnCerca = document.getElementById("btnCerca");
var txt = document.getElementById("txtCerca");
var btnAutori = document.getElementById("btnAutore");
var btnVoti = document.getElementById("btnVoti");
var btnValuta= document.getElementById("btnValuta");
var cercato = false;
var btnHome = document.getElementById("btnHome");

var index = 0;
var pagecount = 20;
var x = false;

document.addEventListener("DOMContentLoaded", function () {
    getSWData("https://programming-quotes-api.herokuapp.com/quotes");
});

btnCerca.addEventListener("click", function () {
    cerca("https://programming-quotes-api.herokuapp.com/quotes");
});

btnHome.addEventListener("click", function () {
    pnl.innerHTML = "";
    getSWData("https://programming-quotes-api.herokuapp.com/quotes");
});

function getSWData(url) {
    var list = 0;
    fetch(url).then(function (response) {
        return response.json();
    }).then(function (data) {
        list = data.count;

        console.log(data);
        for (let i = 0; i < data.length; i++) {
            var column = document.createElement("div");
            column.classList.add("col-6");
            column.classList.add("offset-3");

            var card = document.createElement("div");
            card.classList.add("card");
            card.classList.add("mt-4");
            card.classList.add("text-center");
            

            var cardtitle = document.createElement("div");
            cardtitle.classList.add("card-header");
            cardtitle.classList.add("ml-0");
            cardtitle.classList.add("mr-0");
            cardtitle.setAttribute("width", "100%");

            var carddescription = document.createElement("p");
            carddescription.classList.add("card-text");
            carddescription.id="testo"+i;

            var cardbody = document.createElement("div");
            cardbody.classList.add("card-body");

            var cardBlockquote = document.createElement("blockquote");
            cardBlockquote.classList.add("blockquote");
            cardBlockquote.classList.add("mb-0");

            var cardfooter = document.createElement("footer");
            cardfooter.classList.add("blockquote-footer");

            var ratings = document.createElement("div");
            ratings.classList.add("card-footer");
            ratings.classList.add("text-muted");

            var stars = document.createElement("div");
            stars.classList.add("stars-outer");

            var innerStars = document.createElement("div");
            innerStars.classList.add("stars-inner");

            var votes = document.createElement("div");

            const citazione = data[i];

            cardtitle.innerHTML = "Citazione " + (i + 1);
            carddescription.innerHTML = citazione.sr;
            cardfooter.innerHTML = citazione.author;
            var voti = citazione.numberOfVotes;
            console.log(voti);
            if (voti == undefined) {
                voti = 0;
            }
            votes.innerHTML = voti + " voti.";
            var stelle = citazione.rating;
            var percStelle = (stelle / 5) * 100;
            var stelleRot = `${(Math.round(percStelle / 1) * 1)}%`;
            innerStars.setAttribute("style", "width:" + stelleRot);

            card.addEventListener("mouseover", function () {
                var txt = document.getElementById("testo"+i);
                txt.innerHTML = citazione.en;
            })

            card.addEventListener("mouseout", function () {
                var txt = document.getElementById("testo"+i);
                txt.innerHTML = citazione.sr;
            })

           /* function handler(event) {

                function str(el) {
                    if (!el) return "null"
                    return el.className || el.tagName;
                }

                if (event.type == 'mouseover') {
                    carddescription.innerHTML = citazione.en;
                    console.log("in");
                }
                if (event.type == 'mouseout') {
                    carddescription.innerHTML = citazione.sr;
                    console.log("out");
                }
            }*/

            cardBlockquote.append(cardfooter);
            cardbody.append(carddescription);
            cardbody.append(cardBlockquote);
            stars.append(innerStars);
            ratings.append(stars);
            ratings.append(votes);
            card.append(cardtitle);
            card.append(cardbody);
            card.append(ratings);


            column.append(card)

            pnl.append(column);
        }
    });

    console.log(list);
}



function cerca(url) {
    pnl.innerHTML = "";
    var nome = document.getElementById("txtCerca").value;
    txtCerca.value = "";

    fetch(url).then(function (response) {
        x = false;
        return response.json();
    }).then(function (data) {
        list = data.count;


        console.log(data);
        for (let i = 0; i < data.length; i++) {
            const citazione = data[i];
            if (nome === citazione.author) {
                var column = document.createElement("div");
                column.classList.add("col-6");
                column.classList.add("offset-3");

                var card = document.createElement("div");
                card.classList.add("card");
                card.classList.add("carta");
                card.classList.add("mt-4");
                card.classList.add("text-center");

                //If card isnt clicked...

                var cardtitle = document.createElement("div");
                cardtitle.classList.add("card-header");
                cardtitle.classList.add("ml-0");
                cardtitle.classList.add("mr-0");
                cardtitle.setAttribute("width", "100%");

                var carddescription = document.createElement("p");
                carddescription.classList.add("card-text");

                var cardbody = document.createElement("div");
                cardbody.classList.add("card-body");

                var cardBlockquote = document.createElement("blockquote");
                cardBlockquote.classList.add("blockquote");
                cardBlockquote.classList.add("mb-0");

                var cardfooter = document.createElement("footer");
                cardfooter.classList.add("blockquote-footer");

                var ratings = document.createElement("div");
                ratings.classList.add("card-footer");
                ratings.classList.add("text-muted");

                var stars = document.createElement("div");
                stars.classList.add("stars-outer");

                var innerStars = document.createElement("div");
                innerStars.classList.add("stars-inner");

                var votes = document.createElement("div");

                cardtitle.innerHTML = "Citazione " + (i + 1);
                carddescription.innerHTML = citazione.en;
                cardfooter.innerHTML = citazione.author;
                var voti = citazione.numberOfVotes;
                if (voti == undefined) {
                    voti = 0;
                }
                votes.innerHTML = voti + " voti.";
                var stelle = citazione.rating;
                var percStelle = (stelle / 5) * 100;
                var stelleRot = `${(Math.round(percStelle / 1) * 1)}%`;
                innerStars.setAttribute("style", "width:" + stelleRot);

                cardBlockquote.append(cardfooter);
                cardbody.append(carddescription);
                cardbody.append(cardBlockquote);
                stars.append(innerStars);
                ratings.append(stars);
                ratings.append(votes);
                card.append(cardtitle);
                card.append(cardbody);
                card.append(ratings);


                column.append(card)

                pnl.append(column);
            }
        }
    });

    console.log(list);
}