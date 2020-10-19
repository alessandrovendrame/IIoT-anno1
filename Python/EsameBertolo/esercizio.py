import random

class Carta():
    def __init__(self, numero, seme):
        self.value = numero
        self.seme = seme
    
    def valore(self):
        return value

    def __str__(self):
        stringa = self.value + " di " + self.seme
        return stringa

class Deck():
    def __init__(self):
        pass
  
    def pesca(self):
        semi = ["quadri","cuori","picche","fiori"]
        return Carta(random.randint(1,10), random.choice(semi))

class Sette_Mezzo():
    def round(self):
        pass
    
    def play(self, turni=5):
        pass