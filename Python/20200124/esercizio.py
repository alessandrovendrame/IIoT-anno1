"""
#-------------------------APPUNTI-------------------------
Liste [.....] --> MUTABILI, posso inserire e modificare i valori al suo interno
{
            type = list()
    
    myList = [] --> Lista vuota
    myList = list() --> costruttore
    myList = [10,20,30] --> Lista con oggetti all'interno
    print(myList[2]) --> 30
    print(myList[-1]) --> 30
    print(myList[:2]) --> 10,20


    myList[[1,2],[2,3],[6,7]]
    print(myList[0]) --> [1,2]
    print(myList[0][1]) --> 2

    myList.insert(2,20) --> inserisce in posizione 2 il numero 20
    myList.append(20)   --> inserisce il numero in fondo

    len(myList)         --> restituisce la grandezza della lista

    del myList[1]       --> Elimina l'elemento nella posizione inserita

    20 in myList        --> Restituisce true/false a seconda della presenza dell'elemento all'interno della lista

    myList2 = myList    --> myList2 punta alla stessa posizione di myList
    myList2[1] = 60     --> quindi in caso cambiassi il valore di un elemento in uno delle due liste cambierebbe anche nell'altra
    print(myList[1])    --> 60

    myList2 = myList.copy --> copia i valori di myList in myList2
}

Tuple (.....) --> NON MUTABILI
"""

"""
#-------------------PROVA PRIMO ESERCIZIO-----------------
s="buon"
t="giorno"

print(s+t)
#buongiorno
print(len(s+t))
#10
print(min(s+t)) #prende il valore minore nella stringa
#b
print(max(s+t)) #prende valore maggiore nella stringa
#u

a=input("sei contento")
#----------------------------------------------------------
"""

"""
#---------------------SECONDO ESERCIZIO--------------------
print(str(False))
#False
print(str(True))
#True
print(str(10.5))
#10.5
print(bool(10))
#True
print(bool(20))
#True
print(bool(0.5))
#True
print(bool(0))
#False
a=input("")
#----------------------------------------------------------
"""

