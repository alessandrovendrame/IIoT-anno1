#ESERCIZIO 2:
#Data una scacchiera n*n (n inserito dall'utente), inserire n regine e fare in modfo che a 2 a 2 non si mangino.
#P.S: Le regine si muovono orizzontalmente, verticalmente e seguendo le 2 diagonali

COLONNE = 4

def caricaColonne(s,v):
    
    print("S è uguale a: ",s)

    if s < COLONNE:
        for i in range(0,COLONNE,1):
           
            if controllaColonne(s,i,v):
                v.insert(s,i)
                print("v[s]]=" , v[s])
                caricaColonne(s+1,v)
    else:
        print("V è uguale a: ", v)
        return v
                
    
def controllaColonne(s, indice,v):
    print("Controllo :" , indice)
    for k in range(0,s,1):
        print("Indice = ",indice)
        aux = v[k]
        print("aux=",aux)
        if aux == indice or aux == (indice-(s-k)) or aux == (indice+(s-k)):
            return False
    
    return True

def main():

    v = []

    g=caricaColonne(0,v)

    print(g)

main()

