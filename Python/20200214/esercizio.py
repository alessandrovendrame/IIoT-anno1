class CC:
    def __init__(self,nome,conto,importo):
        self.nome=nome
        self.conto=conto
        self.__saldo=importo

    def preleva(self,importo):
        self.__saldo -= importo

    def deposita(self,importo):
        self.__saldo += importo
    
    @property
    def saldofinale(self):
        return self.__saldo

    @saldofinale.setter
    def saldofinale(self,importo):
        self.preleva(self.__saldo)
        print(self.__saldo)
        self.deposita(importo)

    def descrizione(self):
        print("Nome: ", self.nome)
        print("Numero conto: ", self.conto)
        print("Saldo: ", self.__saldo)

nome = input("Inserisci un nome: ")
numConto = input("Inserisci il numero di conto: ")
importoIniziale = int(input("Inserisci importo iniziale: "))

conti = CC(nome,numConto,1000)

#preleva = int(input("Inserisci soldi da prelevare: "))
conti.preleva(500)
conti.descrizione()
#deposita = int(input("Inserisci soldi da depositare: "))
conti.deposita(700)
conti.descrizione()
#se = int(input("A quanto vuoi impostare il conto: "))
conti.saldofinale(200)

conti.saldofinale
