#ESERCIZIO 1
#Dati due numeri a,b interi, diciamo MCD(a,b)=c allora esistono x,y interi, tale che: c=ax+by.
#Costruire un programma che trovi x e y.

def MCD(num1,num2):
    if num1<num2:
        max=num2
        min=num1
    else:
        max=num1
        min=num2

    resto=1

    while(resto!=0):
        resto = int(max%min)
        max=min
        min=resto

    return max

n1 = input("Inserisci il primo numero: ")
n2 = input("Inserissci il secondo numero: ")
a = int(n1)
b = int(n2)

mcd=MCD(a,b)

r1 = a%b
m0 = a//b

print(r1,",",m0)

r2 = b%r1
m1 = b//r1

print(r2,",",m1)

res1 = -m1

res2 = (m1 * m0)+1

print(res1 , " , " , res2)



