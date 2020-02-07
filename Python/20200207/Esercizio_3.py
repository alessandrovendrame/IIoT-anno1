def listaDiff(List1,List2):
    l=[]
    for x in List1:
        if not x in List2:
                l.append(x)
    return l

L1=[]
L2=['1','2','3','4','5']

for i in range(5):
    L1.append(input("Inserisci valore: "))

for i in range(5):
    aux=input("Inserisci il valore: ")
    if aux!="":
        L2.pop(i)
        L2.insert(i,aux)
    else:
        break

print(listaDiff(L1,L2))
print(L2)



