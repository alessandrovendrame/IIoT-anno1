class Conto:
    def __init__(self,nome,conto):
        self.nome=nome
        self.conto=conto

class ContoCorrente(Conto):
    def __init__(self, nome, conto,importo):
        super().__init__(nome, conto)
        self.__saldo=importo
    
    def preleva(self,importo):
        self.__saldo -= importo
    
    def deposita(self,importo):
        self.__saldo += importo

    

class GCC:
    @staticmethod
    def bonifico(sorg,dest,importo):
        sorg.preleva(importo)
        dest.deposita(importo)