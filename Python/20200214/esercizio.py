class CC:
    def __init__(self,nome,conto,importo_iniziale):
        self.nome=nome
        self.conto=conto
        self.importo_iniziale=importo_iniziale
    
    def preleva(self,importo):
        self.importo_iniziale -= importo

    def deposita(self,importo):
        self.importo_iniziale += importo

    def descrizione(self):
        print("Nome: ", self.nome)
        print("Numero conto: ", self.conto)
        print("Saldo: ", self.importo_iniziale)

nome = input("Inserisci un nome: ")
numConto = input("Inserisci il numero di conto: ")
importoIniziale = int(input("Inserisci importo iniziale: "))

conti = CC(nome,numConto,importoIniziale)

preleva = int(input("Inserisci soldi da prelevare: "))

conti.preleva(preleva)

conti.descrizione()

deposita = int(input("Inserisci soldi da depositare: "))

conti.deposita(deposita)

conti.descrizione()
