var btnApi = document.getElementById("btnGetAPI");
var pnl = document.getElementById("pnlOut");
var btnCerca = document.getElementById("btnCerca");
var txt = document.getElementById("txtCerca");
var cercato=false;
var btnHome = document.getElementById("btnHome");

var index=0;
var pagecount=20;
var x = false;

var link="https://gateway.marvel.com:443/v1/public/characters?";
var ApiCode = "4fa21dccd7356d242036c36ce32a0fe6";


document.addEventListener("DOMContentLoaded", function() {
    getSWData("https://gateway.marvel.com:443/v1/public/characters?apikey=4fa21dccd7356d242036c36ce32a0fe6");
});

btnCerca.addEventListener("click", function() {
    cerca();
});

btnHome.addEventListener("click",function () {
    pnl.innerHTML="";
    getSWData("https://gateway.marvel.com:443/v1/public/characters?apikey=4fa21dccd7356d242036c36ce32a0fe6");
    cercato=false;
})

function getSWData(url){
    var list = 0;
    x = true;
    fetch(url).then(function (response) {
        x= false;
        return response.json();
    }).then(function (data) {
        list = data.data.count;

        console.log(data.data);
        for (let i = 0; i < data.data.results.length; i++) {
            var card=document.createElement("div");
            card.classList.add("card");
            card.classList.add("col-3");
            card.classList.add("carta");
            card.setAttribute("data-toggle","modal");
            card.setAttribute("data-target", "#myModal" + i);

            card.addEventListener("click",function(){
                cercato=true;

                var modal=document.createElement("div");
                modal.classList.add("modal");
                modal.id="myModal" + i;
                console.log(modal.id);
                //dialog
                var modalDialog=document.createElement("div");
                modalDialog.classList.add("modal-dialog");
                modalDialog.classList.add("modal-xl");
                //content
                var modalContent=document.createElement("div");
                modalContent.classList.add("modal-content");
                //header
                var modalHeader=document.createElement("div");
                modalHeader.classList.add("modal-header");
                //headerTitle
                var modalTitle=document.createElement("h4");
                modalTitle.classList.add("modal-title");
                //closeButton
                var closeButton=document.createElement("button");
                closeButton.classList.add("close");
                closeButton.setAttribute("data-dismiss", "modal");
                closeButton.innerHTML="&times;"
                //modalBody
                var modalBody=document.createElement("div");
                modalBody.classList.add("modal-body");

                var card=document.createElement("div");
                card.classList.add("card");
                card.classList.add("col-6");
                card.classList.add("offset-3");

                var cardimg=document.createElement("img");
                cardimg.classList.add("card-img-top");
                cardimg.setAttribute("height", "600px");

                var cardtitle=document.createElement("h5");
                cardtitle.classList.add("card-header");

                var carddescription =document.createElement("p");
                carddescription.classList.add("card-text");

                var cardbody=document.createElement("div");
                cardbody.classList.add("card-body");

                const supereroe = data.data.results[i];

                cardtitle.innerHTML=supereroe.name;
                carddescription.innerHTML=supereroe.description;
                var source = supereroe.thumbnail.path + "." + supereroe.thumbnail.extension;
                cardimg.src=source;

                //append statement

                cardbody.append(carddescription);
                card.append(cardimg);
                card.append(cardtitle);
                card.append(cardbody);

                modalBody.append(card);
                modalHeader.append(modalTitle);
                modalHeader.append(closeButton);
                modalContent.append(modalHeader);
                modalContent.append(modalBody);
                modalDialog.append(modalContent);
                modal.append(modalDialog);

                //print statement

                pnl.append(modal);

            });

            //If buttonn isnt clicked...

            var cardimg=document.createElement("img");
            cardimg.classList.add("card-img-top");
            cardimg.setAttribute("height", "350px");

            var cardtitle=document.createElement("h5");
            cardtitle.classList.add("card-header");

            var carddescription =document.createElement("p");
            carddescription.classList.add("card-text");

            var cardbody=document.createElement("div");
            cardbody.classList.add("card-body");
            
            const supereroe = data.data.results[i];

            cardtitle.innerHTML=supereroe.name;
            carddescription.innerHTML=supereroe.description;
            var source = supereroe.thumbnail.path + "." + supereroe.thumbnail.extension;
            cardimg.src=source;

            cardbody.append(carddescription);
            card.append(cardimg);
            card.append(cardtitle);
            card.append(cardbody);

            pnl.appendChild(card);
        }
    });
    
    console.log(list);
}



function cerca(){
    var nome = document.getElementById("txtCerca").value;
    txtCerca.value="";

    cercato = true;
    
    if(nome!="")
    {
        var search = "nameStartsWith=";
        search = search + nome + "&";
        pnl.innerHTML="";
        txtCerca.value="";
        getSWData("https://gateway.marvel.com:443/v1/public/characters?" + search + "apikey=4fa21dccd7356d242036c36ce32a0fe6");
    }else
    {
        alert("Devi inserire un nome prima di premere il bottone!");
        pnl.innerHTML="";
        txtCerca.value="";
        getSWData("https://gateway.marvel.com:443/v1/public/characters?apikey=4fa21dccd7356d242036c36ce32a0fe6");
    }
}

window.onscroll = function(ev) {
    if(cercato==false){
        if ((window.innerHeight + window.scrollY + 100)  >= document.body.scrollHeight && !x) {
            // you're at the bottom of the page
            console.log("Bottom of page");
            index+=this.pagecount;
            getSWData('https://gateway.marvel.com:443/v1/public/characters?apikey=4fa21dccd7356d242036c36ce32a0fe6&offset=' + this.index);
      
          }
    }
};