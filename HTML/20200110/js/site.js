var celle = document.querySelectorAll(".cella");
var X="casellaX";
var O="casellaO";
var turno = 0;

var update = function(e){
    if(this.classList.contains(X)||this.classList.contains(O))
    {
        alert("Casella già selezionata");
    }else{
        if(turno%2==0){
            this.classList.add(X);
            if(controllaOrizzontali(0,1,2,X) || controllaVerticali(0,3,6,X) || controllaObliquo(0,4,8,X))
            {
                vincente(X);
            }
            turno++;
            controlla(turno);
        }else
        {
            this.classList.add(O);
            if(controllaOrizzontali(0,1,2,O) || controllaVerticali(0,3,6,O) || controllaObliquo(0,4,8,O))
            {
                vincente(O);
            }
            turno++;
            controlla(turno);
        }  
    }         
}


function controlla(t)
{
    if(turno>8)
    {
        setTimeout(() => {
            if(!alert('Nessuno ha vinto!')){window.location.reload();}
        }, 700);
    }
}

function controllaOrizzontali(a,b,c,gioc)
{
    for(;c<=8;)
    {
        if(celle[a].classList.contains(gioc)&&celle[b].classList.contains(gioc)&&celle[c].classList.contains(gioc)){
            return true
        }else{
            a+=3;
            b+=3;
            c+=3;
        }
    }
    return false;
}

function controllaVerticali(a,b,c,gioc)
{
    for(;c<=8;)
    {
        if(celle[a].classList.contains(gioc)&&celle[b].classList.contains(gioc)&&celle[c].classList.contains(gioc))
        {
            return true;
        }else{
            a+=1;
            b+=1;
            c+=1;
        }
    }
    return false;
}

function controllaObliquo(a,b,c,gioc)
{
    for(;a<=2;)
    {
        if(celle[a].classList.contains(gioc)&&celle[b].classList.contains(gioc)&&celle[c].classList.contains(gioc))
        {
            return true;
        }else{
            a+=2;
            c-=2;
        }
    }
    return false;
}

function vincente(gioc)
{
    if(gioc=="casellaX")
    {
        if(!alert('HA VINTO X!')){window.location.reload();}
    }else{
        if(!alert('HA VINTO O!')){window.location.reload();}
    }
}

for (let i = 0; i < celle.length; i++) {
    const cella = celle[i];
    cella.addEventListener("click",update);
}


