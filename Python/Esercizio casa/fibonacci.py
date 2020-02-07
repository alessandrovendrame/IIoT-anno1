n=input("Inserisci il k-nesimo numero che vuoi visualizzare: ")
numero=int(n)

i=1
a,b=0,1

while(i<numero):
    a,b=b,a+b
    print(i,": ",a)
    i=i+1
    

print("Il numero in posizione ",n," è il ",a)