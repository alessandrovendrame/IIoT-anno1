a = input("Inserisci il primo numero: ")
b = input("Inserissci il secondo numero: ")
num1 = int(a)
num2 = int(b)

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
        
print("L'MCD è ", max)

mcm = (num1*num2)/max

print("L'mcm è ",mcm)
