#Teorema cinese del resto


def checkWeek(P):
    if P>7:
        aux = P-7
        return aux
    else:
        aux = int(P)
        return aux


def findDay(pr1,pr2,pr3,pr4,pr5,pr6):
    if (pr1==pr2) and (pr2==pr3) and (pr3==pr4) and (pr4==pr5) and (pr5==pr6):
        return True

def checkDay(index, agg):
    if index%12 == 0:
        aux = 12
        return aux
    else:
        aux = 0
        return aux

def main():

    
    Pr1 = 1
    Pr2 = 2
    Pr3 = 3
    Pr4 = 4
    Pr5 = 5
    Pr6 = 6

    ADD_P1 = 2
    ADD_P2 = 3
    ADD_P3 = 4
    ADD_P4 = 6
    ADD_P5 = 1
    ADD_P6 = 5

    indice = 0
    giorni = 0
    trovato = False
    
    while trovato != True:
        indice+=1

        print("Indice:" ,indice)

        P1=checkWeek(Pr1)
        P2=checkWeek(Pr2)
        P3=checkWeek(Pr3)
        P4=checkWeek(Pr4)
        P5=checkWeek(Pr5)
        P6=checkWeek(Pr6)

        if indice%6==0:
            Pr1 = fixDay(P1, ADD_P1, 6)
            Pr2 = fixDay(P2, ADD_P2, 6)
            Pr4 = fixDay(P4, ADD_P4, 6)
        elif indice%12==0:
            Pr1 = fixDay(P1, ADD_P1, 12)
            Pr2 = fixDay(P2, ADD_P2, 12)
            Pr3 = fixDay(P3, ADD_P3, 12)
            Pr4 = fixDay(P4, ADD_P4, 12)


        print("P1:",P1)
        print("P2:",P2)
        print("P3:",P3)
        print("P4:",P4)
        print("P5:",P5)
        print("P6:",P6)

        trovato = findDay(P1,P2,P3,P4,P5,P6)

        
        

        print("Giorni = " , giorni)
    
    print("Sono passati ", giorni , " giorni.")

main()
