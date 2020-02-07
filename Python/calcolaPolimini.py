import math

num = int(input("Inserisci numero di cubetti: "))

risultato = int(math.factorial(num))

combinazioni = int(risultato/num)

print("Le combinazioni possibili sono: ", combinazioni)