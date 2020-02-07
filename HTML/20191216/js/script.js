var risultato=0;
var numero="";
var numero2="";
var operatore="";

function scriviCalc(id)
{
    document.getElementById("txtCalc").value+=id;
}

function scriviOp(id)
{
    numero=document.getElementById("txtCalc").value;
    operatore=id;
    document.getElementById("txtCalc").value="";
    disableButtons();
    document.getElementById("=").disabled=false;
    console.log(operatore)
}

function getRisultato()
{
    numero2=document.getElementById("txtCalc").value;
    switch(operatore)
    {
        case "+":
            risultato = (parseFloat(numero) + parseFloat(numero2)).toFixed(2);
            document.getElementById("txtCalc").value=risultato.toString();
            enableButtons();
            document.getElementById("=").disabled=true;
            break;
        case "-":
            risultato = (parseFloat(numero) - parseFloat(numero2)).toFixed(2);
            document.getElementById("txtCalc").value=risultato.toString();
            enableButtons();
            document.getElementById("=").disabled=true;
            break;
        case "X":
            risultato = (parseFloat(numero) * parseFloat(numero2)).toFixed(2);
            document.getElementById("txtCalc").value=risultato.toString();
            enableButtons();
            document.getElementById("=").disabled=true;
            break;
        case "/":
            risultato = (parseFloat(numero) / parseFloat(numero2)).toFixed(2);
            document.getElementById("txtCalc").value=risultato.toString();
            enableButtons();
            document.getElementById("=").disabled=true;
            break;
    }
}

function cancellaCalc()
{
    document.getElementById("txtCalc").value="";
    document.getElementById("txtCalc").value="";
    enableButtons();
    document.getElementById("=").disabled=true;
}

function enableButtons()
{
    document.getElementById("+").disabled= false;
    document.getElementById("-").disabled= false;
    document.getElementById("X").disabled= false;
    document.getElementById("/").disabled= false;
}

function disableButtons()
{
    document.getElementById("+").disabled= true;
    document.getElementById("-").disabled= true;
    document.getElementById("X").disabled= true;
    document.getElementById("/").disabled= true;
}

